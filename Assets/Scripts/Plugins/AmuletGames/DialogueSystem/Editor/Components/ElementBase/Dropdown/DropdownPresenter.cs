using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownPresenter
    {
        /// <summary>
        /// Create a new dropdown element.
        /// </summary>
        /// <param name="dropdownMenuHeader">The dropdown menu header to set for.</param>
        /// <param name="dropdownElements">The dropdown elements to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        /// <returns>A new dropdown element.</returns>
        public static Dropdown CreateElement
        (
            string dropdownMenuHeader,
            DropdownElement[] dropdownElements,
            GraphViewer graphViewer
        )
        {
            Dropdown dropdown;

            VisualElement dropdownMenuHeaderContainer;

            Image dropdownButtonSelectImage;

            Label dropdownMenuHeaderLabel;

            CreateDropdown();

            CreateContainers();

            CreateDropdownButton();

            CreateDropdownButtonIconImage();

            CreateDropdownButtonTextLabel();

            CreateDropdownArrowIconImage();

            CreateDropdownMenuHeaderLabel();

            AddElementsToContainer();

            SetupDetails();

            AddContainersToDropdown();

            AddStyleSheet();

            HideDropdownMenuByDefault();

            return dropdown;

            void CreateDropdown()
            {
                dropdown = new(graphViewer);
                dropdown.AddToClassList(StyleConfig.Dropdown);
            }

            void CreateContainers()
            {
                dropdown.DropdownMenu = new();
                dropdown.DropdownMenu.AddToClassList(StyleConfig.Dropdown_DropdownMenu);

                dropdownMenuHeaderContainer = new();
                dropdownMenuHeaderContainer.AddToClassList(StyleConfig.Dropdown_DropdownMenu_Header_Container);

                dropdown.DropdownElementsContainer = new();
                dropdown.DropdownElementsContainer.AddToClassList(StyleConfig.Dropdown_DropdownMenu_DropElements_Container);
            }

            void CreateDropdownButton()
            {
                dropdown.DropdownButton = new();
                dropdown.DropdownButton.AddToClassList(StyleConfig.Dropdown_DropdownButton_Button);
            }

            void CreateDropdownButtonIconImage()
            {
                dropdown.DropdownButtonIconImage = CommonImagePresenter.CreateElement(
                    imageUSS01: StyleConfig.Dropdown_DropdownButton_ButtonIcon_Image
                );
            }

            void CreateDropdownButtonTextLabel()
            {
                dropdown.DropdownButtonTextLabel = CommonLabelPresenter.CreateElement(
                    labelText: "",
                    labelUSS: StyleConfig.Dropdown_DropdownButton_ButtonText_Label
                );
            }

            void CreateDropdownArrowIconImage()
            {
                dropdownButtonSelectImage = CommonImagePresenter.CreateElement(
                    imageSprite: ConfigResourcesManager.SpriteConfig.DropdownArrowIcon2Sprite,
                    imageUSS01: StyleConfig.Dropdown_DropdownButton_ArrowIcon_Image
                );
            }

            void CreateDropdownMenuHeaderLabel()
            {
                dropdownMenuHeaderLabel = CommonLabelPresenter.CreateElement(
                    labelText: dropdownMenuHeader,
                    labelUSS: StyleConfig.Dropdown_DropdownMenu_HeaderText_Label
                );
            }

            void SetupDetails()
            {
                dropdown.DropdownButton.focusable = true;
            }

            void AddElementsToContainer()
            {
                dropdown.DropdownButton.Add(dropdown.DropdownButtonIconImage);
                dropdown.DropdownButton.Add(dropdown.DropdownButtonTextLabel);
                dropdown.DropdownButton.Add(dropdownButtonSelectImage);

                dropdownMenuHeaderContainer.Add(dropdownMenuHeaderLabel);
                dropdown.DropdownElements = dropdownElements;

                dropdown.DropdownMenu.Add(dropdownMenuHeaderContainer);
                dropdown.DropdownMenu.Add(dropdown.DropdownElementsContainer);
            }

            void AddContainersToDropdown()
            {
                dropdown.Add(dropdown.DropdownButton);

                dropdown.GraphViewer.contentViewContainer.Add(dropdown.DropdownMenu);
            }

            void AddStyleSheet()
            {
                dropdown.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSDropdownStyle);
                
                dropdown.DropdownMenu.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSGlobalStyle);
                dropdown.DropdownMenu.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSDropdownStyle);
            }

            void HideDropdownMenuByDefault()
            {
                dropdown.Dropped = false;
            }
        }
    }
}