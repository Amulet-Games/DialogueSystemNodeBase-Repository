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
            for (int i = 0; i < view.ModifiersCount; i++)
            {
                data.ModifiersData.Add(
                    ConditionModifierDataFactory.Generate(view: view.Modifiers[i])
                );
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
            var count = data.ModifiersData.Count;
            for (int i = 0; i <= count; i++)
            {
                var modifier = ConditionModifierViewFactory.Generate
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