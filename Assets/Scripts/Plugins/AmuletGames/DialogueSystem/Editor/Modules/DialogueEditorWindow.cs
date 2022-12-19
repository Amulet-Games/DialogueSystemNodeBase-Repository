using System.Collections;
using Unity.EditorCoroutines.Editor;
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class DialogueEditorWindow : EditorWindow
    {
        /// <summary>
        /// Reference of the connecting dialogue system data.
        /// </summary>
        public DialogueSystemData DsData;


        /// <summary>
        /// The asset instance id of the connecting dialogue system data.
        /// </summary>
        public int DsDataInstanceId;


        /// <summary>
        /// Reference of the graph viewer module.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// Reference of the headBar module.
        /// </summary>
        HeadBar headBar;


        /// <summary>
        /// Reference of the hotkey handler module.
        /// </summary>
        HotkeysHandler hotkeysHandler;


        /// <summary>
        /// Reference of the undo redo handler module.
        /// </summary>
        UndoRedoHandler undoRedoHandler;


        /// <summary>
        /// Is the graph viewer module in focus at the moment?
        /// </summary>
        public bool IsGraphViewerFocus;


        /// <summary>
        /// Is the headbar module in focus at the moment?
        /// </summary>
        public bool IsHeadBarFocus;


        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        static DialogueEditorWindow instance;


        /// <summary>
        /// Are we skipping the next OnEnable method call?
        /// </summary>
        static bool isSkipOnEnable;


        // ----------------------------- Overrides -----------------------------
        /// <summary>
        /// Callback attribute for opening an asset in Unity (e.g the callback is fired when double clicking an asset in the Project Browser).
        /// <para>Read More https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Callbacks.OnOpenAssetAttribute.html</para>
        /// </summary>
        /// <param name="instanceId">The instance id of the opened asset. Required paramenter for the callback attribute.</param>
        /// <param name="line">Can be ignored. Required paramenter for the callback attribute.</param>
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
                    // Print out a warning message and return the method immediately.
                    Debug.LogWarning(StringsConfig.WindowAlreadyOpenedWarningText);
                    return false;
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
        /// <br>The method is overrided to include saving all the visual elements in this window.</br>
        /// <para>Read More https://docs.unity3d.com/ScriptReference/EditorWindow.SaveChanges.html</para>
        /// </summary>
        public override void SaveChanges()
        {
            SaveWindowAction();
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// This method is called when custom graph editor becomes enabled and active.
        /// </summary>
        void OnEnable()
        {
            // OnEnable is called manually when isShowWindowSetup is true.
            if (isSkipOnEnable) return;

            PreSetup();

            Setup();

            PostSetup();

            DelaySetup();

            LoadSavedData();

            void DelaySetup()
            {
                EditorCoroutineUtility.StartCoroutine(routine: DelayedSetup(), owner: this);
            }

            void LoadSavedData()
            {
                LoadWindowAction(isForceLoadWindow: true);
            }
        }


        /// <summary>
        /// This method is called when the behaviour becomes disabled.
        /// This is also called when the object is destroyed and can be used for any cleanup code.
        /// When scripts are reloaded after compilation has finished, OnDisable will be called, 
        /// followed by an OnEnable after the script has been loaded.
        /// </summary>
        void OnDisable()
        {
            DestructGraphView();

            void DestructGraphView()
            {
                rootVisualElement.Remove(graphViewer);
            }

            InputHint.Instance.Destruct();
        }


        /// <summary>
        /// Ask the serialie handler to save all the graph elements on the custom graph editor.
        /// <para>ButtonClickedAction - HeadBar - SaveButton</para>
        /// </summary>
        public void SaveWindowAction()
        {
            if (hasUnsavedChanges)
            {
                SaveToDSDataEvent.Invoke(DsData);
                ApplyChangesToDiskEvent.Invoke();
            }
            else
            {
                Debug.LogWarning(StringsConfig.WindowAlreadySavedWarningText);
            }
        }


        /// <summary>
        /// Ask the serialie handler to load the saved graph elements and create them again on the graph.
        /// <para></para>
        /// <br>ButtonClickedAction - HeadBar - LoadButton</br>
        /// <br>OnDisable - Internal - Unity</br>
        /// </summary>
        public void LoadWindowAction(bool isForceLoadWindow)
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
                Debug.LogWarning(StringsConfig.WindowAlreadyLoadedWarningText);
            }

            void LoadWindow()
            {
                LoadFromDSDataEvent.Invoke(DsData);
                ApplyChangesToDiskEvent.Invoke();
            }
        }


        /// <summary>
        /// Action that called when the window's dock area has gained focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void DockAreaFocusAction(FocusEvent evt) => graphViewer.Focus();


        /// <summary>
        /// Action that called when the window's dock area has lost focus.
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
        void Init(DialogueSystemData selectedDsData, int instanceId)
        {
            ResetIsShowWindowSetup();

            SetupContainerRefs();

            SetupWindowDetail();

            ExecuteOnEnable();

            void ResetIsShowWindowSetup()
            {
                isSkipOnEnable = false;
            }

            void SetupContainerRefs()
            {
                DsDataInstanceId = instanceId;
                DsData = selectedDsData;
            }

            void SetupWindowDetail()
            {
                titleContent = new GUIContent(text: StringsConfig.DialogueEditorWindowLabelText);
                minSize = new Vector2(2000, 1080);
            }

            void ExecuteOnEnable()
            {
                OnEnable();
            }
        }


        // ----------------------------- Pre Setup -----------------------------
        /// <summary>
        /// Pre setup for the class. It's executed before any other module class's pre setup method.
        /// <para></para>
        /// <br>Its main responsibility is to call the other module class's pre setup method,</br>
        /// <br>and set up static events for the custom graph editor by clearing them and registering actions again.</br>
        /// </summary>
        void PreSetup()
        {
            CreateGraphViewer();

            CreateInputHint();

            CreateHeaderBar();

            CreateHotkeysHandler();

            SetupEvents();

            void CreateGraphViewer()
            {
                graphViewer = new GraphViewer(this);
            }

            void CreateInputHint()
            {
                if (InputHint.Instance != null)
                {
                    Debug.LogWarning(StringsConfig.InputHintAlreadyExistsWarningText);
                    return;
                }
                else
                {
                    new InputHint(graphViewer);
                }
            }

            void CreateHeaderBar()
            {
                headBar = new HeadBar(this);
            }

            void CreateHotkeysHandler()
            {
                hotkeysHandler = new HotkeysHandler(this);
            }

            void SetupEvents()
            {
                ClearInternalEvents();

                ClearStaticEvents();

                RegisterInternalEvents();

                RegisterStaticEvents();

                MultiCastEvents();

                void ClearInternalEvents()
                {
                    UnRegisterKeyDownEvent();

                    UnRegisterKeyUpEvent();

                    void UnRegisterKeyDownEvent()
                    {
                        rootVisualElement.UnregisterCallback<KeyDownEvent>(hotkeysHandler.HotkeysDownAction);
                    }

                    void UnRegisterKeyUpEvent()
                    {
                        rootVisualElement.UnregisterCallback<KeyUpEvent>(hotkeysHandler.HotkeysUpAction);
                    }
                }

                void ClearStaticEvents()
                {
                    // Serialization Events
                    SaveToDSDataEvent.Clear();
                    LoadFromDSDataEvent.Clear();
                    ApplyChangesToDiskEvent.Clear();
                    EdgesLoadingCompletedEvent.Clear();

                    // Changed Events
                    GraphViewChangedEvent.Clear();
                    LanguageChangedEvent.Clear();
                    GraphTitleChangedEvent.Clear();
                    TreeEntrySelectedEvent.Clear();
                    WindowChangedEvent.Clear();
                }

                void RegisterInternalEvents()
                {
                    RegisterKeyDownEvent();

                    RegisterKeyUpEvent();

                    void RegisterKeyDownEvent()
                    {
                        rootVisualElement.RegisterCallback<KeyDownEvent>(hotkeysHandler.HotkeysDownAction);
                    }

                    void RegisterKeyUpEvent()
                    {
                        rootVisualElement.RegisterCallback<KeyUpEvent>(hotkeysHandler.HotkeysUpAction);
                    }
                }

                void RegisterStaticEvents()
                {
                    // Serialization Events
                    SaveToDSDataEvent.Register(graphViewer.SerializeHandler);
                    LoadFromDSDataEvent.Register(graphViewer.SerializeHandler, headBar);
                    ApplyChangesToDiskEvent.Register(this);

                    // Changed Events
                    GraphTitleChangedEvent.Register(headBar);
                    WindowChangedEvent.Register(this);
                }

                void MultiCastEvents()
                {
                    WindowChangedEvent.MultiCast();
                }
            }
        }


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class. It's executed before any other module class's setup method.
        /// <para></para>
        /// <br>Its main responsibility is to call the other module class's setup method.</br>
        /// </summary>
        void Setup()
        {
            SetupLanguagesConfig();

            SetupStylesConfig();

            SetupAssetsConfig();

            SetupStringUtility();

            SetupNodeCreationEntriesProvider();

            void SetupLanguagesConfig()
            {
                LanguagesConfig.Setup();
            }

            void SetupStylesConfig()
            {
                StylesConfig.Setup();
            }

            void SetupAssetsConfig()
            {
                AssetsConfig.Setup();
            }

            void SetupStringUtility()
            {
                StringUtility.Setup();
            }

            void SetupNodeCreationEntriesProvider()
            {
                NodeCreationEntriesProvider.Setup();
            }
        }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Post setup for the class. It's executed before any other module class's post setup method.
        /// <para></para>
        /// <br>Its main responsibility is to call the other module class's post setup method.</br>
        /// </summary>
        void PostSetup()
        {
            SetupGraphViewer();

            SetupInputHint();

            SetupHeadBar();

            void SetupGraphViewer()
            {
                graphViewer.PostSetup();
            }

            void SetupInputHint()
            {
                InputHint.Instance.PostSetup();
            }

            void SetupHeadBar()
            {
                headBar.PostSetup();
            }
        }


        // ----------------------------- Delayed Setup -----------------------------
        /// <summary>
        /// Delay setup for the class. It'll executed after the post setup method and at the end of that frame.
        /// <para></para>
        /// <br>Its main responsibility is to executes the internal setups that were needed the 1 frame of delay.</br>
        /// </summary>
        /// <returns></returns>
        IEnumerator DelayedSetup()
        {
            yield return new WaitForEndOfFrame();

            SetupEvent();

            SetupReframeGraphView();

            void SetupEvent()
            {
                UnRegisterFocusBlurEvent();

                RegisterFocusBlurEvent();

                void UnRegisterFocusBlurEvent()
                {
                    // Get the dock area from the window's parent
                    VisualElement dockArea = rootVisualElement.parent.ElementAt(0);

                    dockArea.UnregisterCallback<FocusEvent>(DockAreaFocusAction);
                    dockArea.UnregisterCallback<BlurEvent>(DockAreaBlurAction);
                }

                void RegisterFocusBlurEvent()
                {
                    // Get the dock area from the window's parent
                    VisualElement dockArea = rootVisualElement.parent.ElementAt(0);

                    dockArea.RegisterCallback<FocusEvent>(_ => graphViewer.Focus());
                    dockArea.RegisterCallback<BlurEvent>(_ => graphViewer.Blur());
                }
                
            }

            void SetupReframeGraphView()
            {
                graphViewer.ReframeGraphAll();
            }
        }


        // ----------------------------- Set Has Unsaved Changes Services -----------------------------
        /// <summary>
        /// Force Unity to recognize the custom graph editor has unsaved changes,
        /// <br>so that it asks the user to save it each time when they're trying to close it without saving.</br>
        /// <para></para>
        /// <br>WindowChangedEvent =></br>
        /// <br>-> LanguageChangedEvent - HeadBar</br>
        /// <br>-> GraphViewChangedEvent - GraphViewer</br>
        /// <br>-> TreeEntrySelectedEvent - SearchWindow</br>
        /// <br>-> FieldValueChangedEvent - GEMaker</br>
        /// </summary>
        public void SetHasUnsavedChangesToTrue() => hasUnsavedChanges = true;


        /// <summary>
        /// Tell Unity that user has saved the graph so that it won't stop user to close the custom graph editor.
        /// <para>ApplyChangesToDiskEvent - Internal</para>
        /// </summary>
        public void SetHasUnsavedChangesToFalse() => hasUnsavedChanges = false;


        // ----------------------------- Retrieve Is Hotkey Available Services -----------------------------
        /// <summary>
        /// Returns true if the editor window and either the graph viewer or the headbar is in focus.
        /// </summary>
        /// <returns>True if the editor window and either the graph viewer or the headbar is in focus.</returns>
        public bool IsHotkeysFunctionAvailable()
        {
            // If either the graph viewer or headbar is in focus.
            if (IsGraphViewerFocus || IsHeadBarFocus)
            {
                // Hotkeys are allowed.
                return true;
            }

            return false;
        }
    }
}