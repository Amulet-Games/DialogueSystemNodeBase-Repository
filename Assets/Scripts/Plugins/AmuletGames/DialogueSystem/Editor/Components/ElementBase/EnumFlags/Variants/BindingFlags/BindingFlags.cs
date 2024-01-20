using System;
using System.Linq;

namespace AG.DS
{
    public class BindingFlags : EnumFlagsFrameBase<BindingFlags.Bindings>
    {
        [Flags]
        public enum Bindings
        {
            None = 0,
            Instance = 4,
            Static = 8,
            Public = 16,
            Private = 32
        }


        /// <summary>
        /// The all type enum flags item.
        /// </summary>
        public EnumFlagsItem<Bindings> AllTypeItem;


        /// <inheritdoc/>
        public override EnumFlagsItem<Bindings>[] Items
        {
            get
            {
                return m_items;
            }
            set
            {
                if (m_items != null)
                {
                    throw new ArgumentException("Attempted to set the enum flags elements cache twice!");
                }
                else
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        EnumFlagsMenu.Add(value[i]);
                    }

                    m_items = value;

                    Items.First().ShowFirstStyle();
                    m_items.Last().ShowLastStyle();
                }
            }
        }
        

        /// <inheritdoc/>
        public override Bindings SelectedItems
        {
            get
            {
                return m_selectedItems;
            }
            set
            {
                m_selectedItems = value;

                UpdateItemsDisplay();

                SelectedItemsChangedEvent?.Invoke();
            }
        }


        /// <summary>
        /// Constructor of the binding flags element.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public BindingFlags(GraphViewer graphViewer) : base(graphViewer)
        {
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc/>
        protected override void AddFlag(Bindings value) => SelectedItems |= value;


        /// <inheritdoc/>
        protected override void RemoveFlag(Bindings value) => SelectedItems &= ~value;


        /// <summary>
        /// Update the enum flags items' display.
        /// </summary>
        void UpdateItemsDisplay()
        {
            var allFlag = m_selectedItems == AllTypeItem.Flag;
            if (allFlag)
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    Items[i].SetSelected(true);
                }
            }
            else
            {
                for (int i = 0; i < Items.Length; i++)
                {
                    Items[i].SetSelected(SelectedItems.HasFlag(Items[i].Flag));
                }

                // If the selected flag is None, automatically select the second flag element by default.
                if (m_selectedItems == 0)
                {
                    LastSelectedItem = Items[1];
                }
            }

            EnumFlagsButtonTextLabel.text = allFlag
                ? StringConfig.ConditionModifier_BindingFlags_FlagElement_All_LabelText
                : m_selectedItems.ToString();
        }
    }
}