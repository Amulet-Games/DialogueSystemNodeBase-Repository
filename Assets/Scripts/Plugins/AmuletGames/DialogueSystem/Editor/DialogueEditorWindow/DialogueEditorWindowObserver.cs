using UnityEditor;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG.DS
{
    public class DialogueEditorWindowObserver
    {
        /// <summary>
        /// Reference of the dialogue system model.
        /// </summary>
        DialogueSystemModel dsModel;


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
        /// Reference of the node create request window.
        /// </summary>
        NodeCreateRequestWindow nodeCreateRequestWindow;


        /// <summary>
        /// The targeting dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// Reference of the dialogue editor window root visual element.
        /// </summary>
        VisualElement windowRootElement;


        /// <summary>
        /// Has the user released the previously pressed hotkey?
        /// </summary>
        bool isHotkeyReleased;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue editor window observer class.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="serializeHandler">The serialize handler to set for.</param>
        /// <param name="nodeCreateRequestWindow">The node create request window to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        public DialogueEditorWindowObserver
        (
            DialogueSystemModel dsModel,
            GraphViewer graphViewer,
            HeadBar headBar,
            SerializeHandler serializeHandler,
            NodeCreateRequestWindow nodeCreateRequestWindow,
            DialogueEditorWindow dsWindow
        )
        {
            this.dsModel = dsModel;
            this.graphViewer = graphViewer;
            this.headBar = headBar;
            this.serializeHandler = serializeHandler;
            this.nodeCreateRequestWindow = nodeCreateRequestWindow;
            this.dsWindow = dsWindow;

            windowRootElement = dsWindow.rootVisualElement;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the dialogue editor window.
        /// </summary>
        public void RegisterEvents()
        {
            // Serialization events
            RegisterSaveToDSModelEvent();
            RegisterLoadFromDSModelEvent();
            RegisterApplyChangesToDiskEvent();

            // Window events
            RegisterWindowOnDisableEvent();
            RegisterWindowOnDestroyEvent();
            RegisterWindowChangedEvent();

            // Visual element events
            RegisterKeyDownEvent();
            RegisterKeyUpEvent();
            RegisterGeometryChangedEvent();
        }


        /// <summary>
        /// Register SaveToDSModelEvent to the dialogue editor window.
        /// </summary>
        void RegisterSaveToDSModelEvent() => dsWindow.SaveToDSModelEvent += SaveToDSModelEvent;


        /// <summary>
        /// Register LoadFromDSModelEvent to the dialogue editor window.
        /// </summary>
        void RegisterLoadFromDSModelEvent() => dsWindow.LoadFromDSModelEvent += LoadFromDSModelEvent;


        /// <summary>
        /// Register ApplyChangesToDiskEvent to the dialogue editor window.
        /// </summary>
        void RegisterApplyChangesToDiskEvent() => dsWindow.ApplyChangesToDiskEvent += ApplyChangesToDiskEvent;


        /// <summary>
        /// Register WindowOnDisableEvent to the dialogue editor window.
        /// </summary>
        void RegisterWindowOnDisableEvent() => dsWindow.WindowOnDisableEvent += WindowOnDisableEvent;


        /// <summary>
        /// Register WindowOnDestroyEvent to the dialogue editor window.
        /// </summary>
        void RegisterWindowOnDestroyEvent() => dsWindow.WindowOnDestroyEvent += WindowOnDestroyEvent;


        /// <summary>
        /// Register KeyDownEvent to the dialogue editor window root visual element.
        /// </summary>
        void RegisterKeyDownEvent() => windowRootElement.RegisterCallback<KeyDownEvent>(KeyDownEvent);


        /// <summary>
        /// Register KeyUpEvent to the dialogue editor window root visual element.
        /// </summary>
        void RegisterKeyUpEvent() => windowRootElement.RegisterCallback<KeyUpEvent>(KeyUpEvent);


        /// <summary>
        /// Register GeometryChangedEvent to the dialogue editor window root visual element.
        /// </summary>
        void RegisterGeometryChangedEvent() => windowRootElement.ExecuteOnceOnGeometryChanged(GeometryChangedEvent);


        /// <summary>
        /// Register m_WindowChangedEvent to the static WindowChangedEvent.
        /// </summary>
        void RegisterWindowChangedEvent() => WindowChangedEvent.Register(m_WindowChangesEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the user clicked the save button in the headBar element.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        void SaveToDSModelEvent(DialogueSystemModel dsModel)
        {
            serializeHandler.SaveEdgesAndNodes(dsModel);
        }


        /// <summary>
        /// The event to invoke when the dialogue editor window is first opened,
        /// <br>or when the user clicked the load button in the headBar element.</br>
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        void LoadFromDSModelEvent(DialogueSystemModel dsModel)
        {
            graphViewer.ClearGraph();

            serializeHandler.LoadEdgesAndNodes(dsModel);

            headBar.RefreshTitleAndLanguage(dsModel);
        }


        /// <summary>
        /// The event to invoke to write all the unsaved changes to the disk.
        /// </summary>
        void ApplyChangesToDiskEvent()
        {
            AssetDatabase.SaveAssets();

            dsWindow.SetHasUnsavedChanges(value: false);
        }


        /// <summary>
        /// The event to invoke when the dialogue editor window's OnDisable is called.
        /// </summary>
        void WindowOnDisableEvent()
        {
            // Dispose node create windows
            {
                Object.DestroyImmediate(nodeCreateRequestWindow, allowDestroyingAssets: true);
                Object.DestroyImmediate(graphViewer.NodeCreateConnectorWindow, allowDestroyingAssets: true);
            }
        }


        /// <summary>
        /// The event to invoke when the dialogue editor window's OnDestroy is called.
        /// </summary>
        void WindowOnDestroyEvent()
        {
            WindowChangedEvent.Unregister(m_WindowChangesEvent);

            dsModel.IsDsWindowAlreadyOpened = false;
        }


        /// <summary>
        /// The event to invoke when the user pressed any hotkeys in the empty space inside the window.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void KeyDownEvent(KeyDownEvent evt)
        {
            var hotkeyManager = HotkeyManager.Instance;

            // If the user hasn't released the previous pressed hotkey.
            if (!isHotkeyReleased)
                return;

            // If hotkey is not available at the moment.
            if (!graphViewer.IsFocus || !headBar.IsFocus)
                return;

            // If support key is being held down,
            if (hotkeyManager.IsSupportKeyDown(evt))
            {
                // Saving
                if (evt.keyCode == hotkeyManager.SaveKey)
                {
                    dsWindow.Save();
                    isHotkeyReleased = false;
                }

                // Loading
                if (evt.keyCode == hotkeyManager.LoadKey)
                {
                    dsWindow.Load(false);
                    isHotkeyReleased = false;
                }
            }
        }


        /// <summary>
        /// The event to invoke when the user released the hotkey that was pressed inside the window.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void KeyUpEvent(KeyUpEvent evt)
        {
            isHotkeyReleased = true;
        }


        /// <summary>
        /// The event to invoke when the dialogue editor window root visual element's geometry has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void GeometryChangedEvent(GeometryChangedEvent evt)
        {
            // Register events to the window's dock area
            {
                var dockArea = windowRootElement.parent.ElementAt(index: 0);
                dockArea.RegisterCallback<FocusEvent>(DockAreaFocusEvent);
                dockArea.RegisterCallback<BlurEvent>(DockAreaBlurEvent);
            }


            /// <summary>
            /// The event to invoke when the window's dock area has given focus.
            /// </summary>
            /// <param name="evt">The registering event.</param>
            void DockAreaFocusEvent(FocusEvent evt) => graphViewer.Focus();


            /// <summary>
            /// The event to invoke when the window's dock area has lost focus.
            /// </summary>
            /// <param name="evt">The registering event.</param>
            void DockAreaBlurEvent(BlurEvent evt) => graphViewer.Blur();
        }


        /// <summary>
        /// The event to invoke when there are new changes happened to the dialogue editor window.
        /// </summary>
        void m_WindowChangesEvent()
        {
            if (dsWindow.hasFocus)
            {
                dsWindow.SetHasUnsavedChanges(value: true);
            }
        }
    }
}