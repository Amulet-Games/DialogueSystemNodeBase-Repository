namespace AG.DS
{
    public class OptionPortGroupCellFactory
    {
        /// <summary>
        /// Create a new option port group cell element.
        /// </summary>
        /// <param name="group">The option port group to set for.</param>
        /// <param name="data">The option port cell data to set for.</param>
        /// <returns>A new option port group cell element.</returns>
        public static OptionPortGroupCell Create
        (
            OptionPortGroup group,
            OptionPortCellData data = null
        )
        {
            var groupCell = OptionPortGroupCellPresenter.CreateElement
            (
                edgeConnectorSearchWindowView: group.GraphViewer.OptionEdgeConnectorSearchWindowView,
                direction: group.Direction,
                index: group.NextCellIndex
            );

            new OptionPortGroupCellObserver(groupCell, group).RegisterEvents();

            if (data != null)
            {
                new OptionPortCellSerializer().Load(groupCell.PortCell, data);
            }

            return groupCell;
        }
    }
}