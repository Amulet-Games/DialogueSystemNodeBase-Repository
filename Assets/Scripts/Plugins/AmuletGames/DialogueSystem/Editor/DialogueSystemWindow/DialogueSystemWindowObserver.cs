using UnityEditor;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG.DS
{
    public class DialogueSystemWindowObserver
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
        /// Reference of the node create request window.
        /// </summary>
        NodeCreateRequestWindow nodeCreateRequestWindow;


        /// <summary>
        /// The targeting dialogue system window.
        /// </summary>
        DialogueSystemWindow dsWindow;


        /// <summary>
        /// Reference of the root visual element in the dialogue system window.
        /// </summary>
        VisualElement windowRootElement;


        /// <summary>
        /// Has the user released the previously pressed hotkey?
        /// </summary>
        bool isHotkeyReleased;


        /// <summary>
        /// Constructor of the dialogue system window observer class.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="nodeCreateRequestWindow">The node create request window to set for.</param>
        /// <param name="dsWindow">The dialogue system window to set for.</param>
        public DialogueSystemWindowObserver
        (
            DialogueSystemModel dsModel,
            GraphViewer graphViewer,
            HeadBar headBar,
            NodeCreateRequestWindow nodeCreateRequestWindow,
            DialogueSystemWindow dsWindow
        )
        {
            this.dsModel = dsModel;
            this.graphViewer = graphViewer;
            this.headBar = headBar;
            this.nodeCreateRequestWindow = nodeCreateRequestWindow;
            this.dsWindow = dsWindow;

            windowRootElement = dsWindow.rootVisualElement;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the dialogue system window.
        /// </summary>
        public void RegisterEvents()
        {
            // Serialization events
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
        /// Register ApplyChangesToDiskEvent to the dialogue system window.
        /// </summary>
        void RegisterApplyChangesToDiskEvent() => dsWindow.ApplyChangesToDiskEvent += ApplyChangesToDiskEvent;


        /// <summary>
        /// Register WindowOnDisableEvent to the dialogue system window.
        /// </summary>
        void RegisterWindowOnDisableEvent() => dsWindow.WindowOnDisableEvent += WindowOnDisableEvent;


        /// <summary>
        /// Register WindowOnDestroyEvent to the dialogue system window.
        /// </summary>
        void RegisterWindowOnDestroyEvent() => dsWindow.WindowOnDestroyEvent += WindowOnDestroyEvent;


        /// <summary>
        /// Register KeyDownEvent to the dialogue system window root visual element.
        /// </summary>
        void RegisterKeyDownEvent() => windowRootElement.RegisterCallback<KeyDownEvent>(KeyDownEvent);


        /// <summary>
        /// Register KeyUpEvent to the dialogue system window root visual element.
        /// </summary>
        void RegisterKeyUpEvent() => windowRootElement.RegisterCallback<KeyUpEvent>(KeyUpEvent);


        /// <summary>
        /// Register GeometryChangedEvent to the dialogue system window root visual element.
        /// </summary>
        void RegisterGeometryChangedEvent() => windowRootElement.ExecuteOnceOnGeometryChanged(GeometryChangedEvent);


        /// <summary>
        /// Register m_WindowChangedEvent to the static WindowChangedEvent.
        /// </summary>
        void RegisterWindowChangedEvent() => WindowChangedEvent.Register(m_WindowChangesEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke to write all the unsaved changes to the disk.
        /// </summary>
        void ApplyChangesToDiskEvent()
        {
            AssetDatabase.SaveAssets();

            dsWindow.HasUnsavedChanges = false;
        }


        /// <summary>
        /// The event to invoke when the dialogue system window's OnDisable is called.
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
        /// The event to invoke when the dialogue system window's OnDestroy is called.
        /// </summary>
        void WindowOnDestroyEvent()
        {
            WindowChangedEvent.Unregister(m_WindowChangesEvent);

            dsModel.IsAlreadyOpened = false;
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
        /// The event to invoke when the dialogue system window root visual element's geometry has changed.
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
        /// The event to invoke when there are new changes happened to the dialogue system window.
        /// </summary>
        void m_WindowChangesEvent()
        {
            if (dsWindow.hasFocus)
            {
                dsWindow.HasUnsavedChanges = true;
            }
        }
    }
}