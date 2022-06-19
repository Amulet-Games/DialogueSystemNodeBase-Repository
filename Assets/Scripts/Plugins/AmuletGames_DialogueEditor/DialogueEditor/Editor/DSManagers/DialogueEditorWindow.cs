using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AG
{
    public class DialogueEditorWindow : EditorWindow
    {
        public static int ContainerID { get; private set; }                                /// The Asset Instance ID of current using containerSO.
        public static bool isRenameChangesApplied { get; private set; }

        /// Refs.
        public DialogueContainerSO containerSO;                                     /// The current using containerSO.
        public DSHeadBar headBar;
        public DSSearchWindow searchWindow;

        public static DialogueEditorWindow dsWindow;

        public DSGraphView graphView;
        public SerializeHandler serializeHandler;                                  /// Reference to Save and Load Functions.

        #region On Enable / Disable / ShowWindow.
        private void OnEnable()
        {
            CheckDSWindowRef();

            PreSetup();

            Setup();

            PostSetup();

            LoadWindow();

            void CheckDSWindowRef()
            {
                if (!dsWindow)
                {
                    dsWindow = this;
                }
            }
        }

        private void OnDisable()
        {
            Destruct();
        }

        /// Callback attribute for opening an asset in Unity (e.g the callback is fired when double clicking an asset in the Project Browser).
        /// Read More https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Callbacks.OnOpenAssetAttribute.html
        [OnOpenAsset(0)]
        public static bool ShowWindow(int instanceId, int line)
        {
            // GOAL: Opens up a editor window when double clicked a dialogue container asset.

            Object item;

            TryGetContainerSOByID();

            if (item is DialogueContainerSO)
            {
                DrawNewWindow();

                SetupWindowDetail();

                LoadPreviousData();
            }

            return false;

            void TryGetContainerSOByID()
            {
                // Find the object that is assigned with this InstanceId From Unity Asset Folder and Load it.
                item = EditorUtility.InstanceIDToObject(instanceId);
            }

            void DrawNewWindow()
            {
                dsWindow = (DialogueEditorWindow)GetWindow(typeof(DialogueEditorWindow));
            }

            void SetupWindowDetail()
            {
                ContainerID = instanceId;
                dsWindow.titleContent = new GUIContent("Dialogue Editor");
                dsWindow.containerSO = item as DialogueContainerSO;
                dsWindow.minSize = new Vector2(2000, 1080);
            }

            void LoadPreviousData()
            {
                dsWindow.LoadWindow();
            }
        }
        #endregion

        #region Setup.
        void PreSetup()
        {
            // GOAL: Construct all the nesscary module classes 

            CreateGraphView();

            CreateHeaderBar();

            CreateSearchWindow();

            CreateSerializeHandler();

            SetupEvents();

            void CreateGraphView()
            {
                graphView = new DSGraphView(this);
            }

            void CreateHeaderBar()
            {
                headBar = new DSHeadBar(this);
            }

            void CreateSearchWindow()
            {
                searchWindow = CreateInstance<DSSearchWindow>();
            }

            void CreateSerializeHandler()
            {
                serializeHandler = new SerializeHandler(graphView);
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
                    graphView.ClearEvents();
                }

                void ClearStaticEvents()
                {
                    // Serialization Events
                    DSSaveDataToContainerSOEvent.ClearEvents();
                    DSLoadDataFromContainerSOEvent.ClearEvents();
                    DSApplyChangesToDiskEvent.ClearEvents();

                    // Changed Events
                    DSGraphViewChangedEvent.ClearEvents();
                    DSLanguageChangedEvent.ClearEvents();
                    DSTitleChangedEvent.ClearEvents();
                    DSTreeEntrySelectedEvent.ClearEvents();
                    DSWindowChangedEvent.ClearEvents();
                }

                void RegisterInstanceEvents()
                {
                    graphView.RegisterEvents();
                }

                void RegisterStaticEvents()
                {
                    // Serialization Events
                    DSSaveDataToContainerSOEvent.RegisterEvent();
                    DSLoadDataFromContainerSOEvent.RegisterEvent();
                    DSApplyChangesToDiskEvent.RegisterEvent();

                    // Changed Events
                    DSLanguageChangedEvent.RegisterEvent();
                    DSTitleChangedEvent.RegisterEvent();
                    DSWindowChangedEvent.RegisterEvent();
                }

                void MultiCastEvents()
                {
                    DSWindowChangedEvent.MultiCastEvents();
                }
            }
        }

        void Setup()
        {
            SetupSupportLanguage();

            SetupDSConfigStyles();

            SetupDSMaker();

            SetupDSStrBuilder();

            SetupAssetModificationProcessor();

            void SetupSupportLanguage()
            {
                SupportLanguage.Setup();
            }

            void SetupDSConfigStyles()
            {
                DSStylesConfig.Setup();
            }

            void SetupDSMaker()
            {
                DSBuiltInFieldsMaker.Setup();
            }

            void SetupDSStrBuilder()
            {
                DSStringBuilder.Setup();
            }

            void SetupAssetModificationProcessor()
            {
                DSAssetModificationProcessor.headBar = headBar;
            }
        }

        void PostSetup()
        {
            SetupGraphView();

            SetupHeadBar();

            SetupSearchWindow();

            AddStyleSheet();

            void SetupGraphView()
            {
                graphView.PostSetup();
            }

            void SetupHeadBar()
            {
                headBar.PostSetup();
            }

            void SetupSearchWindow()
            {
                searchWindow.PostSetup(this, graphView);
            }

            void AddStyleSheet()
            {
                rootVisualElement.styleSheets.Add(DSStylesConfig.dsEditorWindowStyle);
            }
        }
        #endregion

        #region Destruct.
        void Destruct()
        {
            DestructGraphView();

            void DestructGraphView()
            {
                rootVisualElement.Remove(graphView);
            }
        }
        #endregion

        #region Callbacks.
        /// TitleChangedEvent - DSHeadBar - Title TextField.
        public static void RenameContainerFromField(string newValue)
        {
            isRenameChangesApplied = true;

            AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(ContainerID), newValue);
            DSApplyChangesToDiskEvent.Invoke();

            isRenameChangesApplied = false;
        }

        /// DSWindowChangedEvent - SELibrary =>
        /// -> LanguageChangedEvent - DSHeadBar
        /// -> GraphViewChangedEvent - DSGraphView
        /// -> TreeEntrySelectedEvent - DSSearchWindow
        /// -> FieldValueChangedEvent - GEMaker
        public static void SetHasUnsavedChangesToTrue()
        {
            dsWindow.hasUnsavedChanges = true;
        }

        /// SaveAssetsEvent - Internal
        public static void SetHasUnsavedChangesToFalse()
        {
            dsWindow.hasUnsavedChanges = false;
        }
        #endregion

        #region Overrides.
        public override void SaveChanges()
        {
            // INHERIT: Editor Window Class
            // GOAL: Overrides to include saving all the visual elements in this window.

            SaveWindow();
        }
        #endregion

        #region Save / Load Window.
        public void SaveWindow()
        {
            // GOAL: Call the Save function in graph Serialization

            if (containerSO != null)
            {
                DSSaveDataToContainerSOEvent.Invoke(containerSO);
                DSApplyChangesToDiskEvent.Invoke();
            }
        }

        public void LoadWindow()
        {
            /// When window first show up, this will only be executed within "LoadPreviousData".
            // GOAL: Load in dialogue container's data to edit window's info.

            if (containerSO != null)
            {
                DSLoadDataFromContainerSOEvent.Invoke(containerSO);
                DSApplyChangesToDiskEvent.Invoke();
            }
        }
        #endregion
    }
}