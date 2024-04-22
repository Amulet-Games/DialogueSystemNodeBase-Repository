namespace AG.DS
{
    public class OptionPortGroupItemSerializer
    {
        /// <summary>
        /// Save the option port group item values.
        /// </summary>
        /// <param name="item">The option port group item to set for.</param>
        /// <param name="data">The option port group item data to set for.</param>
        public static void Save
        (
            OptionPortGroupItem item,
            OptionPortGroupItemData data
        )
        {
            OptionPortCellSerializer.Save(cell: item.PortCell, data: data.OptionPortCellData);
        }


        /// <summary>
        /// Load the option port group item values.
        /// </summary>
        /// <param name="item">The option port group item to set for.</param>
        /// <param name="data">The option port group item data to set for.</param>
        public static void Load
        (
            OptionPortGroupItem item,
            OptionPortGroupItemData data
        )
        {
            OptionPortCellSerializer.Load(cell: item.PortCell, data: data.OptionPortCellData);
        }
    }
}