namespace AG.DS
{
    public class EventModifierCallback
    {
        /// <summary>
        /// The callback to invoke when the modifier is created on the graph by the system or user.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <param name="byUser">Is the modifier created by the user.</param>
        public void OnCreate
        (
            EventModifierView view,
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