using UnityEditor.UIElements;

public class DSToolbarMenusMaker
{
    /// <summary>
    /// Create a new toolbar menu.
    /// </summary>
    /// <param name="toolbarText">The text that'll show up as a label for the menu.</param>
    /// <param name="USS01">The first style for the menu to use when it appeared on the editor window.</param>
    /// <returns>A new toolbar menu that haven't fully been setup yet. Assign the menu actions separately.</returns>
    public static ToolbarMenu GetNewToolbarMenu(string toolbarText, string USS01 = "")
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
}
