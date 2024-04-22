namespace AG.DS
{
    public class OptionPortGroupItemObserver
    {
        /// <summary>
        /// The targeting option port group item element.
        /// </summary>
        OptionPortGroupItem item;


        /// <summary>
        /// Reference of the option port group.
        /// </summary>
        OptionPortGroup group;


        /// <summary>
        /// Constructor of the option port group item observer class.
        /// </summary>
        /// <param name="item">The option port group item element to set for.</param>
        /// <param name="group">The option port group to set for.</param>
        public OptionPortGroupItemObserver
        (
            OptionPortGroupItem item,
            OptionPortGroup group
        )
        {
            this.item = item;
            this.group = group;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the group item element.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterPortCellEvents();

            RegisterRemoveButtonClickEvent();
        }


        /// <summary>
        /// Register events to the item's port cell element.
        /// </summary>
        void RegisterPortCellEvents()
            => new OptionPortCellObserver(portCell: item.PortCell).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the remove button.
        /// </summary>
        void RegisterRemoveButtonClickEvent()
            => new ButtonObserver(
                isAlert: true,
                button: item.RemoveButton,
                clickEvent: RemoveButtonClickEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the item's remove button is pressed.
        /// </summary>
        void RemoveButtonClickEvent()
        {
            group.Remove(item);

            // Update every item's port cell index.
            {
                var index = OptionPortGroup.FIRST_ITEM_INDEX + 1;

                for (int i = 0; i < group.Items.Count; i++)
                {
                    var cell = group.Items[i].PortCell;

                    cell.Index = index;

                    if (cell.OpponentCell != null)
                    {
                        cell.OpponentCell.Index = index;

                        cell.UpdatePortName();
                        cell.OpponentCell.UpdatePortName();
                    }

                    index++;
                }
            }
        }
    }
}