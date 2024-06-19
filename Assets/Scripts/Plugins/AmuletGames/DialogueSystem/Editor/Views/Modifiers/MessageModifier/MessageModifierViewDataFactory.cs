namespace AG.DS
{
    public class MessageModifierViewDataFactory
    {
        /// <summary>
        /// Generate a new message modifier view data.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <returns>a new message modifier view data.</returns>
        public static MessageModifierViewData Generate(MessageModifierView view)
        {
            var data = new MessageModifierViewData();
            MessageModifierViewSerializer.Save(view, data);

            return data;
        }
    }
}