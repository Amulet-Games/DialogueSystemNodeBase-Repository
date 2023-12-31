namespace AG.DS
{
    public class OptionPortGroupCellSeeder
    {
        /// <summary>
        /// Generate a new option port group cell.
        /// </summary>
        /// <param name="node">The node base element to set for.</param>
        /// <param name="groupView">The option port group view to set for.</param>
        /// <param name="data">The option port group cell data to set for.</param>
        /// <returns>A new option port group cell.</returns>
        public OptionPortGroupCell Generate
        (
            NodeBase node,
            OptionPortGroupView groupView,
            OptionPortGroupCellData data = null
        )
        {
            var cell = OptionPortGroupCellPresenter.CreateElement
            (
                connectorWindow: node.GraphViewer.NodeCreateOptionConnectorWindow,
                direction: groupView.Direction
            );

            new OptionPortGroupCellObserver(cell, node, groupView).RegisterEvents();

            if (data != null)
            {
                PortManager.Instance.Load(cell.Port, data.OptionPortData);
            }

            return cell;
        }
    }
}