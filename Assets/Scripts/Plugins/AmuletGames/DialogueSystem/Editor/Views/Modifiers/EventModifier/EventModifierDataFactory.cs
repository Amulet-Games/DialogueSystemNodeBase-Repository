namespace AG.DS
{
    public class EventModifierDataFactory
    {
        /// <summary>
        /// Generate a new event modifier data.
        /// </summary>
        /// <param name="view">The event modifier view to set for.</param>
        /// <returns>a new event modifier data.</returns>
        public static EventModifierData Generate(EventModifierView view)
        {
            var data = new EventModifierData();
            EventModifierSerializer.Save(view, data);

            return data;
        }
    }
}