using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadbarPresenter
    {
        /// <summary>
        /// Method for creating the headbar element.
        /// </summary>
        /// <param name="dsData">The dialogue system data to set for.</param>
        /// <returns>A new headbar element.</returns>
        public static Headbar CreateElement(DialogueSystemData dsData)
        {
            Headbar headbar;
            VisualElement buttonsContainer;

            CreateHeadbar();

            SetupDetail();

            SetupContainers();

            SetupSaveButton();

            SetupLoadButton();

            SetupLanguageToolbarMenu();

            SetupGraphTitleField();

            AddElementsToContainer();

            AddElementsToHeadbar();

            AddStyleSheet();

            return headbar;

            void CreateHeadbar()
            {
                headbar = new();
                headbar.AddToClassList(StyleConfig.Instance.Headbar_Main);
            }

            void SetupDetail()
            {
                headbar.focusable = true;
            }

            void SetupContainers()
            {
                buttonsContainer = new();
                buttonsContainer.AddToClassList(StyleConfig.Instance.Headbar_ButtonContainer);
            }

            void SetupSaveButton()
            {
                headbar.SaveButton = CommonButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.Instance.Headbar_SaveButton_LabelText,
                    buttonUSS01: StyleConfig.Instance.Headbar_SaveButton
                );
            }

            void SetupLoadButton()
            {
                headbar.LoadButton = CommonButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.Instance.Headbar_LoadButton_LabelText,
                    buttonUSS01: StyleConfig.Instance.Headbar_LoadButton
                );
            }

            void SetupLanguageToolbarMenu()
            {
                var languageManager = LanguageManager.Instance;
                headbar.LanguageToolbarMenu = ToolbarMenuPresenter.CreateElement
                (
                    labelText: languageManager.GetShort(type: languageManager.SelectedLanguage),
                    arrowIcon: ConfigResourcesManager.Instance.SpriteConfig.DropdownArrowIcon1Sprite
                );
            }

            void SetupGraphTitleField()
            {
                headbar.GraphTitleTextFieldModel.TextField = GraphTitleTextFieldPresenter.CreateElement
                (
                    dsData: dsData,
                    fieldUSS01: StyleConfig.Instance.Headbar_GraphTitleTextField
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
                headbar.Add(headbar.GraphTitleTextFieldModel.TextField);
            }

            void AddStyleSheet()
            {
                headbar.styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSHeadbarStyle);
            }
        }
    }
}