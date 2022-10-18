using System.Collections;
using Unity.EditorCoroutines.Editor;
using UnityEditor.Callbacks;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DialogueEditorWindow : EditorWindow
    {
        /// <summary>
        /// Reference of the connecting DSCoaninerSO.
        /// </summary>
        public DialogueContainerSO DSContainerSO;


        /// <summary>
        /// The asset instance id of the connecting DSCoaninerSO.
        /// </summary>
        public int DSContainerId { get; private set; }


        /// <summary>
        /// Reference of the dialogue system's graph view module.
        /// </summary>
        public DSGraphView GraphView;


        /// <summary>
        /// Reference of the custom graph module's input hint.
        /// </summary>
        public DSInputHint InputHint;


        /// <summary>
        /// Reference of the dialogue system's head bar module.
        /// </summary>
        public DSHeadBar HeadBar;


        /// <summary>
        /// Reference of the dialogue system's GUI event module.
        /// </summary>
        public DSHotkeysHandler HotkeysHandler;


        /// <summary>
        /// Is the graph view module in focus at the moment?
        /// </summary>
        public bool IsGraphViewFocus;


        /// <summary>
        /// Is the headbar module in focus at the moment?
        /// </summary>
        public bool IsHeadBarFocus;


        /// <summary>
        /// The static reference of the dialogue editor window module.
        /// </summary>
        public static DialogueEditorWindow Instance;


        /// <summary>
        /// Is the dialogue editor window going through a first time only show window setup?
        /// </summary>
        static bool isShowWindowSetup;


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

            // If the object is an DialogueContainerSO
            if (openedAssetObject is DialogueContainerSO)
            {
                // If the static reference of dialogue editor window already exists somewhere
                if (Instance != null)
                {
                    // Print out a warning message and return the method immediately.
                    Debug.LogWarning(DSStringsConfig.WindowAlreadyOpenedWarningText);
                    return false;
                }

                // This setup only happens the first time when the editor window is shown.
                isShowWindowSetup = true;

                // Show the editor window.
                Instance = (DialogueEditorWindow)GetWindow(typeof(DialogueEditorWindow));

                // Initialize window.
                Instance.Init(openedAssetObject as DialogueContainerSO, instanceId);
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
            if (isShowWindowSetup) return;

            PreSetup();

            Setup();

            PostSetup();

            DelaySetup();

            LoadSavedData();

            void DelaySetup()
            {
                EditorCoroutineUtility.StartCoroutine(DelayedSetup(), this);
            }

            void LoadSavedData()
            {
                LoadWindowAction(true);
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
                rootVisualElement.Remove(GraphView);
            }
        }


        /// <summary>
        /// Ask the DSSerialieHandler to save all the graph elements on the custom graph editor.
        /// <para>ButtonClickedAction - DSHeadBar - SaveButton</para>
        /// </summary>
        public void SaveWindowAction()
        {
            if (hasUnsavedChanges)
            {
                DSSaveDataToContainerSOEvent.Invoke(DSContainerSO);
                DSApplyChangesToDiskEvent.Invoke();
            }
            else
            {
                Debug.LogWarning(DSStringsConfig.WindowAlreadySavedWarningText);
            }
        }


        /// <summary>
        /// Ask the DSSerializeHandler to load the saved graph elements and create them again on the graph.
        /// <para></para>
        /// <br>ButtonClickedAction - DSHeadBar - LoadButton</br>
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
                Debug.LogWarning(DSStringsConfig.WindowAlreadyLoadedWarningText);
            }

            void LoadWindow()
            {
                DSLoadDataFromContainerSOEvent.Invoke(DSContainerSO);
                DSApplyChangesToDiskEvent.Invoke();
            }
        }


        /// <summary>
        /// Action that called when the window's dock area has gained focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void DockAreaFocusAction(FocusEvent evt) => GraphView.Focus();


        /// <summary>
        /// Action that called when the window's dock area has lost focus.
        /// <para></para>
        /// <br>Different than "Focus Out", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void DockAreaBlurAction(BlurEvent evt) => GraphView.Blur();


        // ----------------------------- Init -----------------------------
        /// <summary>
        /// Init for the class. it's executed only when the window is first opened by the user,
        /// <br>meaning that it should only be executed once.</br>
        /// <para></para>
        /// <br>Its main responsibility is to setup the fields that are only needed to be setup once in their life time until the window get closed.</br>
        /// </summary>
        /// <param name="openedContainerSO">The DSContainerSO that were opened by the user in the editor's project window.</param>
        /// <param name="instanceId">The instance id of the opened asset.</param>
        void Init(DialogueContainerSO openedContainerSO, int instanceId)
        {
            ResetIsShowWindowSetup();

            SetupContainerRefs();

            SetupWindowDetail();

            ExecuteOnEnable();

            void ResetIsShowWindowSetup()
            {
                isShowWindowSetup = false;
            }

            void SetupContainerRefs()
            {
                DSContainerId = instanceId;
                DSContainerSO = openedContainerSO;
            }

            void SetupWindowDetail()
            {
                titleContent = new GUIContent(DSStringsConfig.DialogueEditorWindowLabelText);
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
            CreateGraphView();

            CreateInputHint();

            CreateHeaderBar();

            CreateHotkeysHandler();

            SetupEvents();

            void CreateGraphView()
            {
                GraphView = new DSGraphView(this);
            }

            void CreateInputHint()
            {
                InputHint = new DSInputHint(GraphView);
            }

            void CreateHeaderBar()
            {
                HeadBar = new DSHeadBar(this);
            }

            void CreateHotkeysHandler()
            {
                HotkeysHandler = new DSHotkeysHandler(this);
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
                        rootVisualElement.UnregisterCallback<KeyDownEvent>(HotkeysHandler.HotkeysDownAction);
                    }

                    void UnRegisterKeyUpEvent()
                    {
                        rootVisualElement.UnregisterCallback<KeyUpEvent>(HotkeysHandler.HotkeysUpAction);
                    }
                }

                void ClearStaticEvents()
                {
                    // Serialization Events
                    DSSaveDataToContainerSOEvent.Clear();
                    DSLoadDataFromContainerSOEvent.Clear();
                    DSApplyChangesToDiskEvent.Clear();
                    DSEdgeLoadedSetupEvent.Clear();

                    // Changed Events
                    DSGraphViewChangedEvent.Clear();
                    DSLanguageChangedEvent.Clear();
                    DSGraphTitleChangedEvent.Clear();
                    DSTreeEntrySelectedEvent.Clear();
                    DSWindowChangedEvent.Clear();
                }

                void RegisterInternalEvents()
                {
                    RegisterKeyDownEvent();

                    RegisterKeyUpEvent();

                    void RegisterKeyDownEvent()
                    {
                        rootVisualElement.RegisterCallback<KeyDownEvent>(HotkeysHandler.HotkeysDownAction);
                    }

                    void RegisterKeyUpEvent()
                    {
                        rootVisualElement.RegisterCallback<KeyUpEvent>(HotkeysHandler.HotkeysUpAction);
                    }
                }

                void RegisterStaticEvents()
                {
                    // Serialization Events
                    DSSaveDataToContainerSOEvent.Register(GraphView.SerializeHandler);
                    DSLoadDataFromContainerSOEvent.Register(GraphView.SerializeHandler, HeadBar);
                    DSApplyChangesToDiskEvent.Register(this);

                    // Changed Events
                    DSGraphTitleChangedEvent.Register(HeadBar);
                    DSWindowChangedEvent.Register(this);
                }

                void MultiCastEvents()
                {
                    DSWindowChangedEvent.MultiCast();
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
            SetupDSLanguagesConfig();

            SetupDSStylesConfig();

            SetupDSAssetsConfig();

            SetupDSStringUtility();

            SetupDSNodeCreationEntriesProvider();

            void SetupDSLanguagesConfig()
            {
                DSLanguagesConfig.Setup();
            }

            void SetupDSStylesConfig()
            {
                DSStylesConfig.Setup();
            }

            void SetupDSAssetsConfig()
            {
                DSAssetsConfig.Setup();
            }

            void SetupDSStringUtility()
            {
                DSStringUtility.Setup();
            }

            void SetupDSNodeCreationEntriesProvider()
            {
                DSNodeCreationEntriesProvider.Setup();
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
            SetupGraphView();

            SetupInputHint();

            SetupHeadBar();

            void SetupGraphView()
            {
                GraphView.PostSetup();
            }

            void SetupInputHint()
            {
                InputHint.PostSetup();
            }

            void SetupHeadBar()
            {
                HeadBar.PostSetup();
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

                    dockArea.RegisterCallback<FocusEvent>(_ => GraphView.Focus());
                    dockArea.RegisterCallback<BlurEvent>(_ => GraphView.Blur());
                }
                
            }

            void SetupReframeGraphView()
            {
                GraphView.ReframeGraphAll();
            }
        }


        // ----------------------------- Set Has Unsaved Changes Services -----------------------------
        /// <summary>
        /// Force Unity to recognize the custom graph editor has unsaved changes,
        /// <br>so that it asks the user to save it each time when they're trying to close it without saving.</br>
        /// <para></para>
        /// <br>DSWindowChangedEvent - SELibrary =></br>
        /// <br>-> LanguageChangedEvent - DSHeadBar</br>
        /// <br>-> GraphViewChangedEvent - DSGraphView</br>
        /// <br>-> TreeEntrySelectedEvent - DSSearchWindow</br>
        /// <br>-> FieldValueChangedEvent - GEMaker</br>
        /// </summary>
        public void SetHasUnsavedChangesToTrue() => hasUnsavedChanges = true;


        /// <summary>
        /// Tell Unity that user has saved the graph so that it won't stop user to close the custom graph editor.
        /// <para>DSApplyChangesToDiskEvent - Internal</para>
        /// </summary>
        public void SetHasUnsavedChangesToFalse() => hasUnsavedChanges = false;


        // ----------------------------- Retrieve Is Hotkey Available Services -----------------------------
        /// <summary>
        /// Returns true if the editor window and either the graph view or the headbar is in focus.
        /// </summary>
        /// <returns>True if the editor window and either the graph view or the headbar is in focus.</returns>
        public bool IsHotkeysFunctionAvailable()
        {
            //Debug.Log("IsGraphViewFocus = " + IsGraphViewFocus);
            //Debug.Log("IsHeadBarFocus = " + IsHeadBarFocus);

            // If either the graph view or headbar is in focus.
            if (IsGraphViewFocus || IsHeadBarFocus)
            {
                // Hotkeys are allowed.
                return true;
            }

            return false;
        }
    }
}