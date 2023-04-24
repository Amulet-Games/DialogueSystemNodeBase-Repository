using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownPresenter
    {
        /// <summary>
        /// Method for creating a new dropdown UIElement.
        /// </summary>
        /// <param name="dropdownText">The dropdown label text to set for.</param>
        /// <param name="arrowIcon">The sprite icon to set for the dropdown arrow image.</param>
        /// <param name="menuUSS01">The first USS style to set for the dropdown.</param>
        /// <returns>A new dropdown UIElement.</returns>
        public static ToolbarMenu CreateElements
        (
            string dropdownText = null,
            Sprite dropdownSprite = null,
            Sprite arrowIcon = null,
            string menuUSS01 = null
        )
        {
            ToolbarMenu toolbarMenu;
            VisualElement menuTextLabel;
            VisualElement menuArrowImage;

            CreateToolbar();

            GetChildElements();

            SetupDetails();

            RemoveDefaultStyleClass();

            AddStyleClass();

            return toolbarMenu;

            void CreateToolbar()
            {
                toolbarMenu = new();
            }

            void GetChildElements()
            {
                menuTextLabel = toolbarMenu.ElementAt(0);
                menuArrowImage = toolbarMenu.ElementAt(1);
            }

            void SetupDetails()
            {
                toolbarMenu.text = dropdownText;
                
                menuArrowImage.style.backgroundImage = arrowIcon.texture;
            }

            void RemoveDefaultStyleClass()
            {
                toolbarMenu.ClearClassList();
                menuTextLabel.ClearClassList();
                menuArrowImage.ClearClassList();
            }

            void AddStyleClass()
            {
                var styleConfig = StyleConfig.Instance;

                toolbarMenu.AddToClassList(styleConfig.Global_ToolbarMenu);
                menuTextLabel.AddToClassList(styleConfig.Global_ToolbarMenu_TextLabel);
                menuArrowImage.AddToClassList(styleConfig.Global_ToolbarMenu_ArrowImage);

                if (menuUSS01 != null)
                {
                    toolbarMenu.AddToClassList(menuUSS01);
                }
            }
        }
    }
}