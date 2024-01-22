using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownPresenter
    {
        /// <summary>
        /// Create a new dropdown element.
        /// </summary>
        /// <param name="dropdownMenuHeader">The dropdown menu header to set for.</param>
        /// <param name="dropdownItems">The dropdown items to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        /// <returns>A new dropdown element.</returns>
        public static Dropdown CreateElement
        (
            string dropdownMenuHeader,
            DropdownItem[] dropdownItems,
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

                dropdown.DropdownItemsContainer = new();
                dropdown.DropdownItemsContainer.AddToClassList(StyleConfig.Dropdown_DropdownMenu_DropdownItems_Container);
            }

            void CreateDropdownButton()
            {
                dropdown.DropdownButton = new();
                dropdown.DropdownButton.AddToClassList(StyleConfig.Dropdown_DropdownButton_Button);
            }

            void CreateDropdownButtonIconImage()
            {
                dropdown.DropdownButtonIconImage = ImagePresenter.CreateElement(
                    USS01: StyleConfig.Dropdown_DropdownButton_Icon_Image
                );
            }

            void CreateDropdownButtonTextLabel()
            {
                dropdown.DropdownButtonTextLabel = LabelPresenter.CreateElement(
                    text: "",
                    USS: StyleConfig.Dropdown_DropdownButton_Text_Label
                );
            }

            void CreateMenuSelectImage()
            {
                menuSelectImage = ImagePresenter.CreateElement(
                    sprite: ConfigResourcesManager.SpriteConfig.MenuSelectIcon2Sprite,
                    USS01: StyleConfig.Dropdown_DropdownButton_MenuSelectImage
                );
            }

            void CreateDropdownMenuHeaderLabel()
            {
                dropdownMenuHeaderLabel = LabelPresenter.CreateElement(
                    text: dropdownMenuHeader,
                    USS: StyleConfig.Dropdown_DropdownMenu_HeaderText_Label
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
                dropdown.Items = dropdownItems;

                dropdown.DropdownMenu.Add(dropdownMenuHeaderContainer);
                dropdown.DropdownMenu.Add(dropdown.DropdownItemsContainer);
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
        }
    }
}