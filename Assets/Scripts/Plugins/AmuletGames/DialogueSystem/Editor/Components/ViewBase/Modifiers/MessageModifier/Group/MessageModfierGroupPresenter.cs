namespace AG.DS
{
    public class MessageModifierGroupPresenter
    {
        /// <summary>
        /// Create a new message modifier group element.
        /// </summary>
        /// <returns>A new message modifier group element.</returns>
        public static MessageModifierGroup CreateElement()
        {
            var group = new MessageModifierGroup();

            group.AddToClassList(StyleConfig.MessageModifierGroup);

            return group;
        }
    }
}