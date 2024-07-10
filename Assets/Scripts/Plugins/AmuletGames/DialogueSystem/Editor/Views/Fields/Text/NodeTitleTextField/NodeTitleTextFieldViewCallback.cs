namespace AG.DS
{
    public class NodeTitleTextFieldCallback
    {
        /// <summary>
        /// The callback to invoke when the node title text field view is created on the graph by the user.
        /// </summary>
        /// <param name="view">The node title text field view to set for.</param>
        public static void OnCreateByUser(NodeTitleTextFieldView view)
        {
            view.Value = "";
        }
    }
}