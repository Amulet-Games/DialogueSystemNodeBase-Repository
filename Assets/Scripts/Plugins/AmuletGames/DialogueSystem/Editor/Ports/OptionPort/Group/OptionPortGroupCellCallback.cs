using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionPortGroupCellCallback
    {
        /// <summary>
        /// The targeting option port group cell model.
        /// </summary>
        OptionPortGroupModel.CellModel cell;


        /// <summary>
        /// The targeting option port group model.
        /// </summary>
        OptionPortGroupModel group;


        /// <summary>
        /// Reference of the graph viewer element.
        /// </summary>
        GraphViewer graphViewer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option port group cell callback class.
        /// </summary>
        /// <param name="cell">The option port group cell model to set for.</param>
        /// <param name="group">he option port group model to set for.</param>
        /// <param name="graphViewer">he graph viewer element to set for.</param>
        public OptionPortGroupCellCallback
        (
            OptionPortGroupModel.CellModel cell,
            OptionPortGroupModel group,
            GraphViewer graphViewer
        )
        {
            this.cell = cell;
            this.group = group;
            this.graphViewer = graphViewer;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the cell model.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterRemoveButtonClickEvent();
        }


        /// <summary>
        /// Register ClickEvent to the cell model's remove button.
        /// </summary>
        void RegisterRemoveButtonClickEvent()
        {
            new CommonButtonCallback(
                isAlert: true,
                button: cell.RemoveButton,
                clickEvent: RemoveButtonClickEvent).RegisterEvents();
        }


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the cell model's remove button is pressed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void RemoveButtonClickEvent(ClickEvent evt)
        {
            group.Cells.Remove(cell);

            cell.Port.Disconnect(graphViewer);

            // Update other group cell models' port label.
            for (int i = 0; i < group.Cells.Count; i++)
            {
                if (group.Cells[i].Port.connected)
                {
                    var port = group.Cells[i].Port;
                    var siblingIndex = port.GetSiblingIndex(additionNumber: 1);

                    port.UpdatePortLabel(siblingIndex);
                    port.OpponentPort.UpdatePortLabel(siblingIndex);
                }
            }
        }
    }
}