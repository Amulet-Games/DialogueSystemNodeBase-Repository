namespace AG.DS
{
    public class OptionPortGroupItemFactory
    {
        /// <summary>
        /// Generate a new option port group item element.
        /// </summary>
        /// <param name="group">The option port group to set for.</param>
        /// <param name="data">The option port group item data to set for.</param>
        /// <returns>A new option port group item element.</returns>
        public static OptionPortGroupCell Generate
        (
            OptionPortGroup group,
            OptionPortGroupItemData data = null
        )
        {
            var item = OptionPortGroupCellPresenter.CreateElement
            (
                edgeConnectorSearchWindowView: group.GraphViewer.OptionEdgeConnectorSearchWindowView,
                direction: group.Direction,
                index: group.NextCellIndex
            );

            new OptionPortGroupCellObserver(item, group).RegisterEvents();

            if (data != null)
            {
                OptionPortGroupItemSerializer.Load(item, data);
            }

            return item;
        }
    }
}