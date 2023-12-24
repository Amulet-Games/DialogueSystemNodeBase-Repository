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

            Image menuSelectImage;

            Label dropdownMenuHeaderLabel;

            CreateDropdown();

            CreateContainers();

            CreateDropdownButton();

            CreateDropdownButtonIconImage();

            CreateDropdownButtonTextLabel();

            CreateMenuSelectImage();

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

                dropdownMenuHeaderContainer = new();
                dropdownMenuHeaderContainer.AddToClassList(StyleConfig.Dropdown_DropdownMenu_Header_Container);

                dropdown.DropdownElementsContainer = new();
                dropdown.DropdownElementsContainer.AddToClassList(StyleConfig.Dropdown_DropdownMenu_DropdownElements_Container);
            }

            void CreateDropdownButton()
            {
                dropdown.DropdownButton = new();
                dropdown.DropdownButton.AddToClassList(StyleConfig.Dropdown_DropdownButton_Button);
            }

            void CreateDropdownButtonIconImage()
            {
                dropdown.DropdownButtonIconImage = CommonImagePresenter.CreateElement(
                    imageUSS01: StyleConfig.Dropdown_DropdownButton_Icon_Image
                );
            }

            void CreateDropdownButtonTextLabel()
            {
                dropdown.DropdownButtonTextLabel = CommonLabelPresenter.CreateElement(
                    labelText: "",
                    labelUSS: StyleConfig.Dropdown_DropdownButton_Text_Label
                );
            }

            void CreateMenuSelectImage()
            {
                menuSelectImage = CommonImagePresenter.CreateElement(
                    imageSprite: ConfigResourcesManager.SpriteConfig.MenuSelectIcon2Sprite,
                    imageUSS01: StyleConfig.Dropdown_DropdownButton_MenuSelectImage
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
                dropdown.DropdownButton.Add(menuSelectImage);

                dropdownMenuHeaderContainer.Add(dropdownMenuHeaderLabel);
                dropdown.DropdownElements = dropdownElements;

                dropdown.DropdownMenu.Add(dropdownMenuHeaderContainer);
                dropdown.DropdownMenu.Add(dropdown.DropdownElementsContainer);
            }

            void AddContainersToDropdown()
            {
                dropdown.Add(dropdown.DropdownButton);

                graphViewer.contentViewContainer.Add(dropdown.DropdownMenu);
            }

            void AddStyleSheet()
            {
                dropdown.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DropdownStyle);
                
                dropdown.DropdownMenu.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.GlobalStyle);
                dropdown.DropdownMenu.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DropdownStyle);
            }

            void HideDropdownMenuByDefault()
            {
                dropdown.Dropped = false;
            }
        }
    }
}