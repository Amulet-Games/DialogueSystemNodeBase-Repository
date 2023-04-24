using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadbarPresenter
    {
        public static Headbar CreateElements(DialogueEditorWindow dsWindow)
        {
            Headbar headbar;
            VisualElement buttonsContainer;

            CreateHeadbar();

            SetupContainers();

            SetupSaveButton();

            SetupLoadButton();

            SetupLanguageToolbarMenu();

            SetupGraphTitleField();

            AddElementsToContainer();

            AddElementsToHeadbar();

            AddHeadbarToWindowRoot();

            AddStyleSheet();

            return headbar;

            void CreateHeadbar()
            {
                headbar = new(dsWindow);
                headbar.AddToClassList(StyleConfig.Instance.Headbar_Main);
            }

            void SetupContainers()
            {
                buttonsContainer = new();
                buttonsContainer.AddToClassList(StyleConfig.Instance.Headbar_ButtonContainer);
            }

            void SetupSaveButton()
            {
                headbar.SaveButton = CommonButtonPresenter.CreateElements
                (
                    buttonText: StringConfig.Instance.Headbar_SaveButton_LabelText,
                    buttonUSS01: StyleConfig.Instance.Headbar_SaveButton
                );
            }

            void SetupLoadButton()
            {
                headbar.LoadButton = CommonButtonPresenter.CreateElements
                (
                    buttonText: StringConfig.Instance.Headbar_LoadButton_LabelText,
                    buttonUSS01: StyleConfig.Instance.Headbar_LoadButton
                );
            }

            void SetupLanguageToolbarMenu()
            {
                var languageManager = LanguageManager.Instance;
                headbar.LanguageToolbarMenu = DropdownPresenter.CreateElements
                (
                    dropdownText: languageManager.GetShort(type: languageManager.SelectedLanguage),
                    arrowIcon: ConfigResourcesManager.Instance.SpriteConfig.DropdownArrowIcon1Sprite
                );
            }

            void SetupGraphTitleField()
            {
                headbar.GraphTitleTextFieldModel.TextField = GraphTitleTextFieldPresenter.CreateElements
                (
                    dsData: dsWindow.DsData,
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

            void AddHeadbarToWindowRoot()
            {
                dsWindow.rootVisualElement.Add(headbar);
            }

            void AddStyleSheet()
            {
                headbar.styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSHeadbarStyle);
            }
        }
    }
}