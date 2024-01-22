using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class EnumFlagsFrameBase<TEnum> : VisualElement
        where TEnum : struct, Enum
    {
        /// <summary>
        /// Element that contains the enum flags items.
        /// </summary>
        public VisualElement EnumFlagsMenu;


        /// <summary>
        /// The property of the enum flags items cache.
        /// </summary>
        public abstract EnumFlagsItem<TEnum>[] Items { get; set; }


        /// <summary>
        /// The enum flags items cache.
        /// </summary>
        protected EnumFlagsItem<TEnum>[] m_items;


        /// <summary>
        /// The property of the last selected enum flags item.
        /// </summary>
        public EnumFlagsItem<TEnum> LastSelectedItem
        {
            get
            {
                return m_lastSelectedItem;
            }
            set
            {
                m_lastSelectedItem = value;

                if (SelectedItems.HasFlag(m_lastSelectedItem.Flag))
                {
                    RemoveFlag(m_lastSelectedItem.Flag);
                }
                else
                {
                    AddFlag(m_lastSelectedItem.Flag);
                }
            }
        }


        /// <summary>
        /// The last selected enum flags item.
        /// </summary>
        protected EnumFlagsItem<TEnum> m_lastSelectedItem;


        /// <summary>
        /// The property of the selected enum flags items.
        /// </summary>
        public abstract TEnum SelectedItems { get; set; }


        /// <summary>
        /// The selected enum flags items.
        /// </summary>
        protected TEnum m_selectedItems;


        /// <summary>
        /// Label for the enum flags button.
        /// </summary>
        public Label EnumFlagsButtonTextLabel;


        /// <summary>
        /// Button that shows the enum flags menu when clicked.
        /// </summary>
        public Button EnumFlagsButton;


        /// <summary>
        /// The property of the enum flags menu dropped state.
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

                EnumFlagsMenu.SetDisplay(value: m_dropped);

                UpdateMenuPosition();
            }
        }


        /// <summary>
        /// The enum flags menu dropped state.
        /// </summary>
        bool m_dropped;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        public GraphViewer GraphViewer;


        /// <summary>
        /// The vertical offset of the enum flags menu.
        /// </summary>
        const float MENU_OFFSET_TOP = 4f;


        /// <summary>
        /// The event to invoke when the selected enum flags items has changed.
        /// </summary>
        public Action<TEnum> SelectedItemsChangedEvent;


        /// <summary>
        /// Constructor of the enum flags frame base class.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public EnumFlagsFrameBase(GraphViewer graphViewer)
        {
            GraphViewer = graphViewer;
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Add the flag to the selected flags.
        /// </summary>
        /// <param name="value">The adding flag to set for.</param>
        protected abstract void AddFlag(TEnum value);


        /// <summary>
        /// Remove the flag from the selected flags.
        /// </summary>
        /// <param name="value">The removing flag to set for.</param>
        protected abstract void RemoveFlag(TEnum value);


        /// <summary>
        /// Update the enum flags menu position.
        /// </summary>
        void UpdateMenuPosition()
        {
            // Horizontal
            {
                // Set the pivot point of the x axis.
                float targetPosX = EnumFlagsButton.worldBound.x;

                // Remove the horizontal offset value from the graph viewer's content view container.
                targetPosX += GraphViewer.contentViewContainer.worldBound.x * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetPosX /= GraphViewer.scale;

                EnumFlagsMenu.style.left = targetPosX;
            }

            // Vertical
            {
                // Set the pivot point of the y axis.
                float targetPosY = EnumFlagsButton.worldBound.y + EnumFlagsButton.worldBound.height;

                // Remove the vertical offset value from the graph viewer's content view container.
                targetPosY += GraphViewer.contentViewContainer.worldBound.y * -1;

                // Divide it with the graph viewer size to keep position even after zooming in and out.
                targetPosY /= GraphViewer.scale;

                // Combine the calculated position with the offset.
                EnumFlagsMenu.style.top = targetPosY += MENU_OFFSET_TOP;
            }
        }
    }
}