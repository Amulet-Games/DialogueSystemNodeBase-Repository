namespace AG.DS
{
    public class ConditionModifierGroupSerializer
    {
        /// <summary>
        /// Save the condition modifier group values.
        /// </summary>
        /// <param name="group">The condition modifier group element to set for.</param>
        /// <param name="data">The condition modifier group data to set for.</param>
        public void Save
        (
            ConditionModifierGroup group,
            ConditionModifierGroupData data
        )
        {
            data.ModifiersData = new ConditionModifierData[group.ModifiersCount];

            for (int i = 0; i < group.ModifiersCount; i++)
            {
                data.ModifiersData[i] = new();
                new ConditionModifierSerializer().Save(group.Modifiers[i], data.ModifiersData[i]);
            }
        }


        /// <summary>
        /// Load the condition modifier group values.
        /// </summary>
        /// <param name="group">The condition modifier group element to set for.</param>
        /// <param name="data">The condition modifier group data to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        public void Load
        (
            ConditionModifierGroup group,
            ConditionModifierGroupData data,
            GraphViewer graphViewer
        )
        {
            for (int i = 0; i <= data.ModifiersData.Length; i++)
            {
                var modifier = new ConditionModifierSeeder().Generate(
                    group: group,
                    graphViewer,
                    data: data.ModifiersData[i]
                );

                group.Add(modifier);
            }

            group.UpdateReferences();
        }
    }
}