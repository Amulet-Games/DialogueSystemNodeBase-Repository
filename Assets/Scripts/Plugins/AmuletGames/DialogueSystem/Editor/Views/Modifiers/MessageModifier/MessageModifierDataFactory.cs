namespace AG.DS
{
    public class MessageModifierDataFactory
    {
        /// <summary>
        /// Generate a new message modifier data.
        /// </summary>
        /// <param name="view">The message modifier view to set for.</param>
        /// <returns>a new message modifier data.</returns>
        public static MessageModifierData Generate(MessageModifierView view)
        {
            var data = new MessageModifierData();
            MessageModifierSerializer.Save(view, data);

            return data;
        }
    }
}