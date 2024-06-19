namespace AG.DS
{
    public class EventModifierViewGroupPresenter
    {
        /// <summary>
        /// Create the elements for the event modifier view group view.
        /// </summary>
        /// <param name="view">The event modifier view group view to set for.</param>
        public static void CreateElement(EventModifierViewGroupView view)
        {
            view.GroupContainer = new();
            view.GroupContainer.AddToClassList(StyleConfig.EventModifierGroup);
        }
    }
}