using UnityEditor.Callbacks;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AG
{
    public class DialogueEditorWindow : EditorWindow
    {
        /// <summary>
        /// The static reference of the class.
        /// </summary>
        public static DialogueEditorWindow Instance;


        /// <summary>
        /// The asset instance id of the dialogueCoaninerSO that built the custom graph editor.
        /// </summary>
        public static int ContainerID { get; private set; }


        /// <summary>
        /// The boolean variable that helps identifly if the user edited the graph's title
        /// by the custom graph editor or by the project window.
        /// </summary>
        public static bool IsRenameChangesApplied { get; private set; }

        
        /// <summary>
        /// Reference of the dialogueContainerSO that built the custom graph editor.
        /// </summary>
        public DialogueContainerSO ContainerSO;


        /// <summary>
        /// Reference of the custom graph module's input hint.
        /// </summary>
        public DSInputHint InputHint;


        /// <summary>
        /// Reference of the dialogue system's graph view module.
        /// </summary>
        public DSGraphView GraphView;


        /// <summary>
        /// Reference of the dialogue system's headBar module.
        /// </summary>
        public DSHeadBar HeadBar;


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Callback attribute for opening an asset in Unity (e.g the callback is fired when double clicking an asset in the Project Browser).
        /// <para>Read More https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Callbacks.OnOpenAssetAttribute.html</para>
        /// </summary>
        /// <param name="instanceId">The instance id of the opened asset. Required paramenter for the callback attribute.</param>
        /// <param name="line">Can be ignored. Required paramenter for the callback attribute.</param>
        [OnOpenAsset(0)]
        public static bool ShowWindow(int instanceId, int line)
        {
            // Get the instance id from the opened asset and translate it an object reference.
            Object openedAssetObject = EditorUtility.InstanceIDToObject(instanceId);

            if (openedAssetObject is DialogueContainerSO)
            {
                DrawNewWindow();

                SetupWindowDetail();

                LoadPreviousData();
            }

            return false;

            void DrawNewWindow()
            {
                Instance = (DialogueEditorWindow)GetWindow(typeof(DialogueEditorWindow));
            }

            void SetupWindowDetail()
            {
                ContainerID = instanceId;
                Instance.titleContent = new GUIContent("Dialogue Editor");
                Instance.ContainerSO = openedAssetObject as DialogueContainerSO;
                Instance.minSize = new Vector2(2000, 1080);
            }

            void LoadPreviousData()
            {
                Instance.LoadWindowAction();
            }
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


        /// <summary>
        /// This method is called when custom graph editor becomes enabled and active.
        /// </summary>
        void OnEnable()
        {
            CheckDSWindowRef();

            PreSetup();

            Setup();

            PostSetup();

            LoadWindowAction();

            void CheckDSWindowRef()
            {
                Instance ??= this;
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
        /// Invoke the action when the title text field's value is changed.
        /// <para>TitleChangedEvent - DSHeadBar - TitleTextField.</para>
        /// </summary>
        /// <param name="newContainerName">The new value received from the title text field.</param>
        public static void TitleTextFieldChangedAction(string newContainerName)
        {
            IsRenameChangesApplied = true;

            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(ContainerID), newContainerName);
            DSApplyChangesToDiskEvent.Invoke();

            IsRenameChangesApplied = false;
        }


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
        public static void SetHasUnsavedChangesToTrue() => Instance.hasUnsavedChanges = true;


        /// <summary>
        /// Tell Unity that user has saved the graph so that it won't stop user to close the custom graph editor.
        /// <para>DSApplyChangesToDiskEvent - Internal</para>
        /// </summary>
        public static void SetHasUnsavedChangesToFalse() => Instance.hasUnsavedChanges = false;


        /// <summary>
        /// Ask the DSSerialieHandler to save all the graph elements on the custom graph editor.
        /// <para>ButtonClickedAction - DSHeadBar - SaveButton</para>
        /// </summary>
        public void SaveWindowAction()
        {
            if (ContainerSO != null)
            {
                DSSaveDataToContainerSOEvent.Invoke(ContainerSO);
                DSApplyChangesToDiskEvent.Invoke();
            }
        }


        /// <summary>
        /// Ask the DSSerializeHandler to load the saved graph elements and create them again on the graph.
        /// <para></para>
        /// <br>ButtonClickedAction - DSHeadBar - LoadButton</br>
        /// <br>OnDisable - Internal - Unity</br>
        /// </summary>
        public void LoadWindowAction()
        {
            if (ContainerSO != null)
            {
                DSLoadDataFromContainerSOEvent.Invoke(ContainerSO);
                DSApplyChangesToDiskEvent.Invoke();
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

            void SetupEvents()
            {
                ClearInstanceEvents();

                ClearStaticEvents();

                RegisterInstanceEvents();

                RegisterStaticEvents();

                MultiCastEvents();

                void ClearInstanceEvents()
                {
                    GraphView.ClearEvents();
                }

                void ClearStaticEvents()
                {
                    // Serialization Events
                    DSSaveDataToContainerSOEvent.ClearEvents();
                    DSLoadDataFromContainerSOEvent.Clear();
                    DSApplyChangesToDiskEvent.ClearEvents();

                    // Changed Events
                    DSGraphViewChangedEvent.ClearEvents();
                    DSLanguageChangedEvent.Clear();
                    DSTitleChangedEvent.ClearEvents();
                    DSTreeEntrySelectedEvent.ClearEvents();
                    DSWindowChangedEvent.Clear();
                }

                void RegisterInstanceEvents()
                {
                    GraphView.RegisterEvents();
                }

                void RegisterStaticEvents()
                {
                    // Serialization Events
                    DSSaveDataToContainerSOEvent.RegisterEvent();
                    DSLoadDataFromContainerSOEvent.Register();
                    DSApplyChangesToDiskEvent.RegisterEvent();

                    // Changed Events
                    DSTitleChangedEvent.RegisterEvent();
                    DSWindowChangedEvent.Register();
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
            SetupSupportLanguage();

            SetupDSStylesConfig();

            SetupDSAssetsConfig();

            SetupDSStringUtility();

            SetupAssetModificationProcessor();

            void SetupSupportLanguage()
            {
                SupportLanguage.Setup();
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

            void SetupAssetModificationProcessor()
            {
                DSAssetModificationProcessor.HeadBar = HeadBar;
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
    }
}