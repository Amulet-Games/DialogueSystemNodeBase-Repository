namespace AG.DS
{
    public class EventModifierGroupPresenter
    {
        /// <summary>
        /// Method for creating the elements for the event modifier group view.
        /// </summary>
        /// <param name="view">The event modifier group view to set for.</param>
        public static void CreateElement(EventModifierGroupView view)
        {
            view.MainContainer = new();
            view.MainContainer.AddToClassList(StyleConfig.EventModifierGroup_MainContainer);
        }
    }
}