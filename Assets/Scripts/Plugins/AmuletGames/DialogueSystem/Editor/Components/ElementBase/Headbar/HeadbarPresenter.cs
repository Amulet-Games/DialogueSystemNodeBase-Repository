using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadBarPresenter
    {
        /// <summary>
        /// Method for creating a new headBar element.
        /// </summary>
        /// <param name="headBarView">The headBar view class to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <returns>A new headBar element.</returns>
        public static HeadBar CreateElement
        (
            HeadBarView headBarView,
            LanguageHandler languageHandler
        )
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
                headBarView.SaveButton = CommonButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.HeadBar_SaveButton_LabelText,
                    buttonUSS: StyleConfig.HeadBar_SaveButton
                );
            }

            void SetupLoadButton()
            {
                headBarView.LoadButton = CommonButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.HeadBar_LoadButton_LabelText,
                    buttonUSS: StyleConfig.HeadBar_LoadButton
                );
            }

            void SetupLanguageToolbarMenu()
            {
                headBarView.LanguageToolbarMenu = ToolbarMenuPresenter.CreateElement
                (
                    labelText: LanguageProvider.GetShort(type: languageHandler.CurrentLanguage),
                    arrowIcon: ConfigResourcesManager.SpriteConfig.DropdownArrowIcon1Sprite,
                    menuUSS: StyleConfig.HeadBar_LanguageToolbarMenu_Main,
                    centerContainerUSS: StyleConfig.HeadBar_LanguageToolbarMenu_CenterContainer,
                    textLabelUSS: StyleConfig.HeadBar_LanguageToolbarMenu_TextLabel,
                    arrowImageUSS: StyleConfig.HeadBar_LanguageToolbarMenu_ArrowImage
                );
            }

            void SetupGraphTitleField()
            {
                GraphTitleTextFieldPresenter.CreateElement
                (
                    view: headBarView.GraphTitleTextFieldView,
                    fieldUSS: StyleConfig.HeadBar_GraphTitleTextField
                );
            }

            void AddElementsToContainer()
            {
                buttonsContainer.Add(headBarView.SaveButton);
                buttonsContainer.Add(headBarView.LoadButton);
                buttonsContainer.Add(headBarView.LanguageToolbarMenu);
            }

            void AddElementsToHeadBar()
            {
                headBar.Add(buttonsContainer);
                headBar.Add(headBarView.GraphTitleTextFieldView.Field);
            }

            void AddStyleSheet()
            {
                headBar.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSHeadBarStyle);
            }
        }
    }
}