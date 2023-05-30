using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ToolbarMenuPresenter
    {
        /// <summary>
        /// Method for creating a new toolbar menu element.
        /// </summary>
        /// <param name="labelText">The toolbar label text to set for.</param>
        /// <param name="arrowIcon">The sprite icon to set for the toolbar arrow image.</param>
        /// <param name="menuUSS01">The first USS style to set for the toolbar.</param>
        /// <returns>A new toolbar menu element.</returns>
        public static ToolbarMenu CreateElement
        (
            string labelText = null,
            Sprite arrowIcon = null,
            string menuUSS01 = null
        )
        {
            ToolbarMenu toolbarMenu;
            VisualElement menuTextLabel;
            VisualElement menuArrowImage;

            CreateToolbar();

            GetChildElements();

            SetupDetail();

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

            void SetupDetail()
            {
                toolbarMenu.text = labelText;
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
                toolbarMenu.AddToClassList(StyleConfig.Global_ToolbarMenu);
                menuTextLabel.AddToClassList(StyleConfig.Global_ToolbarMenu_TextLabel);
                menuArrowImage.AddToClassList(StyleConfig.Global_ToolbarMenu_ArrowImage);

                if (menuUSS01 != null)
                {
                    toolbarMenu.AddToClassList(menuUSS01);
                }
            }
        }
    }
}