using System;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG.DS
{
    public class DialogueEditorWindow : EditorWindow
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        static DialogueEditorWindow instance;


        /// <summary>
        /// Reference of the connecting dialogue system data.
        /// </summary>
        public DialogueSystemData DsData;


        /// <summary>
        /// The asset instance id of the connecting dialogue system data.
        /// </summary>
        public int DsDataInstanceId;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the headBar element.
        /// </summary>
        Headbar headbar;


        /// <summary>
        /// Reference of the hotkey handler module.
        /// </summary>
        HotkeysHandler hotkeysHandler;


        /// <summary>
        /// Reference of the undo redo handler module.
        /// </summary>
        UndoRedoHandler undoRedoHandler;


        /// <summary>
        /// Are we skipping the next OnEnable method call?
        /// </summary>
        static bool isSkipOnEnable;


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Callback attribute for opening an asset in Unity (e.g the callback is fired when double clicking an asset in the Project Browser).
        /// <para>Read More https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Callbacks.OnOpenAssetAttribute.html</para>
        /// </summary>
        /// <param name="instanceId">The instance id of the opened asset. Required parameter for the callback attribute.</param>
        /// <param name="line">Can be ignored. Required parameter for the callback attribute.</param>
        [OnOpenAsset(0)]
        public static bool ShowWindow(int instanceId, int line)
        {
            // Get the instance id from the opened asset and translate it to an object reference.
            Object openedAssetObject = EditorUtility.InstanceIDToObject(instanceId);

            // If the object is a dialogue system data.
            if (openedAssetObject is DialogueSystemData)
            {
                // If the static reference of dialogue editor window already exists somewhere
                if (instance != null)
                {
                    throw new Exception($"Singleton {typeof(DialogueEditorWindow)} can only be setup once.");
                }

                // This setup only happens the first time when the editor window is shown.
                isSkipOnEnable = true;

                // Show the editor window.
                instance = (DialogueEditorWindow)GetWindow(typeof(DialogueEditorWindow));

                // Initialize window.
                instance.Init(openedAssetObject as DialogueSystemData, instanceId);
            }

            return false;
        }


        /// <summary>
        /// Performs a save action on the contents of the window.
        /// <br>The method is override to include saving all the visual elements in this window.</br>
        /// <para>Read More https://docs.unity3d.com/ScriptReference/EditorWindow.SaveChanges.html</para>
        /// </summary>
        public override void SaveChanges()
        {
            SaveWindow();
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// This method is called after the <see cref="EditorWindow.GetWindow(Type)"/> method.
        /// <para></para>
        /// <br>When scripts are reloaded after compilation has finished, OnDisable will be called,</br>
        /// <br>followed by OnEnable after the script has been loaded.</br>
        /// </summary>
        void OnEnable()
        {
            if (isSkipOnEnable)
            {
                isSkipOnEnable = false;
                return;
            }

            // Reframe window
            {
                rootVisualElement.RegisterCallback<GeometryChangedEvent>(GeometryChangedEvent);

                void GeometryChangedEvent(GeometryChangedEvent evt)
                {
                    graphViewer.ReframeGraphAll();

                    // Unregister the action once the setup is done.
                    rootVisualElement.UnregisterCallback<GeometryChangedEvent>(GeometryChangedEvent);
                }
            }

            // Load window
            LoadWindow(isForceLoadWindow: true);
        }


        /// <summary>
        /// <br>This is called when the window is closed and can be used to cleanup any static references.</br>
        /// </summary>
        void OnDestroy()
        {
            // Dispose Singletons
            {
                ConfigResourcesManager.Instance.Dispose();

                LanguageManager.Instance.Dispose();

                StyleConfig.Instance.Dispose();

                StringConfig.Instance.Dispose();

                EdgeManager.Instance.Dispose();
            }

            // Dispose Static Events
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


        /// <summary>
        /// Ask the serialize handler to save all the graph elements on the custom graph editor.
        /// </summary>
        public void SaveWindow()
        {
            if (hasUnsavedChanges)
            {
                SaveToDSDataEvent.Invoke(DsData);
                ApplyChangesToDiskEvent.Invoke();
            }
            else
            {
                Debug.LogWarning(StringConfig.Instance.Editor_WindowAlreadySaved_WarningText);
            }
        }


        /// <summary>
        /// Ask the serialize handler to load the saved graph elements and create them again on the graph.
        /// </summary>
        public void LoadWindow(bool isForceLoadWindow)
        {
            if (isForceLoadWindow)
            {
                LoadWindow();
            }
            else if (hasUnsavedChanges)
            {
                LoadWindow();
            }
            else
            {
                Debug.LogWarning(StringConfig.Instance.Editor_WindowAlreadyLoaded_WarningText);
            }

            void LoadWindow()
            {
                LoadFromDSDataEvent.Invoke(DsData);
                ApplyChangesToDiskEvent.Invoke();
            }
        }


        /// <summary>
        /// The action to invoke when the window's dock area gained focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void DockAreaFocusAction(FocusEvent evt) => graphViewer.Focus();


        /// <summary>
        /// The action to invoke when the window's dock area lost focus.
        /// <para></para>
        /// <br>Different than "Focus Out", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void DockAreaBlurAction(BlurEvent evt) => graphViewer.Blur();


        // ----------------------------- Init -----------------------------
        /// <summary>
        /// Init for the class. it's executed only when the window is first opened by the user,
        /// <br>meaning that it should only be executed once.</br>
        /// <para></para>
        /// <br>Its main responsibility is to setup the fields that are only needed to be setup once in their life time until the window get closed.</br>
        /// </summary>
        /// <param name="selectedDsData">The dialogue system data that was selected by the user in the editor's project window.</param>
        /// <param name="instanceId">The instance id of the dialogue system data asset.</param>
        public void Init(DialogueSystemData selectedDsData, int instanceId)
        {
            InitDialogueSystemDataFields();

            InitWindowDetails();

            SetupWindow();

            void InitDialogueSystemDataFields()
            {
                DsDataInstanceId = instanceId;
                DsData = selectedDsData;
            }

            void InitWindowDetails()
            {
                minSize = new Vector2(
                    x: selectedDsData.WindowMinSize.x,
                    y: selectedDsData.WindowMinSize.y);

                var mainWindowPosition = EditorGUIUtility.GetMainWindowPosition();
                this.CenterOnMainWindow(
                    customWidth: mainWindowPosition.width * selectedDsData.WindowStartSizeScreenRatio.x,
                    customHeight: mainWindowPosition.height * selectedDsData.WindowStartSizeScreenRatio.y);
            }

            void SetupWindow()
            {
                PreSetup();

                Setup();

                PostSetup();

                GeometryChangedSetup();
            }
        }


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Pre setup for the class.
        /// </summary>
        void PreSetup()
        {
            // Create modules
            {
                graphViewer = new(dsWindow: this);
                hotkeysHandler = new(dsWindow: this);

                headbar = HeadbarPresenter.CreateElements(dsWindow: this);
                new HeadbarCallback(headbar, dsWindow: this).RegisterEvents();
            }

            // Register internal events
            {
                rootVisualElement.RegisterCallback<KeyDownEvent>(callback: hotkeysHandler.HotkeysDownAction);
                rootVisualElement.RegisterCallback<KeyUpEvent>(callback: hotkeysHandler.HotkeysUpAction);
            }

            // Register static events
            {
                // Serialization events
                SaveToDSDataEvent.Register(action: graphViewer.SerializeHandler.SaveEdgesAndNodes);

                LoadFromDSDataEvent.Register(action: graphViewer.SerializeHandler.LoadEdgesAndNodes);
                LoadFromDSDataEvent.Register(action: headbar.RefreshTitleAndLanguage);

                ApplyChangesToDiskEvent.Register(action: AssetDatabase.SaveAssets);
                ApplyChangesToDiskEvent.Register(action: SetHasUnsavedChangesToFalse);

                // Changed events
                GraphViewChangedEvent.Register(action: SetHasUnsavedChangesToTrue);

                TreeEntrySelectedEvent.Register(action: SetHasUnsavedChangesToTrue);

                WindowChangedEvent.Register(action: SetHasUnsavedChangesToTrue);
            }
        }


        /// <summary>
        /// Setup for the class.
        /// </summary>
        void Setup()
        {
            // Setup singletons
            {
                ConfigResourcesManager.Setup();

                LanguageManager.Setup();

                StyleConfig.Setup();

                StringConfig.Setup();

                EdgeManager.Setup();
            }

            // Setup node creation entries provider
            {
                NodeCreationEntriesProvider.Setup();
            }
        }


        /// <summary>
        /// Post setup for the class.
        /// </summary>
        void PostSetup()
        {
            // Post setup modules
            {
                graphViewer.PostSetup();
            }
        }


        /// <summary>
        /// Geometry Changed Setup for the class.
        /// </summary>
        void GeometryChangedSetup()
        {
            rootVisualElement.RegisterCallback<GeometryChangedEvent>(GeometryChangedEvent);

            void GeometryChangedEvent(GeometryChangedEvent evt)
            {
                // Register dock area events
                {
                    var dockArea = rootVisualElement.parent.ElementAt(0);
                    dockArea.RegisterCallback<FocusEvent>(DockAreaFocusAction);
                    dockArea.RegisterCallback<BlurEvent>(DockAreaBlurAction);
                }

                // Reframe window
                graphViewer.ReframeGraphAll();

                // Unregister the action once the setup is done.
                rootVisualElement.UnregisterCallback<GeometryChangedEvent>(GeometryChangedEvent);
            }
        }


        // ----------------------------- Set Has Unsaved Changes -----------------------------
        /// <summary>
        /// Force Unity to recognize the custom graph editor has unsaved changes,
        /// <br>so that it asks the user to save it each time when they're trying to close it without saving.</br>
        /// </summary>
        void SetHasUnsavedChangesToTrue() => hasUnsavedChanges = true;


        /// <summary>
        /// Tell Unity that user has saved the graph so that it won't stop user to close the custom graph editor.
        /// </summary>
        void SetHasUnsavedChangesToFalse() => hasUnsavedChanges = false;


        // ----------------------------- Retrieve Is Hotkey Function Available -----------------------------
        /// <summary>
        /// Returns true if either the graph viewer element or the headbar element is in focus.
        /// </summary>
        /// <returns>True if either the graph viewer element or the headbar element is in focus.</returns>
        public bool IsHotkeysFunctionAvailable()
        {
            // If either the graph viewer or headbar is in focus.
            if (graphViewer.IsFocus || headbar.IsFocus)
            {
                // Allows hotkey functions to pass.
                return true;
            }

            return false;
        }
    }
}