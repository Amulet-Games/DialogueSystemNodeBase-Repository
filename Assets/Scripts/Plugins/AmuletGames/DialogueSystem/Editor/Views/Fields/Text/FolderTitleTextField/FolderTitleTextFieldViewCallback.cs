namespace AG.DS
{
    public class FolderTitleTextFieldCallback
    {
        /// <summary>
        /// The callback to invoke when the folder title text field view is created on the graph by the user.
        /// </summary>
        /// <param name="view">The folder title text field view to set for.</param>
        public static void OnCreateByUser(FolderTitleTextFieldView view)
        {
            view.Value = "";
        }
    }
}