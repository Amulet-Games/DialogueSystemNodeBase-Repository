using UnityEditor.UIElements;
using UnityEngine;

public class DSToolbarMenusMaker
{
    /// <summary>
    /// Returns a new toolbar menu.
    /// </summary>
    /// <param name="toolbarText">The text that'll show up as a label for the menu.</param>
    /// <param name="USS01">The first style for the menu to use when it appeared on the editor window.</param>
    /// <returns>A new toolbar menu that haven't fully been setup yet. Assign the menu actions separately.</returns>
    public static ToolbarMenu GetNewToolbarMenu
    (
        string toolbarText,
        string USS01 = ""
    )
    {
        ToolbarMenu dropdownMenu;

        SetupToolbar();

        AddMenuToStyleClass();

        return dropdownMenu;

        void SetupToolbar()
        {
            dropdownMenu = new ToolbarMenu();
            dropdownMenu.text = toolbarText;
        }

        void AddMenuToStyleClass()
        {
            dropdownMenu.AddToClassList(USS01);
        }
    }

    /// <summary>
    /// Returns a new toolbar menu.
    /// </summary>
    /// <param name="menuSprite">The sprite icon that'll appear on the right side of the menu, usually it's a down arrow.</param>
    /// <param name="USS01">The first style for the menu to use when it appeared on the editor window.</param>
    /// <returns>A new toolbar menu that haven't fully been setup yet. Assign the menu actions separately.</returns>
    public static ToolbarMenu GetNewToolbarMenu
    (
        Sprite menuSprite,
        string USS01 = ""
    )
    {
        ToolbarMenu dropdownMenu;

        SetupToolbar();

        AddMenuToStyleClass();

        return dropdownMenu;

        void SetupToolbar()
        {
            dropdownMenu = new ToolbarMenu();

            // Get the arrow image element and set its background image.
            dropdownMenu.ElementAt(1).style.backgroundImage = menuSprite.texture;
        }

        void AddMenuToStyleClass()
        {
            dropdownMenu.AddToClassList(USS01);
        }
    }
}
