using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class Headbar : VisualElement
    {
        /// <summary>
        /// Reference of the dialogue system editor window module.
        /// </summary>
        public DialogueEditorWindow DsWindow;

        
        /// <summary>
        /// Toolbar menu for the editor window language.
        /// </summary>
        public ToolbarMenu LanguageToolbarMenu;


        /// <summary>
        /// Text model for the graph titile.
        /// </summary>
        public GraphTitleTextFieldModel GraphTitleTextFieldModel;


        /// <summary>
        /// Button that save the editor window when clicked.
        /// </summary>
        public Button SaveButton;


        /// <summary>
        /// Button that load the editor window when clicked.
        /// </summary>
        public Button LoadButton;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the headbar module class.
        /// </summary>
        /// <param name="dsWindow">The editor window module to set for.</param>
        public Headbar(DialogueEditorWindow dsWindow)
        {
            DsWindow = dsWindow;
            GraphTitleTextFieldModel = new();
        }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Post setup for the class.
        /// </summary>
        public void PostSetup()
        {
            CreateHeadbarElements();

            SetupFocusable();

            SetupFocusBlurEvent();

            void SetupFocusable()
            {
                focusable = true;
            }

            void SetupFocusBlurEvent()
            {
                RegisterCallback<FocusEvent>(HeadbarFocusEvent);
                RegisterCallback<BlurEvent>(HeadbarBlurEvent);
            }
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create a new headbar and all its child visual elements on the top area of
        /// <br>the custom graph editor.</br>
        /// </summary>
        void CreateHeadbarElements()
        {
            VisualElement buttonsContainer;

            Button saveButton;
            Button loadButton;

            SetupMainStyle();

            SetupContainers();

            SetupSaveButton();

            SetupLoadButton();

            SetupLanguageToolbarMenu();

            SetupGraphTitleField();

            AddElementsToContainer();

            AddElementsToHeadbar();

            AddHeadbarToWindowRoot();

            AddStyleSheet();

            void SetupMainStyle()
            {
                AddToClassList(StyleConfig.Instance.Headbar_Main);
            }

            void SetupContainers()
            {
                buttonsContainer = new();
                buttonsContainer.AddToClassList(StyleConfig.Instance.Headbar_ButtonContainer);
            }

            void SetupSaveButton()
            {
                saveButton = CommonButtonPresenter.CreateElements
                (
                    buttonText: StringConfig.Instance.Headbar_SaveButton_LabelText,
                    buttonUSS01: StyleConfig.Instance.Headbar_SaveButton
                );

                new CommonButtonCallback(
                    isAlert: false,
                    button: saveButton,
                    clickEvent: SaveButtonClickEvent).RegisterEvents();
            }

            void SetupLoadButton()
            {
                loadButton = CommonButtonPresenter.CreateElements
                (
                    buttonText: StringConfig.Instance.Headbar_LoadButton_LabelText,
                    buttonUSS01: StyleConfig.Instance.Headbar_LoadButton
                );

                new CommonButtonCallback(
                    isAlert: false,
                    button: loadButton,
                    clickEvent: LoadButtonClickEvent).RegisterEvents();
            }

            void SetupLanguageToolbarMenu()
            {
                SetupMenu();

                RegisterMenuDropdownAction();

                void SetupMenu()
                {
                    var languageManager = LanguageManager.Instance;
                    LanguageToolbarMenu = DropdownPresenter.CreateElements
                    (
                        dropdownText: languageManager.GetShort(type: languageManager.SelectedLanguage),
                        arrowIcon: ConfigResourcesManager.Instance.SpriteConfig.DropdownArrowIcon1Sprite
                    );
                }

                void RegisterMenuDropdownAction()
                {
                    G_LanguageType[] languages = LanguageManager.Instance.SupportLanguageTypes;

                    for (int i = 0; i < LanguageManager.Instance.SupportLanguageLength; i++)
                    {
                        LanguageToolbarMenu.menu.AppendAction
                        (
                            actionName: LanguageManager.Instance.GetFull(languages[i]),
                            action: DropdownCallback.GetDropdownMenuAction
                            (
                                dropdownMenuAction: () => DropdownMenuItemClickAction(languages[i])
                            )
                        );
                    }
                }
            }

            void SetupGraphTitleField()
            {
                GraphTitleTextFieldModel.TextField =
                    GraphTitleTextFieldPresenter.CreateElements
                    (
                        dsData: DsWindow.DsData,
                        fieldUSS01: StyleConfig.Instance.Headbar_GraphTitleTextField
                    );

                new GraphTitleTextFieldCallback(
                    model: GraphTitleTextFieldModel,
                    dsDataInstanceId: DsWindow.DsDataInstanceId).RegisterEvents();
            }

            void AddElementsToContainer()
            {
                buttonsContainer.Add(saveButton);
                buttonsContainer.Add(loadButton);
                buttonsContainer.Add(LanguageToolbarMenu);
            }

            void AddElementsToHeadbar()
            {
                Add(buttonsContainer);
                Add(GraphTitleTextFieldModel.TextField);
            }

            void AddHeadbarToWindowRoot()
            {
                DsWindow.rootVisualElement.Add(this);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSHeadbarStyle);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The event to invoke when the headbar module gained focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void HeadbarFocusEvent(FocusEvent evt) => DsWindow.IsHeadbarFocus = true;


        /// <summary>
        /// The event to invoke when the headbar module lost focus.
        /// <para></para>
        /// <br>Different than "Focus Out", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void HeadbarBlurEvent(BlurEvent evt) => DsWindow.IsHeadbarFocus = false;


        /// <summary>
        /// The event to invoke when the save button is clicked.
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void SaveButtonClickEvent(ClickEvent evt) => DsWindow.SaveWindowAction();


        /// <summary>
        /// The event to invoke when the load button is clicked.
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void LoadButtonClickEvent(ClickEvent evt) => DsWindow.LoadWindowAction(false);


        /// <summary>
        /// The action to invoke when a dropdown menu item is clicked.
        /// </summary>
        /// <param name="value">The language to change to.</param>
        public void DropdownMenuItemClickAction(G_LanguageType value) => ChangeGraphLanguage(value);


        // ----------------------------- Update Title and Language -----------------------------
        /// <summary>
        /// Update all the language fields within the editor to suit the current selected language,
        /// and update the custom graph editor's title.
        /// </summary>
        /// <param name="dsData">The dialogue system data which has connected to the custom graph editor.</param>
        public void RefreshTitleAndLanguage(DialogueSystemData dsData)
        {
            ChangeGraphLanguage(value: LanguageManager.Instance.SelectedLanguage);

            GraphTitleTextFieldModel.TextField.SetValueWithoutNotify(newValue: dsData.name);
        }


        // ----------------------------- Update Language -----------------------------
        /// <summary>
        /// Update the custom graph editor's current language to the given ones.
        /// </summary>
        /// <param name="value">The language to change to.</param>
        void ChangeGraphLanguage(G_LanguageType value)
        {
            var languageManager = LanguageManager.Instance;

            languageManager.SelectedLanguage = value;
            LanguageToolbarMenu.text = languageManager.GetShort(type: languageManager.SelectedLanguage);

            LanguageChangedEvent.Invoke();
        }
    }
}