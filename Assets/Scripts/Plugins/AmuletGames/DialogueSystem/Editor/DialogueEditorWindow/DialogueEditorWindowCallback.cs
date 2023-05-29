using UnityEngine.UIElements;

namespace AG.DS
{
    public class DialogueEditorWindowCallback
    {
        /// <summary>
        /// The targeting dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        HeadBar headBar;


        /// <summary>
        /// Reference of the hotkey manager.
        /// </summary>
        HotkeyManager hotkeyManager;


        /// <summary>
        /// Reference of the project manager.
        /// </summary>
        ProjectManager projectManager;


        /// <summary>
        /// Has the user released the previously pressed hotkey?
        /// </summary>
        bool isHotkeyReleased;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue editor window callback class.
        /// </summary>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        /// <param name="headBar">The headBar element to set for.</param>
        /// <param name="projectManager">The project manager to set for.</param>
        public DialogueEditorWindowCallback
        (
            DialogueEditorWindow dsWindow,
            GraphViewer graphViewer,
            HeadBar headBar,
            ProjectManager projectManager
        )
        {
            this.dsWindow = dsWindow;
            this.graphViewer = graphViewer;
            this.headBar = headBar;
            this.projectManager = projectManager;

            hotkeyManager = HotkeyManager.Instance;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the dialogue editor window.
        /// </summary>
        public void RegisterEventsSetup()
        {
            RegisterKeyDownEvent();

            RegisterKeyUpEvent();

            RegisterGeometryChangedEvent();
        }


        /// <summary>
        /// Register events to the dialogue editor window.
        /// </summary>
        public void RegisterEventOnEnable()
        {
            RegisterGeometryChangedEventOnEnable();
        }


        /// <summary>
        /// Register KeyDownEvent to the dialogue editor window.
        /// </summary>
        void RegisterKeyDownEvent() =>
            dsWindow.rootVisualElement.RegisterCallback<KeyDownEvent>(KeyDownEvent);


        /// <summary>
        /// Register KeyUpEvent to the dialogue editor window.
        /// </summary>
        void RegisterKeyUpEvent() =>
            dsWindow.rootVisualElement.RegisterCallback<KeyUpEvent>(KeyUpEvent);


        /// <summary>
        /// Register GeometryChangedEvent to the dialogue editor window.
        /// </summary>
        void RegisterGeometryChangedEvent() =>
            dsWindow.rootVisualElement.RegisterCallback<GeometryChangedEvent>(GeometryChangedEvent);


        /// <summary>
        /// Register GeometryChangedEvent to the dialogue editor window when its OnEnable callback is triggered.
        /// </summary>
        void RegisterGeometryChangedEventOnEnable() =>
            dsWindow.rootVisualElement.RegisterCallback<GeometryChangedEvent>(GeometryChangedEventOnEnable);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the user pressed any hotkeys in the empty space inside the window.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void KeyDownEvent(KeyDownEvent evt)
        {
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
                    projectManager.Save();
                    isHotkeyReleased = false;
                }

                // Loading
                if (evt.keyCode == hotkeyManager.LoadKey)
                {
                    projectManager.Load(false);
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
        /// The event to invoke when the dialogue editor window has been created and setup.
        /// </summary>
        void GeometryChangedEvent(GeometryChangedEvent evt)
        {
            // Register events to the window's dock area
            {
                var dockArea = dsWindow.rootVisualElement.parent.ElementAt(index: 0);
                dockArea.RegisterCallback<FocusEvent>(DockAreaFocusEvent);
                dockArea.RegisterCallback<BlurEvent>(DockAreaBlurEvent);
            }

            // Reframe window
            graphViewer.ReframeGraphAll();

            // Unregister event after it has done executed once.
            dsWindow.rootVisualElement.UnregisterCallback<GeometryChangedEvent>(GeometryChangedEvent);


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
        /// The event to invoke when the dialogue editor window's position or dimension has changed
        /// <br>and its OnEnable callback is triggered. 
        /// </summary>
        /// <param name="evt"></param>
        void GeometryChangedEventOnEnable(GeometryChangedEvent evt)
        {
            // Reframe window
            graphViewer.ReframeGraphAll();

            // Unregister event after it has done executed once.
            dsWindow.rootVisualElement.UnregisterCallback<GeometryChangedEvent>(GeometryChangedEventOnEnable);
        }
    }
}