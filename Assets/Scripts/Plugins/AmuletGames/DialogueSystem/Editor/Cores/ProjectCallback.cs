using UnityEditor;

namespace AG.DS
{
    public class ProjectCallback
    {
        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// Reference of the dialogue editor window callback.
        /// </summary>
        DialogueEditorWindowCallback dsWindowCallback;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        HeadBar headBar;


        /// <summary>
        /// Reference of the serialize handler.
        /// </summary>
        SerializeHandler serializeHandler;


        /// <summary>
        /// Reference of the project manager.
        /// </summary>
        ProjectManager projectManager;


        /// <summary>
        /// Constructor of the project manager callback class.
        /// </summary>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        /// <param name="dsWindowCallback">The dialogue editor window callback to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="serializeHandler">The serialize handler to set for.</param>
        /// <param name="projectManager">The project manager to set for.</param>
        public ProjectCallback
        (
            DialogueEditorWindow dsWindow,
            DialogueEditorWindowCallback dsWindowCallback,
            GraphViewer graphViewer,
            HeadBar headBar,
            SerializeHandler serializeHandler,
            ProjectManager projectManager
        )
        {
            this.dsWindow = dsWindow;
            this.dsWindowCallback = dsWindowCallback;
            this.graphViewer = graphViewer;
            this.headBar = headBar;
            this.serializeHandler = serializeHandler;
            this.projectManager = projectManager;
        }


        // ----------------------------- Register Static Events -----------------------------
        /// <summary>
        /// Register events to the project.
        /// </summary>
        public void RegisterEvents()
        {
            // Serialization events
            RegisterSaveToDSDataEvent();
            RegisterLoadFromDSDataEvent();
            RegisterApplyChangesToDiskEvent();

            // Changed events
            RegisterGraphViewChangedEvent();
            RegisterSearchTreeEntrySelected();

            // Window events
            RegisterWindowOnEnableEvent();
            RegisterWindowOnDestroyEvent();
            RegisterWindowChangedEvent();
            RegisterWindowSaveChangesEvent();
        }


        /// <summary>
        /// Register SaveToDSDataEvent to the project.
        /// </summary>
        void RegisterSaveToDSDataEvent() => DS.SaveToDSDataEvent.Register(SaveToDSDataEvent);


        /// <summary>
        /// Register LoadFromDSDataEvent to the project.
        /// </summary>
        void RegisterLoadFromDSDataEvent() => DS.LoadFromDSDataEvent.Register(LoadFromDSDataEvent);


        /// <summary>
        /// Register ApplyChangesToDiskEvent to the project.
        /// </summary>
        void RegisterApplyChangesToDiskEvent() => DS.ApplyChangesToDiskEvent.Register(ApplyChangesToDiskEvent);


        /// <summary>
        /// Register GraphViewChangedEvent to the project.
        /// </summary>
        void RegisterGraphViewChangedEvent() => DS.GraphViewChangedEvent.Register(GraphViewChangedEvent);


        /// <summary>
        /// Register SearchTreeEntrySelectedEvent to the project.
        /// </summary>
        void RegisterSearchTreeEntrySelected() => DS.SearchTreeEntrySelectedEvent.Register(SearchTreeEntrySelectedEvent);


        /// <summary>
        /// Register WindowOnEnableEvent to the project.
        /// </summary>
        void RegisterWindowOnEnableEvent() => DS.WindowOnEnableEvent.Register(WindowOnEnableEvent);


        /// <summary>
        /// Register WindowOnDestroyEvent to the project.
        /// </summary>
        void RegisterWindowOnDestroyEvent() => DS.WindowOnDestroyEvent.Register(WindowOnDestroyEvent);


        /// <summary>
        /// Register WindowChangedEvent to the project.
        /// </summary>
        void RegisterWindowChangedEvent() => DS.WindowChangedEvent.Register(WindowChangedEvent);


        /// <summary>
        /// Register WindowSaveChangesEvent to the project.
        /// </summary>
        void RegisterWindowSaveChangesEvent() => DS.WindowSaveChangesEvent.Register(WindowSaveChangesEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the user clicked the save button in the headBar element.
        /// </summary>
        void SaveToDSDataEvent(DialogueSystemData dsData)
        {
            serializeHandler.SaveEdgesAndNodes(dsData);
        }


        /// <summary>
        /// The event to invoke when the dialogue editor window is first opened,
        /// <br>or when the user clicked the load button in the headBar element.</br>
        /// </summary>
        void LoadFromDSDataEvent(DialogueSystemData dsData)
        {
            graphViewer.ClearGraph();

            serializeHandler.LoadEdgesAndNodes(dsData);

            headBar.RefreshTitleAndLanguage(dsData);
        }


        /// <summary>
        /// The event to invoke after the saving or loading data serialization event,
        /// <br>also it'll be invoked when the dialogue editor window graph's title is edited.</br>
        /// </summary>
        void ApplyChangesToDiskEvent()
        {
            AssetDatabase.SaveAssets();

            dsWindow.SetHasUnsavedChanges(value: false);
        }


        /// <summary>
        /// The event to invoke when certain changes have occurred in the graph.
        /// </summary>
        void GraphViewChangedEvent()
        {
            dsWindow.SetHasUnsavedChanges(value: true);
        }


        /// <summary>
        /// The event to invoke when the user selected a search entry in the search tree window.
        /// </summary>
        void SearchTreeEntrySelectedEvent()
        {
            dsWindow.SetHasUnsavedChanges(value: true);
        }


        /// <summary>
        /// The event to invoke when the dialogue editor window's OnEnable callback is triggered.
        /// </summary> 
        void WindowOnEnableEvent()
        {
            dsWindowCallback.RegisterEventOnEnable();

            projectManager.Load(isForceLoadWindow: true);
        }


        /// <summary>
        /// The event to invoke when the dialogue editor window is closed.
        /// </summary>
        void WindowOnDestroyEvent()
        {
            // Clear static events
            {
                // Serialization events
                DS.SaveToDSDataEvent.Clear();
                DS.LoadFromDSDataEvent.Clear();
                DS.ApplyChangesToDiskEvent.Clear();

                // Changed events
                DS.GraphViewChangedEvent.Clear();
                DS.LanguageChangedEvent.Clear();
                DS.SearchTreeEntrySelectedEvent.Clear();

                // Window events
                DS.WindowOnEnableEvent.Clear();
                DS.WindowOnDestroyEvent.Clear();
                DS.WindowChangedEvent.Clear();
                DS.WindowSaveChangesEvent.Clear();
            }
        }


        /// <summary>
        /// The event to invoke when there are new changes happened to the dialogue editor window.
        /// </summary>
        void WindowChangedEvent()
        {
            dsWindow.SetHasUnsavedChanges(value: true);
        }


        /// <summary>
        /// The event to invoke when the user performed a save action in the dialogue editor window.
        /// </summary>
        void WindowSaveChangesEvent()
        {
            projectManager.Save();
        }
    }
}