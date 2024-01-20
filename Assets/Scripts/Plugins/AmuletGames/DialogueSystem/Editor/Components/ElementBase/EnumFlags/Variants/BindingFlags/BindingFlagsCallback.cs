namespace AG.DS
{
    public class BindingFlagsCallback
    {
        /// <summary>
        /// The callback to invoke when the binding flags is created on the graph by the user.
        /// </summary>
        /// <param name="flags">The binding flags to set for.</param>
        public static void OnCreateByUser(BindingFlags flags)
        {
            flags.SelectedItems = flags.AllTypeItem.Flag;
        }
    }
}