using UnityEngine;

namespace AG.DS
{
    public class ProjectManager
    {
        /// <summary>
        /// Reference of the dialogue system data.
        /// </summary>
        DialogueSystemData dsData;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        HeadBar headBar;


        /// <summary>
        /// Reference of the undo redo handler.
        /// </summary>
        UndoRedoHandler undoRedoHandler;


        /// <summary>
        /// Reference of the serialize handler.
        /// </summary>
        SerializeHandler serializeHandler;


        /// <summary>
        /// Reference of th dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// Reference of the dialogue editor window callback.
        /// </summary>
        DialogueEditorWindowCallback dsWindowCallback;


        /// <summary>
        /// Reference of the node create connector window.
        /// </summary>
        public NodeCreateConnectorWindow NodeCreateConnectorWindow;


        /// <summary>
        /// Reference of the node create request window.
        /// </summary>
        NodeCreateRequestWindow nodeCreateRequestWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the project manager class.
        /// </summary>
        /// <param name="dsData">The dialogue system data to set for.</param>
        public ProjectManager(DialogueSystemData dsData)
        {
            this.dsData = dsData;

            PreSetup();

            Setup();

            PostSetup();
        }


        /// <summary>
        /// Pre-setup for the class.
        /// </summary>
        void PreSetup()
        {
            // Setup singletons
            ConfigResourcesManager.Setup();
            LanguageManager.Setup();
            HotkeyManager.Setup();
            EdgeManager.Setup();
        }


        /// <summary>
        /// Setup for the class.
        /// </summary>
        void Setup()
        {
            // Create modules
            {
                // Graph Viewer
                graphViewer = GraphViewerPresenter.CreateElement(projectManager: this);

                // HeadBar
                headBar = HeadBarPresenter.CreateElement(dsData);

                // Dialogue Editor Window
                dsWindow = DialogueEditorWindowPresenter.CreateWindow(dsData, projectManager: this);
                dsWindow.rootVisualElement.Add(graphViewer);
                dsWindow.rootVisualElement.Add(headBar);

                // Serialize Handler
                serializeHandler = new(graphViewer);

                // Node Create Window
                nodeCreateRequestWindow = NodeCreateRequestWindowPresenter.CreateWindow
                (
                    graphViewer,
                    dsWindow,
                    serializeHandler
                );
                NodeCreateConnectorWindow = NodeCreateConnectorWindowPresenter.CreateWindow
                (
                    graphViewer,
                    dsWindow,
                    serializeHandler
                );
                NodeCreateEntryProvider.SetupNodeCreateWindowEntries();
            }

            // Register modules events
            {
                // Graph Viewer
                var graphViewerCallback = new GraphViewerCallback
                (
                    graphViewer,
                    dsWindow,
                    nodeCreateRequestWindow
                );

                graphViewerCallback.SetCallbacks();
                graphViewerCallback.RegisterEvents();

                // HeadBar
                new HeadBarCallback(
                    headBar,
                    dsWindow,
                    dsData.InstanceId,
                    projectManager: this).RegisterEvents();

                // Dialogue Editor Window
                dsWindowCallback = new DialogueEditorWindowCallback
                (
                    dsWindow,
                    graphViewer,
                    headBar,
                    projectManager: this
                );

                dsWindowCallback.RegisterEventsSetup();
            }
        }


        /// <summary>
        /// Post-setup for the class.
        /// </summary>
        void PostSetup()
        {
            // Register static events
            new ProjectCallback(
                dsWindow,
                dsWindowCallback,
                graphViewer,
                headBar,
                serializeHandler,
                projectManager: this).RegisterEvents();
        }


        /// <summary>
        /// Save all the graph elements on the custom graph editor.
        /// </summary>
        public void Save()
        {
            if (dsWindow.hasUnsavedChanges)
            {
                SaveToDSDataEvent.Invoke(dsData);
                ApplyChangesToDiskEvent.Invoke();
            }
            else
            {
                Debug.LogWarning(StringConfig.Editor_WindowAlreadySaved_WarningText);
            }
        }


        /// <summary>
        /// Load the saved graph elements and create them again on the graph.
        /// </summary>
        public void Load(bool isForceLoadWindow)
        {
            if (isForceLoadWindow || dsWindow.hasUnsavedChanges)
            {
                LoadFromDSDataEvent.Invoke(dsData);
                ApplyChangesToDiskEvent.Invoke();
            }
            else
            {
                Debug.LogWarning(StringConfig.Editor_WindowAlreadyLoaded_WarningText);
            }
        }
    }
}