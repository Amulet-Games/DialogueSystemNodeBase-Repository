using System;
using System.Linq;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class Dropdown : VisualElement
    {
        /// <summary>
        /// Element that contains the dropdown menu header container and dropdown items container.
        /// </summary>
        public VisualElement DropdownMenu;

        /// <summary>
        /// Element that contains the dropdown items.
        /// </summary>
        public VisualElement DropdownItemsContainer;


        /// <summary>
        /// The property of the dropdown items cache.
        /// </summary>
        public DropdownItem[] Items
        {
            get
            {
                return m_items;
            }
            set
            {
                if (m_items != null)
                {
                    throw new ArgumentException("Attempted to set the dropdown items cache twice!");
                }
                else
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        DropdownItemsContainer.Add(value[i]);
                    }

                    m_items = value;

                    m_items.Last().ShowLastStyle();
                }
            }
        }


        /// <summary>
        /// The dropdown items cache.
        /// </summary>
        DropdownItem[] m_items;


        /// <summary>
        /// The property of the selected dropdown item.
        /// </summary>
        public DropdownItem SelectedItem
        {
            get
            {
                return m_selectedItem;
            }
            set
            {
                if (value == m_selectedItem)
                {
                    return;
                }

                value?.SetSelected(true);
                m_selectedItem?.SetSelected(false);
                m_selectedItem = value;

                DropdownButtonIconImage.sprite = m_selectedItem.IconImage.sprite;
                DropdownButtonTextLabel.text = m_selectedItem.TextLabel.text;

                SelectedItemChangedEvent?.Invoke();
            }
        }


        /// <summary>
        /// The selected dropdown item.
        /// </summary>
        public DropdownItem m_selectedItem;


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

                UpdateMenuPosition();
            }
        }


        /// <summary>
        /// The dropdown menu dropped state.
        /// </summary>
        bool m_dropped;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        /// <summary>
        /// The vertical offset of the dropdown menu.
        /// </summary>
        const float MENU_OFFSET_TOP = 4f;


        /// <summary>
        /// The event to invoke when the selected dropdown item has changed.
        /// </summary>
        public Action SelectedItemChangedEvent;


        /// <summary>
        /// Constructor of the dropdown element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public Dropdown(GraphViewer graphViewer)
        {
            this.graphViewer = graphViewer;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the dropdown values.
        /// </summary>
        /// <param name="data">The dropdown data to set for.</param>
        public void Save(DropdownData data)
        {
            data.selectedItemIndex = Items.IndexOf(SelectedItem);
        }


        /// <summary>
        /// Load the dropdown values.
        /// </summary>
        /// <param name="data">The dropdown data to set for.</param>
        public void Load(DropdownData data)
        {
            SelectedItem = Items[data.selectedItemIndex];
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Update the dropdown menu position.
        /// </summary>
        void UpdateMenuPosition()
        {
            // Horizontal
            {
                // Set the pivot point of the x axis.
                float targetPosX = DropdownButton.worldBound.x;

                // Remove the horizontal offset value from the graph viewer's content view container.
                targetPosX += graphViewer.contentViewContainer.worldBound.x * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetPosX /= graphViewer.scale;

                DropdownMenu.style.left = targetPosX;
            }

            // Vertical
            {
                // Set the pivot point of the y axis.
                float targetPosY = DropdownButton.worldBound.y + DropdownButton.worldBound.height;

                // Remove the vertical offset value from the graph viewer's content view container.
                targetPosY += graphViewer.contentViewContainer.worldBound.y * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetPosY /= graphViewer.scale;

                // Combine the calculated position with the offset.
                DropdownMenu.style.top = targetPosY += MENU_OFFSET_TOP;
            }
        }
    }
}