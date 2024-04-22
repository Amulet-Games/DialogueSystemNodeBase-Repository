namespace AG.DS
{
    public class OptionPortGroupItemModel
    {
        /// <summary>
        /// Reference of the item's group.
        /// </summary>
        public OptionPortGroup Group;


        /// <summary>
        /// Constructor of the option port group item model.
        /// </summary>
        /// <param name="group">The option port group to set for.</param>
        public OptionPortGroupItemModel(OptionPortGroup group)
        {
            Group = group;
        }
    }
}