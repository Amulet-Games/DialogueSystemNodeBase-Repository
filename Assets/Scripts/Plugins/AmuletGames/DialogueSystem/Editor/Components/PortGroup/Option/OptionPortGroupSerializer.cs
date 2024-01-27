namespace AG.DS
{
    public class OptionPortGroupSerializer
    {
        /// <summary>
        /// Save the option port group values.
        /// </summary>
        /// <param name="group">The option port group to set for.</param>
        /// <param name="data">The option port group data to set for.</param>
        public static void Save(OptionPortGroup group, OptionPortGroupData data)
        {
            data.FirstPortCellData = OptionPortCellDataFactory.Generate(cell: group.BaseOptionPortCell);

            var itemsCount = group.GroupCells.Count;
            for (int i = 0; i < itemsCount; i++)
            {
                data.ItemsData.Add(
                    OptionPortGroupItemDataFactory.Generate(item: group.GroupCells[i])
                );
            }
        }


        /// <summary>
        /// Load the option port group values.
        /// </summary>
        /// <param name="group">The option port group to set for.</param>
        /// <param name="data">The option port group data to set for.</param>
        public static void Load(OptionPortGroup group, OptionPortGroupData data)
        {
            // base option port cell
            var baseOptionPortCell = OptionPortCellFactory.Generate
            (
                edgeConnectorSearchWindowView: group.GraphViewer.OptionEdgeConnectorSearchWindowView,
                direction: group.Direction,
                isIndexDominant: true,
                index: OptionPortGroup.FIRST_ITEM_INDEX,
                data: data.FirstPortCellData
            );

            group.BaseOptionPortCell = baseOptionPortCell;

            // items
            var itemsDataCount = data.ItemsData.Count;
            for (int i = 0; i < itemsDataCount; i++)
            {
                var cell = OptionPortGroupItemFactory.Generate
                (
                    group,
                    data: data.ItemsData[i]
                );

                group.Add(cell);
            }
        }
    }
}