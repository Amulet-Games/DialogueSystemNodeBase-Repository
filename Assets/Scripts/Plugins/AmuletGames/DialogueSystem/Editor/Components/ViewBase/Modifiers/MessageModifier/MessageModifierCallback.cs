namespace AG.DS
{
    public class MessageModifierCallback
    {
        /// <summary>
        /// The callback to invoke when the modifier is created on the graph by the system or user.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <param name="byUser">Is the modifier created by the user.</param>
        public void OnCreate
        (
            MessageModifierView view,
            bool byUser
        )
        {
            if (byUser)
            {
                FolderCallback.OnCreateByUser(view.Folder);
            }
        }
    }
}