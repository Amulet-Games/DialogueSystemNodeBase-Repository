namespace AG.DS
{
    public class EventModifierViewDataFactory
    {
        /// <summary>
        /// Generate a new event modifier view data.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <returns>a new event modifier view data.</returns>
        public static EventModifierViewData Generate(EventModifierView view)
        {
            var data = new EventModifierViewData();
            EventModifierViewSerializer.Save(view, data);

            return data;
        }
    }
}