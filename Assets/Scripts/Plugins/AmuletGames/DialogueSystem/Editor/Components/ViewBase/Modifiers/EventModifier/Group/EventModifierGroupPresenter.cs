namespace AG.DS
{
    public class EventModifierGroupPresenter
    {
        /// <summary>
        /// Create the elements for the event modifier group view.
        /// </summary>
        /// <param name="view">The event modifier group view to set for.</param>
        public static void CreateElement(EventModifierGroupView view)
        {
            view.GroupContainer = new();
            view.GroupContainer.AddToClassList(StyleConfig.Event_Modifier_Group);
        }
    }
}