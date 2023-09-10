using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ToolbarMenuPresenter
    {
        /// <summary>
        /// Create a new toolbar menu element.
        /// </summary>
        /// <param name="dropdownLabel">The dropdown label text to set for.</param>
        /// <param name="dropdownIcon">The dropdown icon to set for.</param>
        /// <param name="toolbarMenuUSS">The toolbar menu USS style to set for.</param>
        /// <param name="centerContainerUSS">The center container USS style to set for.</param>
        /// <param name="dropdownLabelUSS">The dropdown label USS style to set for.</param>
        /// <param name="dropdownImageUSS">The dropdown image USS style to set for.</param>
        /// <returns>A new toolbar menu element.</returns>
        public static ToolbarMenu CreateElement
        (
            string dropdownLabel,
            Sprite dropdownIcon,
            string toolbarMenuUSS,
            string centerContainerUSS,
            string dropdownLabelUSS,
            string dropdownImageUSS
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
                toolbarMenu.text = dropdownLabel;
                arrowImage.style.backgroundImage = dropdownIcon.texture;
            }

            void RemoveDefaultStyleClass()
            {
                toolbarMenu.ClearClassList();
                textLabel.ClearClassList();
                arrowImage.ClearClassList();
            }

            void AddStyleClass()
            {
                toolbarMenu.AddToClassList(toolbarMenuUSS);
                centerContainer.AddToClassList(centerContainerUSS);
                textLabel.AddToClassList(dropdownLabelUSS);
                arrowImage.AddToClassList(dropdownImageUSS);
            }
        }
    }
}