using UnityEditor;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG.DS
{
    public class DialogueSystemWindowObserver
    {
        /// <summary>
        /// Reference of the dialogue system window asset.
        /// </summary>
        DialogueSystemWindowAsset dialogueSystemWindowAsset;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        Headbar headBar;


        /// <summary>
        /// The targeting dialogue system window.
        /// </summary>
        DialogueSystemWindow dialogueSystemWindow;


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
        /// <param name="dialogueSystemWindowAsset">The dialogue system window asset to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="dialogueSystemWindow">The dialogue system window to set for.</param>
        public DialogueSystemWindowObserver
        (
            DialogueSystemWindowAsset dialogueSystemWindowAsset,
            GraphViewer graphViewer,
            Headbar headBar,
            DialogueSystemWindow dialogueSystemWindow
        )
        {
            this.dialogueSystemWindowAsset = dialogueSystemWindowAsset;
            this.graphViewer = graphViewer;
            this.headBar = headBar;
            this.dialogueSystemWindow = dialogueSystemWindow;

            windowRootElement = dialogueSystemWindow.rootVisualElement;
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
        void RegisterApplyChangesToDiskEvent() => dialogueSystemWindow.ApplyChangesToDiskEvent += ApplyChangesToDiskEvent;


        /// <summary>
        /// Register WindowOnDisableEvent to the dialogue system window.
        /// </summary>
        void RegisterWindowOnDisableEvent() => dialogueSystemWindow.WindowOnDisableEvent += WindowOnDisableEvent;


        /// <summary>
        /// Register WindowOnDestroyEvent to the dialogue system window.
        /// </summary>
        void RegisterWindowOnDestroyEvent() => dialogueSystemWindow.WindowOnDestroyEvent += WindowOnDestroyEvent;


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

            dialogueSystemWindow.HasUnsavedChanges = false;
        }


        /// <summary>
        /// The event to invoke when the dialogue system window's OnDisable is called.
        /// </summary>
        void WindowOnDisableEvent()
        {
            // Dispose search windows
            {
                Object.DestroyImmediate(graphViewer.NodeCreationRequestSearchWindowView.SearchWindow, allowDestroyingAssets: true);
                Object.DestroyImmediate(graphViewer.EdgeConnectorSearchWindowView.SearchWindow, allowDestroyingAssets: true);
                Object.DestroyImmediate(graphViewer.OptionEdgeConnectorSearchWindowView.SearchWindow, allowDestroyingAssets: true);
            }
        }


        /// <summary>
        /// The event to invoke when the dialogue system window's OnDestroy is called.
        /// </summary>
        void WindowOnDestroyEvent()
        {
            WindowChangedEvent.Unregister(m_WindowChangesEvent);

            dialogueSystemWindowAsset.IsAlreadyOpened = false;
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
                    dialogueSystemWindow.Save();
                    isHotkeyReleased = false;
                }

                // Loading
                if (evt.keyCode == hotkeyManager.LoadKey)
                {
                    dialogueSystemWindow.Load(false);
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
            if (dialogueSystemWindow.hasFocus)
            {
                dialogueSystemWindow.HasUnsavedChanges = true;
            }
        }
    }
}