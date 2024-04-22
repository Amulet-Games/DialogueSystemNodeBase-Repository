namespace AG.DS
{
    public class OptionPortGroupItemDataFactory
    {
        /// <summary>
        /// Generate a new option port group item data.
        /// </summary>
        /// <param name="item">The option port group item to set for.</param>
        /// <returns>A new option port group item data.</returns>
        public static OptionPortGroupItemData Generate(OptionPortGroupItem item)
        {
            var data = new OptionPortGroupItemData();
            OptionPortGroupItemSerializer.Save(item, data);

            return data;
        }
    }
}