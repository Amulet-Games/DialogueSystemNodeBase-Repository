namespace AG.DS
{
    public class MessageModifierGroupPresenter
    {
        /// <summary>
        /// Create the elements for the message modifier group view.
        /// </summary>
        /// <param name="view">The message modifier group view to set for.</param>
        public static void CreateElement(MessageModifierGroupView view)
        {
            view.GroupContainer = new();
            view.GroupContainer.AddToClassList(StyleConfig.MessageModifierGroup);
        }
    }
}