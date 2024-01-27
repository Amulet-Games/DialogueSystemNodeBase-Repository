namespace AG.DS
{
    public class ConditionModifierDataFactory
    {
        /// <summary>
        /// Generate a new condition modifier data.
        /// </summary>
        /// <param name="view">The condition modifier view to set for.</param>
        /// <returns>a new condition modifier data.</returns>
        public static ConditionModifierData Generate(ConditionModifierView view)
        {
            var data = new ConditionModifierData();
            ConditionModifierSerializer.Save(view, data);

            return data;
        }
    }
}