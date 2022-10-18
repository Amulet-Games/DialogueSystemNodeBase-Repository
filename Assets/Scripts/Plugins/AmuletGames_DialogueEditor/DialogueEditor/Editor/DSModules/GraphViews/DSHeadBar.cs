using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSHeadBar : Toolbar
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
        /// Constructor of the dialogue system's headBar module.
        /// </summary>
        /// <param name="dsWindow">Dialogue system's editor window module.</param>
        public DSHeadBar(DialogueEditorWindow dsWindow)
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
                AddToClassList(DSStylesConfig.HeadBar_MainBox);

                headBar_LeftSide_SubBox = new Box();
                headBar_LeftSide_SubBox.AddToClassList(DSStylesConfig.HeadBar_LeftSide_SubBox);
            }

            void SetupButton_Save()
            {
                saveButton = DSButtonsMaker.GetNewButtonNonAlert
                (
                    DSStringsConfig.HeadBarSaveButtonLabelText,
                    dsWindow.SaveWindowAction,
                    DSStylesConfig.HeadBar_SaveGraph_Button
                );
            }

            void SetupButton_Load()
            {
                loadButton = DSButtonsMaker.GetNewButtonNonAlert
                (
                    DSStringsConfig.HeadBarLoadButtonLabelText, 
                    () => dsWindow.LoadWindowAction(false), 
                    DSStylesConfig.HeadBar_LoadGraph_Button
                );
            }

            void SetupToolbarMenu_SwitchLanguage()
            {
                SetupMenu();

                RegisterMenuDropdownAction();

                ChangeChildElementsPickingMode();

                void SetupMenu()
                {
                    languageDropdownMenu = DSToolbarMenusMaker.GetNewToolbarMenu
                    (
                        DSAssetsConfig.LanguageSelectionDropdownArrowIconImage,
                        DSStylesConfig.HeadBar_LanguageSelection_ToolbarMenu
                    );
                }

                void RegisterMenuDropdownAction()
                {
                    // Go through each language and make a button with that language.
                    // When you click on the language in the dropdown menu we tell it to run the action's method.

                    G_LanguageType[] languages = DSLanguagesConfig.SupportLanguageTypes;
                    for (int i = 0; i < DSLanguagesConfig.SupportLanguageLength; i++)
                    {
                        languageDropdownMenu.menu.AppendAction
                        (
                            languages[i].ToString(),
                            DSToolbarMenuCallbacks.RegisterDropdownMenuAction
                            (
                                DropdownMenuItemClickedAction,
                                languages[i]
                            )
                        );
                    }
                }

                void ChangeChildElementsPickingMode()
                {
                    // Add hover style to the child's Label visual element only,
                    // the Arrow Visual Element is languageDropdown[1]
                    languageDropdownMenu[0].pickingMode = PickingMode.Position;
                }
            }

            void SetupGraphTitleField()
            {
                graphTitleField = DSTextFieldsMaker.GetNewGraphTitleField
                (
                    dsWindow,
                    DSStylesConfig.HeadBar_GraphTitle_TextField
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
                styleSheets.Add(DSStylesConfig.DSHeadBarStyle);
                headBar_LeftSide_SubBox.styleSheets.Add(DSStylesConfig.DSHeadBarStyle);
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
        /// Action that called when the head bar module has gained focus.
        /// <para></para>
        /// <br>Different than "Focus In", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void HeadBarFocusAction(FocusEvent evt) => dsWindow.IsHeadBarFocus = true;


        /// <summary>
        /// Action that called when the head bar module has lost focus.
        /// <para></para>
        /// <br>Different than "Focus Out", this version has its bubble up property set to false.</br>
        /// <br>Which means the visual elements that are in higher hierarchy won't be affected by this event.</br>
        /// </summary>
        /// <param name="evt">Registering event.</param>
        void HeadBarBlurAction(BlurEvent evt) => dsWindow.IsHeadBarFocus = false;


        /// <summary>
        /// Action that invoked when any of the dropdown menu item is clicked.
        /// DropdownMenuItemClickedAction - Internal - LanguageDropdownMenu
        /// </summary>
        /// <param name="switchToLanguage">The new language type to change to.</param>
        public void DropdownMenuItemClickedAction(G_LanguageType switchToLanguage)
            =>
            UpdateGraphLanguage(switchToLanguage);


        /// <summary>
        /// Action that invoked when the graph title field's value is changed.
        /// <para>GraphTitleChangedEvent - Internal - GraphTitleField.</para>
        /// </summary>
        /// <param name="newContainerName">The new value received from the graph title field.</param>
        public void GraphTitleFieldChangedAction(string newContainerName)
        {
            // Rename the DSContainerSO asset name with the new value.
            AssetDatabase.RenameAsset
            (
                AssetDatabase.GetAssetPath(dsWindow.DSContainerId),
                newContainerName
            );
            
            // Save the changes.
            DSApplyChangesToDiskEvent.Invoke();
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Refresh the custom graph editor language to the current selected one,
        /// and reload the custom graph editor's name.
        /// <para>LoadDataFromContainerSOEvent - DS Static Event</para>
        /// </summary>
        public void LoadLanguageAndTitleAction(DialogueContainerSO containerSO)
        {
            // Update the graph to match the current selected language.
            UpdateGraphLanguage(DSLanguagesConfig.SelectedLanguage);

            // Update the graph title.
            UpdateGraphTitleFieldNonAlert(containerSO.name);
        }


        // ----------------------------- Update Graph Title Services -----------------------------
        /// <summary>
        /// Update the graph title field value without invoking the field's valueChangedCallback event.
        /// <para>OnDidMove - DSAssetModificationProcessor</para>
        /// </summary>
        /// <param name="newTitleText">The new title text for the custom graph editor.</param>
        public static void UpdateGraphTitleFieldNonAlert(string newTitleText)
            =>
            graphTitleField.SetValueWithoutNotify(newTitleText);


        // ----------------------------- Update Language Tasks -----------------------------
        /// <summary>
        /// Change the current custom graph editor's language to the specified one.
        /// </summary>
        /// <param name="switchToLanguage">The new language type to change to.</param>
        void UpdateGraphLanguage(G_LanguageType switchToLanguage)
        {
            ChangeSelectedLanguage();

            UpdateDropdownLabel();

            InvokeLanguageChangedEvent();

            void ChangeSelectedLanguage()
            {
                DSLanguagesConfig.SelectedLanguage = switchToLanguage;
            }

            void UpdateDropdownLabel()
            {
                languageDropdownMenu.text = DSLanguagesConfig.GetLanguageLabel();
            }

            void InvokeLanguageChangedEvent()
            {
                DSLanguageChangedEvent.Invoke();
            }
        }
    }
}