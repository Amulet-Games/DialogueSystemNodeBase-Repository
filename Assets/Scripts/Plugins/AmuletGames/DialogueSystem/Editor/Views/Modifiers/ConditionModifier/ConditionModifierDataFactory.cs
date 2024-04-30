namespace AG.DS
{
    public class ConditionModifierDataFactory
    {
        /// <summary>
        /// Generate a new condition modifier data.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <returns>a new condition modifier data.</returns>
        public static ConditionModifierViewData Generate(ConditionModifierView view)
        {
            var data = new ConditionModifierViewData();
            ConditionModifierViewSerializer.Save(view, data);

            return data;
        }
    }
}