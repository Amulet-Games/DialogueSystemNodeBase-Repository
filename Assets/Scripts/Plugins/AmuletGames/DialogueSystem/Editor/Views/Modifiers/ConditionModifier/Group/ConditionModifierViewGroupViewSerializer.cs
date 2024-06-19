namespace AG.DS
{
    public class ConditionModifierViewGroupViewSerializer
    {
        /// <summary>
        /// Save the condition modifier view group view values.
        /// </summary>
        /// <param name="view">The condition modifier view group view to set for.</param>
        /// <param name="data">The condition modifier view group view data to set for.</param>
        public void Save
        (
            ConditionModifierViewGroupView view,
            ConditionModifierViewGroupViewData data
        )
        {
            for (int i = 0; i < view.ModifiersCount; i++)
            {
                data.ModifierViewsData.Add(
                    ConditionModifierViewDataFactory.Generate(view: view.Modifiers[i])
                );
            }
        }


        /// <summary>
        /// Load the condition modifier view group view values.
        /// </summary>
        /// <param name="view">The condition modifier view group view to set for.</param>
        /// <param name="data">The condition modifier view group view data to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        public void Load
        (
            ConditionModifierViewGroupView view,
            ConditionModifierViewGroupViewData data,
            GraphViewer graphViewer
        )
        {
            var count = data.ModifierViewsData.Count;
            for (int i = 0; i <= count; i++)
            {
                var modifier = ConditionModifierViewFactory.Generate
                (
                    groupView: view,
                    graphViewer,
                    data: data.ModifierViewsData[i]
                );

                view.Add(modifier);
            }

            view.UpdateModifiersReferences();
        }
    }
}