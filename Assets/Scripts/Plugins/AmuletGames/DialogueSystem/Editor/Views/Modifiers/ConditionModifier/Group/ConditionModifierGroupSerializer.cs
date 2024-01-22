namespace AG.DS
{
    public class ConditionModifierGroupSerializer
    {
        /// <summary>
        /// Save the condition modifier group values.
        /// </summary>
        /// <param name="view">The condition modifier group view to set for.</param>
        /// <param name="data">The condition modifier group data to set for.</param>
        public void Save
        (
            ConditionModifierGroupView view,
            ConditionModifierGroupData data
        )
        {
            data.ModifiersData = new ConditionModifierData[view.ModifiersCount];

            for (int i = 0; i < view.ModifiersCount; i++)
            {
                data.ModifiersData[i] = new();
                new ConditionModifierSerializer().Save(view.Modifiers[i], data.ModifiersData[i]);
            }
        }


        /// <summary>
        /// Load the condition modifier group values.
        /// </summary>
        /// <param name="view">The condition modifier group view to set for.</param>
        /// <param name="data">The condition modifier group data to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        public void Load
        (
            ConditionModifierGroupView view,
            ConditionModifierGroupData data,
            GraphViewer graphViewer
        )
        {
            for (int i = 0; i <= data.ModifiersData.Length; i++)
            {
                var modifier = ConditionModifierFactory.Create
                (
                    groupView: view,
                    graphViewer,
                    data: data.ModifiersData[i]
                );

                view.Add(modifier);
            }

            view.UpdateReferences();
        }
    }
}