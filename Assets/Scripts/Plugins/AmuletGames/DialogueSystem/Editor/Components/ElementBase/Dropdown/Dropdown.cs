using System;
using System.Linq;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class Dropdown : VisualElement
    {
        /// <summary>
        /// Element that contains the dropdown menu and dropdown elements.
        /// </summary>
        public VisualElement DropdownMenu;

        /// <summary>
        /// Element that contains the dropdown elements.
        /// </summary>
        public VisualElement DropdownElementsContainer;


        /// <summary>
        /// The property of the dropdown elements cache.
        /// </summary>
        public DropdownElement[] DropdownElements
        {
            get
            {
                return m_dropdownElements;
            }
            set
            {
                if (m_dropdownElements != null)
                {
                    throw new ArgumentException("Attempted to set the dropdown elements cache twice!");
                }
                else
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        DropdownElementsContainer.Add(value[i]);
                    }

                    m_dropdownElements = value;

                    SelectedElement = m_dropdownElements.First();

                    m_dropdownElements.Last().ShowLastElementStyle();
                }
            }
        }


        /// <summary>
        /// The dropdown elements cache.
        /// </summary>
        DropdownElement[] m_dropdownElements;


        /// <summary>
        /// The property of the selected dropdown element.
        /// </summary>
        public DropdownElement SelectedElement
        {
            get
            {
                return m_selectedElement;
            }
            set
            {
                if (value == m_selectedElement)
                {
                    return;
                }

                value?.SetSelected(true);
                m_selectedElement?.SetSelected(false);
                m_selectedElement = value;

                DropdownButtonIconImage.sprite = m_selectedElement.ElementIconImage.sprite;
                DropdownButtonTextLabel.text = m_selectedElement.ElementTextLabel.text;
            }
        }


        /// <summary>
        /// The selected dropdown element.
        /// </summary>
        public DropdownElement m_selectedElement;


        /// <summary>
        /// Image for the dropdown button icon.
        /// </summary>
        public Image DropdownButtonIconImage;


        /// <summary>
        /// Label for the dropdown button text.
        /// </summary>
        public Label DropdownButtonTextLabel;


        /// <summary>
        /// Button that shows the dropdown menu when clicked.
        /// </summary>
        public CommonButton DropdownButton;


        /// <summary>
        /// The property of the dropdown menu dropped state.
        /// </summary>
        public bool Dropped
        {
            get
            {
                return m_dropped;
            }
            set
            {
                m_dropped = value;

                DropdownMenu.SetDisplay(value: m_dropped);

                UpdatePositionMenu();
            }
        }


        /// <summary>
        /// The dropdown menu dropped state.
        /// </summary>
        bool m_dropped;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer GraphViewer;


        /// <summary>
        /// The vertical offset of the dropdown menu.
        /// </summary>
        const float MENU_OFFSET_TOP = 4f;


        /// <summary>
        /// Constructor of the dropdown element.
        /// </summary>
        public Dropdown(GraphViewer graphViewer)
        {
            GraphViewer = graphViewer;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the dropdown values.
        /// </summary>
        /// <param name="model">The dropdown model to set for.</param>
        public void Save(DropdownModel model)
        {
            model.selectedElementIndex = DropdownElements.IndexOf(SelectedElement);
        }


        /// <summary>
        /// Load the dropdown values.
        /// </summary>
        /// <param name="model">The dropdown model to set for.</param>
        public void Load(DropdownModel model)
        {
            SelectedElement = DropdownElements[model.selectedElementIndex];
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Update the dropdown menu position.
        /// </summary>
        void UpdatePositionMenu()
        {
            // Horizontal
            {
                // Set the pivot point of the x axis.
                float targetPosX = DropdownButton.worldBound.x;

                // Remove the horizontal offset value from the graph viewer's content view container.
                targetPosX += GraphViewer.contentViewContainer.worldBound.x * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetPosX /= GraphViewer.scale;

                DropdownMenu.style.left = targetPosX;
            }

            // Vertical
            {
                // Set the pivot point of the y axis.
                float targetPosY = DropdownButton.worldBound.y + DropdownButton.worldBound.height;

                // Remove the vertical offset value from the graph viewer's content view container.
                targetPosY += GraphViewer.contentViewContainer.worldBound.y * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetPosY /= GraphViewer.scale;

                // Combine the calculated position with the offset.
                DropdownMenu.style.top = targetPosY += MENU_OFFSET_TOP;
            }
        }
    }
}