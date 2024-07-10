namespace AG.DS
{
    public class CommonIntegerFieldViewCallback
    {
        /// <summary>
        /// The callback to invoke when the common integer field view is created on the graph by the user.
        /// </summary>
        /// <param name="view">The common integer field view to set for.</param>
        public static void OnCreateByUser(CommonIntegerFieldView view)
        {
            view.Value = 0;
        }
    }
}