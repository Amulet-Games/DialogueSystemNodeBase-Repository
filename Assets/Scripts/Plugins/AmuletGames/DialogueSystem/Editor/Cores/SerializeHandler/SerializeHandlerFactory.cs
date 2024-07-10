namespace AG.DS
{
    public class SerializeHandlerFactory
    {
        /// <summary>
        /// Generate a new serialize handler.
        /// </summary>
        /// <returns>A new serialize handler.</returns>
        public static SerializeHandler Generate()
        {
            return new SerializeHandler();
        }
    }
}