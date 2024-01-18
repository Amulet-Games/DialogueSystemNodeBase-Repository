namespace AG.DS
{
    public class ConditionModifierGroupPresenter
    {
        /// <summary>
        /// Create a new condition modifier group element.
        /// </summary>
        /// <returns>A new condition modifier group element.</returns>
        public static ConditionModifierGroup CreateElement()
        {
            var group = new ConditionModifierGroup();

            group.AddToClassList(StyleConfig.ConditionModifierGroup);

            return group;
        }
    }
}