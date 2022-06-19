using System;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace AG
{
    public class DSHeadBar
    {
        [Header("Refs.")]
        private DialogueEditorWindow dsWindow;

        [Header("UI Element Refs.")]
        private ToolbarMenu languageDropdown;
        private TextField titleTextField;

        #region Setup.
        public DSHeadBar(DialogueEditorWindow dsWindow)
        {
            this.dsWindow = dsWindow;
        }

        public void PostSetup()
        {
            SetupVisualElements();

            void SetupVisualElements()
            {
                // GOAL: Create the headBar that located on the top area of the editor window.

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

                    headBar_LeftSideSubBox.AddToClassList(DSStylesConfig.headBar_LeftSideSubBox);
                }

                void SetupButton_Save()
                {
                    saveButton = DSBuiltInFieldsMaker.GetNewButtonNonAlert("Save", dsWindow.SaveWindow, DSStylesConfig.headBar_SaveButton);
                }

                void SetupButton_Load()
                {
                    loadButton = DSBuiltInFieldsMaker.GetNewButtonNonAlert("Load", dsWindow.LoadWindow, DSStylesConfig.headBar_LoadButton);
                }

                void SetupToolbarMenu_SwitchLanguage()
                {
                    SetupMenu();

                    RegisterMenuDropdownAction();

                    ChangeChildElementsPickingMode();

                    void SetupMenu()
                    {
                        languageDropdown = DSBuiltInFieldsMaker.GetNewToolbarMenu("", DSStylesConfig.headBar_LanguageToolbarMenu);
                    }

                    void RegisterMenuDropdownAction()
                    {
                        // Go through each language and make a button with that language.
                        // When you click on the language in the dropdown menu we tell it to run the action's method.

                        G_LanguageType[] languages = SupportLanguage.SupportLanguageTypes;
                        for (int i = 0; i < SupportLanguage.SupportLanguageLength; i++)
                        {
                            languageDropdown.menu.AppendAction(languages[i].ToString(), DSToolbarMenuUtilityEditor.DSDropdownMenuAction(SwitchLanguage, languages[i]));
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
                    titleTextField = DSBuiltInFieldsMaker.GetTitleTextField("", "", DSStylesConfig.headBar_TitleTextField);

                    // TextField will not invoke OnValueChangedCallback unless user is pressed enter.
                    titleTextField.isDelayed = true;
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
                    headBar_Toolbar.styleSheets.Add(DSStylesConfig.dsHeadBarStyle);
                    headBar_LeftSideSubBox.styleSheets.Add(DSStylesConfig.dsHeadBarStyle);
                }

                void AddBoxToWindowRoot()
                {
                    // Add Boxes to the window root in order for buttons to function.

                    dsWindow.rootVisualElement.Add(headBar_Toolbar);
                    dsWindow.rootVisualElement.Add(headBar_LeftSideSubBox);
                }
            }
        }
        #endregion

        #region Callbacks.
        /// RegisterTitleFocusOutEvent - DSTitleTextFieldUtilityEditor - Title TextField.
        public void ReloadTitleText()
        {
            UpdateTitleTextField(dsWindow.containerSO.name);
        }

        /// LoadDataFromContainerSOEvent - DS Static Events - Serialization Events
        public void LoadGraphLanguageAndTitle(DialogueContainerSO containerSO)
        {
            // Update the graph to suit current selected language.
            SwitchLanguage(SupportLanguage.selectedLanguage);

            // Update the graph title.
            UpdateTitleTextField(containerSO.name);
        }
        #endregion

        #region Dropdown Menu Action
        void SwitchLanguage(G_LanguageType switchToLanguage)
        {
            // GOAL: Change the current editor window language to desired one.

            ChangeSelectedLanguage();

            UpdateDropdownLabel();

            InvokeLanguageChangedEvent();

            void ChangeSelectedLanguage()
            {
                SupportLanguage.selectedLanguage = switchToLanguage;
            }

            void UpdateDropdownLabel()
            {
                switch (switchToLanguage)
                {
                    case G_LanguageType.English:
                        languageDropdown.text = "ENG";
                        break;
                    case G_LanguageType.German:
                        languageDropdown.text = "GER";
                        break;
                    case G_LanguageType.Danish:
                        languageDropdown.text = "DAN";
                        break;
                    case G_LanguageType.Spanish:
                        languageDropdown.text = "SPAN";
                        break;
                    case G_LanguageType.Japanese:
                        languageDropdown.text = "JPN";
                        break;
                    case G_LanguageType.Latin:
                        languageDropdown.text = "LATIN";
                        break;
                }
            }
            
            void InvokeLanguageChangedEvent()
            {
                DSLanguageChangedEvent.Invoke();
            }
        }
        #endregion

        public void UpdateTitleTextField(string newText)
        {
            titleTextField.SetValueWithoutNotify(newText);
        }
    }
}