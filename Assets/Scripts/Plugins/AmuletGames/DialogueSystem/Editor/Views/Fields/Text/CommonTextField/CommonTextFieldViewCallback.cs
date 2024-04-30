namespace AG.DS
{
    public class CommonTextFieldViewCallback
    {
        /// <summary>
        /// The callback to invoke when the common text field view is created on the graph by the user.
        /// </summary>
        /// <param name="view"></param>
        public static void OnCreateByUser(CommonTextFieldView view)
        {
            view.Value = "";
        }
    }
}