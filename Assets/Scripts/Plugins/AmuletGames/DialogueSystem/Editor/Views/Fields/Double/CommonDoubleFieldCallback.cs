namespace AG.DS
{
    public class CommonDoubleFieldCallback
    {
        /// <summary>
        /// The callback to invoke when the common double field view is created on the graph by the user.
        /// </summary>
        /// <param name="view">The common double field view to set for.</param>
        public static void OnCreateByUser(CommonDoubleFieldView view)
        {
            view.Value = 0;
        }
    }
}