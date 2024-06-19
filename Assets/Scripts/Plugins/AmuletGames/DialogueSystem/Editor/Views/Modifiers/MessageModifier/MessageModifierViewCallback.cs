namespace AG.DS
{
    public class MessageModifierViewCallback
    {
        /// <summary>
        /// The callback to invoke when the modifier is created on the graph by the system or user.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <param name="byUser">Is the modifier created by the user.</param>
        public static void OnCreate
        (
            MessageModifierView view,
            bool byUser
        )
        {
            if (byUser)
            {
                FolderCallback.OnCreateByUser(view.Folder);

                LanguageTextFieldCallback.OnCreateByUser(view.MessageTextFieldView);

                CommonFloatFieldCallback.OnCreateByUser(view.DelaySecondsFieldView);
            }
        }
    }
}