namespace AG.DS
{
    public class ConditionModifierGroupPresenter
    {
        /// <summary>
        /// Create the elements for the condition modifier group view.
        /// </summary>
        /// <param name="view">The condition modifier group view to set for.</param>
        public static void CreateElement(ConditionModifierGroupView view)
        {
            view.GroupContainer = new();
            view.GroupContainer.AddToClassList(StyleConfig.ConditionModifierGroup);
        }
    }
}