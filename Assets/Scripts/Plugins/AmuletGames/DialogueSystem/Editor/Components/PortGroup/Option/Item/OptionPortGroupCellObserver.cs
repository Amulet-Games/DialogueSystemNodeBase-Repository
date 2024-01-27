namespace AG.DS
{
    public class OptionPortGroupCellObserver
    {
        /// <summary>
        /// The targeting option port group cell element.
        /// </summary>
        OptionPortGroupCell groupCell;


        /// <summary>
        /// Reference of the option port group.
        /// </summary>
        OptionPortGroup group;


        /// <summary>
        /// Constructor of the option port group cell observer class.
        /// </summary>
        /// <param name="groupCell">The option port group cell element to set for.</param>
        /// <param name="group">The option port group to set for.</param>
        public OptionPortGroupCellObserver
        (
            OptionPortGroupCell groupCell,
            OptionPortGroup group
        )
        {
            this.groupCell = groupCell;
            this.group = group;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the group cell element.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterPortCellEvents();

            RegisterRemoveButtonClickEvent();
        }


        /// <summary>
        /// Register events to the port cell element.
        /// </summary>
        void RegisterPortCellEvents()
            => new OptionPortCellObserver(groupCell.PortCell).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the remove button.
        /// </summary>
        void RegisterRemoveButtonClickEvent()
            => new ButtonObserver(
                isAlert: true,
                button: groupCell.RemoveButton,
                clickEvent: RemoveButtonClickEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the cell's remove button is pressed.
        /// </summary>
        void RemoveButtonClickEvent()
        {
            group.Remove(groupCell);

            // Update every group cell's index.
            {
                var index = OptionPortGroup.FIRST_ITEM_INDEX + 1;

                for (int i = 0; i < group.GroupCells.Count; i++)
                {
                    var portCell = group.GroupCells[i].PortCell;

                    portCell.Index = index;

                    if (portCell.OpponentCell != null)
                    {
                        portCell.OpponentCell.Index = index;

                        portCell.UpdatePortName();
                        portCell.OpponentCell.UpdatePortName();
                    }

                    index++;
                }
            }
        }
    }
}