namespace AG.DS
{
    public class CommonFloatFieldCallback
    {
        /// <summary>
        /// The callback to invoke when the common float field view is created on the graph by the user.
        /// </summary>
        /// <param name="view">The common float field view to set for.</param>
        public static void OnCreateByUser(CommonFloatFieldView view)
        {
            view.Value = 0;
        }
    }
}