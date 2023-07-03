using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadBarPresenter
    {
        /// <summary>
        /// Method for creating a new headBar element.
        /// </summary>
        /// <param name="graphTitle">The graph title to set for.</param>
        /// <returns>A new headBar element.</returns>
        public static HeadBar CreateElement(string graphTitle)
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
                headBar.AddToClassList(StyleConfig.HeadBar_Main);
            }

            void SetupDetail()
            {
                headBar.focusable = true;
            }

            void SetupContainers()
            {
                buttonsContainer = new();
                buttonsContainer.AddToClassList(StyleConfig.HeadBar_ButtonContainer);
            }

            void SetupSaveButton()
            {
                headBar.SaveButton = CommonButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.HeadBar_SaveButton_LabelText,
                    buttonUSS: StyleConfig.HeadBar_SaveButton
                );
            }

            void SetupLoadButton()
            {
                headBar.LoadButton = CommonButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.HeadBar_LoadButton_LabelText,
                    buttonUSS: StyleConfig.HeadBar_LoadButton
                );
            }

            void SetupLanguageToolbarMenu()
            {
                var languageManager = LanguageManager.Instance;
                headBar.LanguageToolbarMenu = ToolbarMenuPresenter.CreateElement
                (
                    labelText: languageManager.GetShort(type: languageManager.CurrentLanguage),
                    arrowIcon: ConfigResourcesManager.SpriteConfig.DropdownArrowIcon1Sprite,
                    menuUSS: StyleConfig.HeadBar_LanguageToolbarMenu_Main,
                    centerContainerUSS: StyleConfig.HeadBar_LanguageToolbarMenu_CenterContainer,
                    textLabelUSS: StyleConfig.HeadBar_LanguageToolbarMenu_TextLabel,
                    arrowImageUSS: StyleConfig.HeadBar_LanguageToolbarMenu_ArrowImage
                );
            }

            void SetupGraphTitleField()
            {
                headBar.GraphTitleTextFieldView.TextField = GraphTitleTextFieldPresenter.CreateElement
                (
                    graphTitle,
                    fieldUSS: StyleConfig.HeadBar_GraphTitleTextField
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
                headBar.Add(headBar.GraphTitleTextFieldView.TextField);
            }

            void AddStyleSheet()
            {
                headBar.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSHeadBarStyle);
            }
        }
    }
}