using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadbarPresenter
    {
        /// <summary>
        /// Create a new headbar element.
        /// </summary>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="dialogueSystemWindowAsset">The dialogue system window asset to set for.</param>
        /// <returns>A new headbar element.</returns>
        public static Headbar CreateElement
        (
            LanguageHandler languageHandler,
            DialogueSystemWindowAsset dialogueSystemWindowAsset
        )
        {
            Headbar headbar;
            VisualElement buttonsContainer;

            CreateHeadbar();

            SetupDetails();

            CreateContainers();

            CreateSaveButton();

            CreateLoadButton();

            CreateLanguageToolbarMenu();

            CreateGraphTitleField();

            AddElementsToContainer();

            AddElementsToHeadbar();

            AddStyleSheet();

            return headbar;

            void CreateHeadbar()
            {
                headbar = new(dialogueSystemWindowAsset);
                headbar.AddToClassList(StyleConfig.Headbar);
            }

            void SetupDetails()
            {
                headbar.focusable = true;
            }

            void CreateContainers()
            {
                buttonsContainer = new();
                buttonsContainer.AddToClassList(StyleConfig.Headbar_Button_Container);
            }

            void CreateSaveButton()
            {
                headbar.SaveButton = CommonButtonPresenter.CreateElement
                (
                    text: StringConfig.Headbar_SaveButton_LabelText,
                    USS: StyleConfig.Headbar_Save_Button
                );
            }

            void CreateLoadButton()
            {
                headbar.LoadButton = CommonButtonPresenter.CreateElement
                (
                    text: StringConfig.Headbar_LoadButton_LabelText,
                    USS: StyleConfig.Headbar_Load_Button
                );
            }

            void CreateLanguageToolbarMenu()
            {
                headbar.LanguageToolbarMenu = ToolbarMenuPresenter.CreateElement
                (
                    dropdownLabel: LanguageProvider.GetShort(type: languageHandler.CurrentLanguage),
                    dropdownIcon: ConfigResourcesManager.SpriteConfig.MenuSelectIcon1Sprite,
                    toolbarMenuUSS: StyleConfig.Headbar_LanguageToolbarMenu_Main,
                    centerContainerUSS: StyleConfig.Headbar_LanguageToolbarMenu_Center_Container,
                    dropdownLabelUSS: StyleConfig.Headbar_LanguageToolbarMenu_Dropdown_Label,
                    dropdownImageUSS: StyleConfig.Headbar_LanguageToolbarMenu_Dropdown_Image
                );
            }

            void CreateGraphTitleField()
            {
                GraphTitleTextFieldPresenter.CreateElement
                (
                    view: headbar.GraphTitleTextFieldView,
                    fieldUSS: StyleConfig.Headbar_GraphTitleText_Field
                );
            }

            void AddElementsToContainer()
            {
                buttonsContainer.Add(headbar.SaveButton);
                buttonsContainer.Add(headbar.LoadButton);
                buttonsContainer.Add(headbar.LanguageToolbarMenu);
            }

            void AddElementsToHeadbar()
            {
                headbar.Add(buttonsContainer);
                headbar.Add(headbar.GraphTitleTextFieldView.Field);
            }

            void AddStyleSheet()
            {
                headbar.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.HeadbarStyle);
            }
        }
    }
}