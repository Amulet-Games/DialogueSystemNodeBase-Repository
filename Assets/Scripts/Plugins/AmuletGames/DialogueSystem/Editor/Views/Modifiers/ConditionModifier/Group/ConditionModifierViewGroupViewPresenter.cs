namespace AG.DS
{
    public class ConditionModifierViewGroupViewPresenter
    {
        /// <summary>
        /// Create the elements for the condition modifier view group view.
        /// </summary>
        /// <param name="view">The condition modifier view group view to set for.</param>
        public static void CreateElement(ConditionModifierViewGroupView view)
        {
            view.GroupContainer = new();
            view.GroupContainer.AddToClassList(StyleConfig.ConditionModifierGroup);
        }
    }
}