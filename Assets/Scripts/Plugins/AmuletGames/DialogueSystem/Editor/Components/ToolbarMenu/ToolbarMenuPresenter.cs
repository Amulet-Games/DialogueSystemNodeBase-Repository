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
        /// <param name="menuUSS">The USS style to set for the toolbar menu.</param>
        /// <param name="centerContainerUSS">The USS style to set for the center container in the toolbar menu.</param>
        /// <param name="textLabelUSS">The USS style to set for the text label element in the toolbar menu.</param>
        /// <param name="arrowImageUSS">The USS style to set for the arrow image element in the toolbar menu.</param>
        /// <returns>A new toolbar menu element.</returns>
        public static ToolbarMenu CreateElement
        (
            string labelText,
            Sprite arrowIcon,
            string menuUSS,
            string centerContainerUSS,
            string textLabelUSS,
            string arrowImageUSS
        )
        {
            ToolbarMenu toolbarMenu;
            VisualElement centerContainer;
            VisualElement textLabel;
            VisualElement arrowImage;

            CreateToolbar();

            SetupChildElements();

            SetupDetail();

            RemoveDefaultStyleClass();

            AddStyleClass();

            return toolbarMenu;

            void CreateToolbar()
            {
                toolbarMenu = new();
            }

            void SetupChildElements()
            {
                textLabel = toolbarMenu.ElementAt(0);
                arrowImage = toolbarMenu.ElementAt(1);

                centerContainer = new();
                centerContainer.Add(textLabel);
                centerContainer.Add(arrowImage);

                toolbarMenu.Add(centerContainer);
            }

            void SetupDetail()
            {
                toolbarMenu.text = labelText;
                arrowImage.style.backgroundImage = arrowIcon.texture;
            }

            void RemoveDefaultStyleClass()
            {
                toolbarMenu.ClearClassList();
                textLabel.ClearClassList();
                arrowImage.ClearClassList();
            }

            void AddStyleClass()
            {
                toolbarMenu.AddToClassList(menuUSS);
                centerContainer.AddToClassList(centerContainerUSS);
                textLabel.AddToClassList(textLabelUSS);
                arrowImage.AddToClassList(arrowImageUSS);
            }
        }
    }
}