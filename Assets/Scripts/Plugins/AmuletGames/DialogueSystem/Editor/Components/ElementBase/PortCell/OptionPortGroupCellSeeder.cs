namespace AG.DS
{
    public class OptionPortGroupCellSeeder
    {
        /// <summary>
        /// Generate a new option port group cell.
        /// </summary>
        /// <param name="node">The node base element to set for.</param>
        /// <param name="groupView">The option port group view to set for.</param>
        /// <param name="model">The option port group cell model to set for.</param>
        /// <returns>A new option port group cell.</returns>
        public OptionPortGroupCell Generate
        (
            NodeBase node,
            OptionPortGroupView groupView,
            OptionPortGroupCellModel model = null
        )
        {
            var cell = OptionPortGroupCellPresenter.CreateElement
            (
                connectorWindow: node.GraphViewer.NodeCreateConnectorWindow,
                direction: groupView.Direction
            );

            new OptionPortGroupCellObserver(cell, node, groupView).RegisterEvents();

            if (model != null)
            {
                cell.Port.Load(model.OptionPortModel);
            }

            return cell;
        }
    }
}