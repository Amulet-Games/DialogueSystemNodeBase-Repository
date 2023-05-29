using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadBarPresenter
    {
        /// <summary>
        /// Method for creating the headBar element.
        /// </summary>
        /// <param name="dsData">The dialogue system data to set for.</param>
        /// <returns>A new headBar element.</returns>
        public static HeadBar CreateElement(DialogueSystemData dsData)
        {
            HeadBar headBar;
            VisualElement buttonsContainer;

            CreateHeadBar();

            SetupDetail();

            SetupContainers();

            SetupSaveButton();

            SetupLoadButton();

            SetupLanguageToolbarMenu();

            SetupGraphTitleField();

            AddElementsToContainer();

            AddElementsToHeadBar();

            AddStyleSheet();

            return headBar;

            void CreateHeadBar()
            {
                headBar = new();
                headBar.AddToClassList(StyleConfig.Instance.HeadBar_Main);
            }

            void SetupDetail()
            {
                headBar.focusable = true;
            }

            void SetupContainers()
            {
                buttonsContainer = new();
                buttonsContainer.AddToClassList(StyleConfig.Instance.HeadBar_ButtonContainer);
            }

            void SetupSaveButton()
            {
                headBar.SaveButton = CommonButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.HeadBar_SaveButton_LabelText,
                    buttonUSS01: StyleConfig.Instance.HeadBar_SaveButton
                );
            }

            void SetupLoadButton()
            {
                headBar.LoadButton = CommonButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.HeadBar_LoadButton_LabelText,
                    buttonUSS01: StyleConfig.Instance.HeadBar_LoadButton
                );
            }

            void SetupLanguageToolbarMenu()
            {
                var languageManager = LanguageManager.Instance;
                headBar.LanguageToolbarMenu = ToolbarMenuPresenter.CreateElement
                (
                    labelText: languageManager.GetShort(type: languageManager.SelectedLanguage),
                    arrowIcon: ConfigResourcesManager.Instance.SpriteConfig.DropdownArrowIcon1Sprite
                );
            }

            void SetupGraphTitleField()
            {
                headBar.GraphTitleTextFieldModel.TextField = GraphTitleTextFieldPresenter.CreateElement
                (
                    dsData: dsData,
                    fieldUSS01: StyleConfig.Instance.HeadBar_GraphTitleTextField
                );
            }

            void AddElementsToContainer()
            {
                buttonsContainer.Add(headBar.SaveButton);
                buttonsContainer.Add(headBar.LoadButton);
                buttonsContainer.Add(headBar.LanguageToolbarMenu);
            }

            void AddElementsToHeadBar()
            {
                headBar.Add(buttonsContainer);
                headBar.Add(headBar.GraphTitleTextFieldModel.TextField);
            }

            void AddStyleSheet()
            {
                headBar.styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSHeadBarStyle);
            }
        }
    }
}