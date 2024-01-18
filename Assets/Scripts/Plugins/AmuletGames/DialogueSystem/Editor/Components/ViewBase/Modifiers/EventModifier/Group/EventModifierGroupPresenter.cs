namespace AG.DS
{
    public class EventModifierGroupPresenter
    {
        /// <summary>
        /// Create a new event modifier group element.
        /// </summary>
        /// <returns>A new event modifier group element.</returns>
        public static EventModifierGroup CreateElement()
        {
            var group = new EventModifierGroup();

            group.AddToClassList(StyleConfig.EventModifierGroup);

            return group;
        }
    }
}