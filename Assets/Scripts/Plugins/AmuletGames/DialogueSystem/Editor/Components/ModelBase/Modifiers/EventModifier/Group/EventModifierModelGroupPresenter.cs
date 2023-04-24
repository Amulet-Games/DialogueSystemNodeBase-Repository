namespace AG.DS
{
    public class EventModifierModelGroupPresenter
    {
        /// <summary>
        /// Method for creating a new event modifier model group UIElement.
        /// </summary>
        /// <param name="model">The event modifier model group model to set for.</param>
        public static void CreateElements(EventModifierModelGroupModel model)
        {
            model.MainContainer = new();
            model.MainContainer.AddToClassList(StyleConfig.Instance.EventModifierGroup_MainContainer);
        }
    }
}