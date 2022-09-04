using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSHeadBar
    {
        /// <summary>
        /// Reference of the dialogue system editor window module.
        /// </summary>
        DialogueEditorWindow dsWindow;

        
        /// <summary>
        /// Reference of the toolbar menu visual element, user can change the editor window's language by its dropdown options.
        /// </summary>
        ToolbarMenu languageDropdown;


        /// <summary>
        /// Reference of the title text field, user can edit the custom graph's name by the field.
        /// </summary>
        TextField titleTextField;


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
            CreateHeadBarVisualElements();
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create a new headBar and all its child visual elements on the top area of
        /// <br>the custom graph editor.</br>
        /// </summary>
        void CreateHeadBarVisualElements()
        {
            Toolbar headBar_Toolbar;
            Box headBar_LeftSideSubBox;

            Button saveButton;
            Button loadButton;

            SetupBoxContainers();

            SetupButton_Save();

            SetupButton_Load();

            SetupToolbarMenu_SwitchLanguage();

            SetupTitleTextField();

            AddFieldsToBox();

            AddStyleSheet();

            AddBoxToWindowRoot();

            void SetupBoxContainers()
            {
                headBar_Toolbar = new Toolbar();
                headBar_LeftSideSubBox = new Box();

                headBar_Toolbar.Add(headBar_LeftSideSubBox);

                headBar_LeftSideSubBox.AddToClassList(DSStylesConfig.HeadBar_LeftSide_SubBox);
            }

            void SetupButton_Save()
            {
                saveButton = DSButtonsMaker.GetNewButtonNonAlert("Save", dsWindow.SaveWindowAction, DSStylesConfig.HeadBar_SaveGraph_Button);
            }

            void SetupButton_Load()
            {
                loadButton = DSButtonsMaker.GetNewButtonNonAlert("Load", dsWindow.LoadWindowAction, DSStylesConfig.HeadBar_LoadGraph_Button);
            }

            void SetupToolbarMenu_SwitchLanguage()
            {
                SetupMenu();

                RegisterMenuDropdownAction();

                ChangeChildElementsPickingMode();

                void SetupMenu()
                {
                    languageDropdown = DSToolbarMenusMaker.GetNewToolbarMenu(DSAssetsConfig.LanguageSelectionDropdownArrowIconImage, DSStylesConfig.HeadBar_LanguageSelection_ToolbarMenu);
                }

                void RegisterMenuDropdownAction()
                {
                    // Go through each language and make a button with that language.
                    // When you click on the language in the dropdown menu we tell it to run the action's method.

                    G_LanguageType[] languages = SupportLanguage.SupportLanguageTypes;
                    for (int i = 0; i < SupportLanguage.SupportLanguageLength; i++)
                    {
                        languageDropdown.menu.AppendAction(languages[i].ToString(), DSToolbarMenuEventRegister.DSDropdownMenuAction(SwitchLanguageAction, languages[i]));
                    }
                }

                void ChangeChildElementsPickingMode()
                {
                    // Add hover style to the child's Label visual element only,
                    // the Arrow Visual Element is languageDropdown[1]
                    languageDropdown[0].pickingMode = PickingMode.Position;
                }
            }

            void SetupTitleTextField()
            {
                titleTextField = DSTextFieldsMaker.GetTitleTextField(DSStylesConfig.HeadBar_Title_TextField);
            }

            void AddFieldsToBox()
            {
                headBar_LeftSideSubBox.Add(saveButton);
                headBar_LeftSideSubBox.Add(loadButton);
                headBar_LeftSideSubBox.Add(languageDropdown);

                headBar_Toolbar.Add(titleTextField);
            }

            void AddStyleSheet()
            {
                headBar_Toolbar.styleSheets.Add(DSStylesConfig.DSHeadBarStyle);
                headBar_LeftSideSubBox.styleSheets.Add(DSStylesConfig.DSHeadBarStyle);
            }

            void AddBoxToWindowRoot()
            {
                // Add Boxes to the window root in order for buttons to function.

                dsWindow.rootVisualElement.Add(headBar_Toolbar);
                dsWindow.rootVisualElement.Add(headBar_LeftSideSubBox);
            }
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Reload the title text field value with the current dialogueContainerSO name without invoking
        /// <br>the field's valueChangedCallback event.</br>
        /// <para>RegisterTitleFocusOutEvent - DSTitleTextFieldUtilityEditor - TitleTextField</para>
        /// </summary>
        public void ReloadGraphTitleAction()
        {
            titleTextField.SetValueWithoutNotify(dsWindow.ContainerSO.name);
        }


        /// <summary>
        /// Update the title text field value with the specified new title name without invoking
        /// <br>the field's valueChangedCallback event.</br>
        /// <para>OnDidMove - DSAssetModificationProcessor</para>
        /// </summary>
        /// <param name="newTitleText">The new title text for the custom graph editor.</param>
        public void UpdateGraphTitleAction(string newTitleText)
        {
            titleTextField.SetValueWithoutNotify(newTitleText);
        }


        /// <summary>
        /// Refresh the custom graph editor language to the current selected one,
        /// and reload the custom graph editor's name.
        /// <para>LoadDataFromContainerSOEvent - DS Static Event</para>
        /// </summary>
        public void LoadLanguageAndTitleAction(DialogueContainerSO containerSO)
        {
            // Update the graph to match the current selected language.
            SwitchLanguageAction(SupportLanguage.SelectedLanguage);

            // Update the graph title.
            UpdateGraphTitleAction(containerSO.name);
        }


        /// <summary>
        /// Change the current custom graph editor's language to the specified one.
        /// <para>DropdownMenuAction - Internal - languageDropdownMenu</para>
        /// </summary>
        /// <param name="switchToLanguage">The new language type to change to.</param>
        void SwitchLanguageAction(G_LanguageType switchToLanguage)
        {
            ChangeSelectedLanguage();

            UpdateDropdownLabel();

            InvokeLanguageChangedEvent();

            void ChangeSelectedLanguage()
            {
                SupportLanguage.SelectedLanguage = switchToLanguage;
            }

            void UpdateDropdownLabel()
            {
                languageDropdown.text = SupportLanguage.GetLanguageLabel();
            }
            
            void InvokeLanguageChangedEvent()
            {
                DSLanguageChangedEvent.Invoke();
            }
        }
    }
}