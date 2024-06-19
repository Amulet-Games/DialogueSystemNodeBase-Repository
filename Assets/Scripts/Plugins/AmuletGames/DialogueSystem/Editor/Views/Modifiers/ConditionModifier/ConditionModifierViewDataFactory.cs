namespace AG.DS
{
    public class ConditionModifierViewDataFactory
    {
        /// <summary>
        /// Generate a new condition modifier view data.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <returns>a new condition modifier view data.</returns>
        public static ConditionModifierViewData Generate(ConditionModifierView view)
        {
            var data = new ConditionModifierViewData();
            ConditionModifierViewSerializer.Save(view, data);

            return data;
        }
    }
}