using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class ToolbarMenuFactory
    {
        /// <summary>
        /// Factory method for creating a new toolbar menu UIElement.
        /// </summary>
        /// <param name="toolbarText">The text that'll show up as a label for the menu.</param>
        /// <param name="menuUSS01">The first USS style to set for the menu.</param>
        /// <returns>A new toolbar menu UIElement. Assign the menu actions separately.</returns>
        public static ToolbarMenu GetNewToolbarMenu
        (
            string toolbarText,
            string menuUSS01 = ""
        )
        {
            ToolbarMenu dropdownMenu;

            SetupToolbar();

            AddMenuToStyleClass();

            return dropdownMenu;

            void SetupToolbar()
            {
                dropdownMenu = new();
                dropdownMenu.text = toolbarText;
            }

            void AddMenuToStyleClass()
            {
                dropdownMenu.AddToClassList(menuUSS01);
            }
        }


        /// <summary>
        /// Factory method for creating a new toolbar menu UIElement.
        /// </summary>
        /// <param name="menuSprite">The sprite icon that'll appear on the right side of the menu, usually it's a down arrow.</param>
        /// <param name="menuUSS01">The first USS style to set for the menu.</param>
        /// <returns>A new toolbar menu UIElement. Assign the menu actions separately.</returns>
        public static ToolbarMenu GetNewToolbarMenu
        (
            Sprite menuSprite,
            string menuUSS01 = ""
        )
        {
            ToolbarMenu dropdownMenu;

            SetupToolbar();

            AddMenuToStyleClass();

            return dropdownMenu;

            void SetupToolbar()
            {
                dropdownMenu = new();

                // Get the arrow image element and set its background image.
                dropdownMenu.ElementAt(1).style.backgroundImage = menuSprite.texture;
            }

            void AddMenuToStyleClass()
            {
                dropdownMenu.AddToClassList(menuUSS01);
            }
        }
    }
}