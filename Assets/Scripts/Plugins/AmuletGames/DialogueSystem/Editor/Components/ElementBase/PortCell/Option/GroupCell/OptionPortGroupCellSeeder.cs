namespace AG.DS
{
    public class OptionPortGroupCellSeeder
    {
        /// <summary>
        /// Generate a new option port group cell element.
        /// </summary>
        /// <param name="group">The option port group to set for.</param>
        /// <param name="data">The option port cell data to set for.</param>
        /// <returns>A new option port group cell element.</returns>
        public OptionPortGroupCell Generate
        (
            OptionPortGroup group,
            OptionPortCellData data = null
        )
        {
            var groupCell = OptionPortGroupCellPresenter.CreateElement
            (
                nodeCreateOptionConnectorWindow: group.GraphViewer.NodeCreateOptionConnectorWindow,
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