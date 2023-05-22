using UnityEditor;

namespace AG.DS
{
    public class ProjectManager
    {
        /// <summary>
        /// Reference of the dialogue system data.
        /// </summary>
        public DialogueSystemData DsData;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        Headbar headbar;


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
            DsData = dsData;

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
            {
                ConfigResourcesManager.Setup();

                LanguageManager.Setup();

                HotkeyManager.Setup();

                StyleConfig.Setup();

                StringConfig.Setup();

                EdgeManager.Setup();
            }
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

                // Headbar
                headbar = HeadbarPresenter.CreateElement(DsData);

                // Dialogue Editor Window
                dsWindow = DialogueEditorWindowPresenter.CreateWindow(DsData, projectManager: this);
                dsWindow.rootVisualElement.Add(graphViewer);
                dsWindow.rootVisualElement.Add(headbar);

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
                new GraphViewerCallback(
                    graphViewer,
                    dsWindow,
                    nodeCreateRequestWindow).RegisterEvents();

                // Headbar
                new HeadbarCallback(
                    headbar,
                    dsWindow,
                    DsData.InstanceId).RegisterEvents();

                // Dialogue Editor Window
                new DialogueEditorWindowCallback(
                    dsWindow,
                    graphViewer,
                    headbar).RegisterEventsSetup();
            }
        }


        /// <summary>
        /// Post-setup for the class.
        /// </summary>
        void PostSetup()
        {
            // Register static events
            {
                // Serialization events
                SaveToDSDataEvent.Register(action: serializeHandler.SaveEdgesAndNodes);

                LoadFromDSDataEvent.Register(action: dsData => graphViewer.ClearGraph());
                LoadFromDSDataEvent.Register(action: serializeHandler.LoadEdgesAndNodes);
                LoadFromDSDataEvent.Register(action: headbar.RefreshTitleAndLanguage);

                ApplyChangesToDiskEvent.Register(action: AssetDatabase.SaveAssets);
                ApplyChangesToDiskEvent.Register(action: () => dsWindow.SetHasUnsavedChanges(value: false));

                // Changed events
                GraphViewChangedEvent.Register(action: () => dsWindow.SetHasUnsavedChanges(value: true));

                TreeEntrySelectedEvent.Register(action: () => dsWindow.SetHasUnsavedChanges(value: true));

                WindowChangedEvent.Register(action: () => dsWindow.SetHasUnsavedChanges(value: true));
            }
        }


        /// <summary>
        /// Cleanup for the class.
        /// </summary>
        public void Cleanup()
        {
            // Dispose singletons
            {
                ConfigResourcesManager.Instance.Dispose();

                LanguageManager.Instance.Dispose();

                HotkeyManager.Instance.Dispose();

                StyleConfig.Instance.Dispose();

                StringConfig.Instance.Dispose();

                EdgeManager.Instance.Dispose();
            }

            // Clear static events
            {
                // Serialization Events
                SaveToDSDataEvent.Clear();
                LoadFromDSDataEvent.Clear();
                ApplyChangesToDiskEvent.Clear();

                // Changed Events
                GraphViewChangedEvent.Clear();
                LanguageChangedEvent.Clear();
                TreeEntrySelectedEvent.Clear();
                WindowChangedEvent.Clear();
            }
        }
    }
}