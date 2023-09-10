using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionPortGroupCellObserver
    {
        /// <summary>
        /// The targeting option port group cell element.
        /// </summary>
        OptionPortGroupCell cell;


        /// <summary>
        /// Reference of the node base element.
        /// </summary>
        NodeBase node;


        /// <summary>
        /// The targeting option port group view.
        /// </summary>
        OptionPortGroupView group;


        /// <summary>
        /// Constructor of the option port group cell observer class.
        /// </summary>
        /// <param name="cell">The option port group cell element to set for.</param>
        /// <param name="node">The node base element to set for.</param>
        /// <param name="groupView">The option port group view to set for.</param>
        public OptionPortGroupCellObserver
        (
            OptionPortGroupCell cell,
            NodeBase node,
            OptionPortGroupView groupView
        )
        {
            this.cell = cell;
            this.node = node;
            group = groupView;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the cell view.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterRemoveButtonClickEvent();
        }


        /// <summary>
        /// Register ClickEvent to the cell view's remove button.
        /// </summary>
        void RegisterRemoveButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: true,
                button: cell.RemoveButton,
                clickEvent: RemoveButtonClickEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the cell view's remove button is pressed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void RemoveButtonClickEvent(ClickEvent evt)
        {
            group.Remove(cell, node);

            cell.Port.Disconnect(node.GraphViewer);

            // Update the other cell views's port label, of which are contained in the same group.
            for (int i = 0; i < group.Cells.Count; i++)
            {
                if (group.Cells[i].Port.connected)
                {
                    var port = group.Cells[i].Port;
                    var siblingIndex = port.GetSiblingIndex();

                    port.UpdatePortLabel(siblingIndex);
                    port.OpponentPort.UpdatePortLabel(siblingIndex);
                }
            }
        }
    }
}