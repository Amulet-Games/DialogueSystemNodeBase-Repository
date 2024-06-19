namespace AG.DS
{
    public class MessageModifierViewGroupPresenter
    {
        /// <summary>
        /// Create the elements for the message modifier view group view.
        /// </summary>
        /// <param name="view">The message modifier view group view to set for.</param>
        public static void CreateElement(MessageModifierViewGroupView view)
        {
            view.GroupContainer = new();
            view.GroupContainer.AddToClassList(StyleConfig.MessageModifierGroup);
        }
    }
}