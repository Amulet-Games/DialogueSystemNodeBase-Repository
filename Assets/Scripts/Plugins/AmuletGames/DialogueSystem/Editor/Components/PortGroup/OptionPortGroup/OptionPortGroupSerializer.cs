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

            var itemsCount = group.Items.Count;
            for (int i = 0; i < itemsCount; i++)
            {
                data.ItemsData.Add(
                    OptionPortGroupItemDataFactory.Generate(item: group.Items[i])
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
            var baseOptionPortCellModel = new OptionPortCellModel
            (
                direction: group.Direction,
                isIndexDominant: true,
                index: OptionPortGroup.FIRST_ITEM_INDEX,
                edgeConnectorSearchWindowView: group.GraphViewer.OptionEdgeConnectorSearchWindowView
            );

            group.BaseOptionPortCell = OptionPortCellFactory.Generate(model: baseOptionPortCellModel, data: data.FirstPortCellData);

            // items
            var itemsDataCount = data.ItemsData.Count;
            for (int i = 0; i < itemsDataCount; i++)
            {
                var itemModel = new OptionPortGroupItemModel(group);
                var cell = OptionPortGroupItemFactory.Generate
                (
                    itemModel,
                    data: data.ItemsData[i]
                );

                group.Add(cell);
            }
        }
    }
}