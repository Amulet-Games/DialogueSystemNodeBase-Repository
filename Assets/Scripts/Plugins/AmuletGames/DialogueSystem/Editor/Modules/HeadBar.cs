using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadBar : Toolbar
    {
        /// <summary>
        /// Reference of the dialogue system editor window module.
        /// </summary>
        DialogueEditorWindow dsWindow;

        
        /// <summary>
        /// Reference of the toolbar menu visual element, user can change the editor window's language by its dropdown options.
        /// </summary>
        ToolbarMenu languageDropdownMenu;


        /// <summary>
        /// Reference of the graph title field, user can edit the custom graph's name by the field.
        /// </summary>
        static TextField graphTitleField;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the headBar module class.
        /// </summary>
        /// <param name="dsWindow">Dialogue system's editor window module.</param>
        public HeadBar(DialogueEditorWindow dsWindow)
        {
            this.dsWindow = dsWindow;
        }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Post setup for the class, used to call the internal maker's method to create the headBar
        /// <br>and its child visual elements on the graph.</br>
        /// <para></para>
        /// <br>It's called by dialogue editor window, and executed after the creation of input hint module class.</br>
        /// </summary>
        public void PostSetup()
        {
            SetupHeadBarElements();

            SetupFocusable();

            SetupFocusBlurEvent();

            void SetupFocusable()
            {
                focusable = true;
            }

            void SetupFocusBlurEvent()
            {
                RegisterCallback<FocusEvent>(HeadBarFocusAction);
                RegisterCallback<BlurEvent>(HeadBarBlurAction);
            }
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create a new headBar and all its child visual elements on the top area of
        /// <br>the custom graph editor.</br>
        /// </summary>
        void SetupHeadBarElements()
        {
            Box headBar_LeftSide_SubBox;

            Button saveButton;
            Button loadButton;

            SetupBoxContainers();

            SetupButton_Save();

            SetupButton_Load();

            SetupToolbarMenu_SwitchLanguage();

            SetupGraphTitleField();

            AddFieldsToBox();

            AddStyleSheet();

            AddBoxToWindowRoot();

            void SetupBoxContainers()
            {
                AddToClassList(StylesConfig.HeadBar_Main_Box);

                headBar_LeftSide_SubBox = new();
                headBar_LeftSide_SubBox.AddToClassList(StylesConfig.HeadBar_LeftSide_Box);
            }

            void SetupButton_Save()
            {
                saveButton = ButtonFactory.GetNewButton
                (
                    isAlert: false,
                    buttonText: StringsConfig.HeadBarSaveButtonLabelText,
                    buttonClickAction: SaveButtonClickAction,
                    buttonUSS01: StylesConfig.HeadBar_SaveGraph_Button
                );
            }

            void SetupButton_Load()
            {
                loadButton = ButtonFactory.GetNewButton
                (
                    isAlert: false,
                    buttonText: StringsConfig.HeadBarLoadButtonLabelText,
                    buttonClickAction: LoadButtonClickAction,
                    buttonUSS01: StylesConfig.HeadBar_LoadGraph_Button
                );
            }

            void SetupToolbarMenu_SwitchLanguage()
            {
                SetupMenu();

                RegisterMenuDropdownAction();

                ChangeChildElementsPickingMode();

                void SetupMenu()
                {
                    languageDropdownMenu = ToolbarMenuFactory.GetNewToolbarMenu
                    (
                        menuSprite: AssetsConfig.LanguageSelectionDropdownArrowIconSprite,
                        menuUSS01: StylesConfig.HeadBar_LanguageSelection_ToolbarMenu
                    );
                }

                void RegisterMenuDropdownAction()
                {
                    // Go through each language and make a button with that language.
                    // When you click on the language in the dropdown menu we tell it to run the action's method.

                    G_LanguageType[] languages = LanguagesConfig.SupportLanguageTypes;
                    for (int i = 0; i < LanguagesConfig.SupportLanguageLength; i++)
                    {
                        languageDropdownMenu.menu.AppendAction
                        (
                            // Menu item name.
                            actionName: languages[i].ToString(),

                            // Menu item action.
                            action: ToolbarMenuCallbacks.GetDropdownMenuAction
                                    (
                                        dropdownMenuAction: DropdownMenuItemClickAction,
                                        dropdownMenuActionParameter: languages[i]
                                    )
                        );
                    }
                }

                void ChangeChildElementsPickingMode()
                {
                    // Add hover style to the child's Label visual element only,
                    // the Arrow Visual Element is languageDropdown[0]
                    languageDropdownMenu[0].pickingMode = PickingMode.Position;
                }
            }

            void SetupGraphTitleField()
            {
                graphTitleField = TextFieldFactory.GetNewGraphTitleField
                (
                    dsWindow: dsWindow,
                    fieldUSS01: StylesConfig.HeadBar_GraphTitle_TextField
                );
            }

            void AddFieldsToBox()
            {
                headBar_LeftSide_SubBox.Add(saveButton);
                headBar_LeftSide_SubBox.Add(loadButton);
                headBar_LeftSide_SubBox.Add(languageDropdownMenu);

                Add(headBar_LeftSide_SubBox);
                Add(graphTitleField);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSHeadBarStyle);
                headBar_LeftSide_SubBox.styleSheets.Add(StylesConfig.DSHeadBarStyle);
            }

            void AddBoxToWindowRoot()
            {
                // Add Boxes to the window root in order for buttons to function.

                dsWindow.rootVisualElement.Add(this);
                dsWindow.rootVisualElement.Add(headBar_LeftSide_SubBox);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The action to invoke when the headBar module gained focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// <para></para>
        /// References:
        /// <br>See: <see cref="PostSetup"/></br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void HeadBarFocusAction(FocusEvent evt) => dsWindow.IsHeadBarFocus = true;


        /// <summary>
        /// The action to invoke when the headBar module lost focus.
        /// <para></para>
        /// <br>Different than "Focus Out", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// <para></para>
        /// References:
        /// <br>See: <see cref="PostSetup"/></br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void HeadBarBlurAction(BlurEvent evt) => dsWindow.IsHeadBarFocus = false;


        /// <summary>
        /// The action to invoke when the save button is clicked.
        /// <para></para>
        /// References:
        /// <br>See: <see cref="SetupHeadBarElements"/></br>
        /// </summary>
        void SaveButtonClickAction() => dsWindow.SaveWindowAction();


        /// <summary>
        /// The action to invoke when the load button is clicked.
        /// <para></para>
        /// References:
        /// <br>See: <see cref="SetupHeadBarElements"/></br>
        /// </summary>
        void LoadButtonClickAction() => dsWindow.LoadWindowAction(false);


        /// <summary>
        /// The action to invoke when a dropdown menu item is clicked.
        /// <para></para>
        /// References:
        /// <br>See: <see cref="SetupHeadBarElements"/></br>
        /// </summary>
        /// <param name="newLanguage">The new language type to change to.</param>
        public void DropdownMenuItemClickAction(G_LanguageType newLanguage) => ChangeGraphLanguage(newLanguage);


        /// <summary>
        /// The action to invoke when the graph title field's value is changed.
        /// <para></para>
        /// References:
        /// <br>See: <see cref="GraphTitleChangedEvent.Register(HeadBar)"/></br>
        /// </summary>
        /// <param name="newValue">The new value received from the graph title field.</param>
        public void GraphTitleFieldChangedAction(string newValue)
        {
            // Rename the dialogue system data asset by the new value.
            AssetDatabase.RenameAsset
            (
                pathName: AssetDatabase.GetAssetPath(instanceID: dsWindow.DsDataInstanceId),
                newName: newValue
            );
            
            // Save the changes.
            ApplyChangesToDiskEvent.Invoke();
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Update all the language fields within the editor to suit the current selected language,
        /// and update the custom graph editor's title.
        /// <para></para>
        /// References:
        /// <br>See: <see cref="LoadFromDSDataEvent.Register(SerializeHandler, HeadBar)"/></br>
        /// </summary>
        public void UpdateLanguageAndTitleAction(DialogueSystemData dsData)
        {
            // Update all the language fields.
            ChangeGraphLanguage(newLanguage: LanguagesConfig.SelectedLanguage);

            // Update the graph title.
            UpdateGraphTitleFieldNonAlert(newValue: dsData.name);
        }


        // ----------------------------- Update Language Tasks -----------------------------
        /// <summary>
        /// Update the current custom graph editor's language to the given one.
        /// </summary>
        /// <param name="newLanguage">The new language type to change to.</param>
        void ChangeGraphLanguage(G_LanguageType newLanguage)
        {
            ChangeSelectedLanguage();

            UpdateDropdownLabel();

            InvokeLanguageChangedEvent();

            void ChangeSelectedLanguage()
            {
                LanguagesConfig.SelectedLanguage = newLanguage;
                
            }

            void UpdateDropdownLabel()
            {
                languageDropdownMenu.text = LanguagesConfig.GetLanguageLabel();
            }

            void InvokeLanguageChangedEvent()
            {
                LanguageChangedEvent.Invoke();
            }
        }


        // ----------------------------- Update Graph Title Tasks -----------------------------
        /// <summary>
        /// Update the graph title field value without invoking the field's valueChangedCallback event.
        /// </summary>
        /// <param name="newValue">The new title text for the custom graph editor.</param>
        void UpdateGraphTitleFieldNonAlert(string newValue) => graphTitleField.SetValueWithoutNotify(newValue);
    }
}