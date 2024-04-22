namespace AG.DS
{
    public class OptionPortGroupItemFactory
    {
        /// <summary>
        /// Generate a new option port group item element.
        /// </summary>
        /// <param name="model">The option port group item model to set for.</param>
        /// <param name="data">The option port group item data to set for.</param>
        /// <returns>A new option port group item element.</returns>
        public static OptionPortGroupItem Generate
        (
            OptionPortGroupItemModel model,
            OptionPortGroupItemData data = null
        )
        {
            var item = OptionPortGroupItemPresenter.CreateElement(model);

            new OptionPortGroupItemObserver(item, group: model.Group).RegisterEvents();

            if (data != null)
            {
                OptionPortGroupItemSerializer.Load(item, data);
            }

            return item;
        }
    }
}