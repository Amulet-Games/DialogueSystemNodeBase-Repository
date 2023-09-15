using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadBarPresenter
    {
        /// <summary>
        /// Create a new headBar element.
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

            CreateContainers();

            CreateSaveButton();

            CreateLoadButton();

            CreateLanguageToolbarMenu();

            CreateGraphTitleField();

            AddElementsToContainer();

            AddElementsToHeadBar();

            AddStyleSheet();

            return headBar;

            void CreateHeadBar()
            {
                headBar = new();
                headBar.AddToClassList(StyleConfig.HeadBar);
            }

            void SetupDetail()
            {
                headBar.focusable = true;
            }

            void CreateContainers()
            {
                buttonsContainer = new();
                buttonsContainer.AddToClassList(StyleConfig.HeadBar_Button_Container);
            }

            void CreateSaveButton()
            {
                headBarView.SaveButton = CommonButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.HeadBar_SaveButton_LabelText,
                    buttonUSS: StyleConfig.HeadBar_Save_Button
                );
            }

            void CreateLoadButton()
            {
                headBarView.LoadButton = CommonButtonPresenter.CreateElement
                (
                    buttonText: StringConfig.HeadBar_LoadButton_LabelText,
                    buttonUSS: StyleConfig.HeadBar_Load_Button
                );
            }

            void CreateLanguageToolbarMenu()
            {
                headBarView.LanguageToolbarMenu = ToolbarMenuPresenter.CreateElement
                (
                    dropdownLabel: LanguageProvider.GetShort(type: languageHandler.CurrentLanguage),
                    dropdownIcon: ConfigResourcesManager.SpriteConfig.DropdownArrowIcon1Sprite,
                    toolbarMenuUSS: StyleConfig.HeadBar_LanguageToolbarMenu_Main,
                    centerContainerUSS: StyleConfig.HeadBar_LanguageToolbarMenu_Center_Container,
                    dropdownLabelUSS: StyleConfig.HeadBar_LanguageToolbarMenu_Dropdown_Label,
                    dropdownImageUSS: StyleConfig.HeadBar_LanguageToolbarMenu_Dropdown_Image
                );
            }

            void CreateGraphTitleField()
            {
                GraphTitleTextFieldPresenter.CreateElement
                (
                    view: headBarView.GraphTitleTextFieldView,
                    fieldUSS: StyleConfig.HeadBar_GraphTitleText_Field
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