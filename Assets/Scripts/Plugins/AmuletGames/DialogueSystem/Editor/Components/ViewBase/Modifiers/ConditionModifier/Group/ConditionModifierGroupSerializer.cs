namespace AG.DS
{
    public class ConditionModifierGroupSerializer
    {
        /// <summary>
        /// Save the condition modifier group values.
        /// </summary>
        /// <param name="view">The condition modifier group view to set for.</param>
        /// <param name="model">The condition modifier group model to set for.</param>
        public void Save
        (
            ConditionModifierGroupView view,
            ConditionModifierGroupModel model
        )
        {
            model.ModifierModels = new ConditionModifierModel[view.ModifiersCount];

            for (int i = 0; i < view.ModifiersCount; i++)
            {
                model.ModifierModels[i] = new();
                new ConditionModifierSerializer().Save(view.Modifiers[i], model.ModifierModels[i]);
            }
        }


        /// <summary>
        /// Load the condition modifier group values.
        /// </summary>
        /// <param name="view">The condition modifier group view to set for.</param>
        /// <param name="model">The condition modifier group model to set for.</param>
        /// <param name="graphViewer">The graph viewer to set for.</param>
        public void Load
        (
            ConditionModifierGroupView view,
            ConditionModifierGroupModel model,
            GraphViewer graphViewer
        )
        {
            for (int i = 0; i <= model.ModifierModels.Length; i++)
            {
                var modifier = new ConditionModifierSeeder().Generate(
                    groupView: view,
                    graphViewer,
                    model: model.ModifierModels[i]
                );

                view.Add(modifier);
            }

            view.UpdateReferences();
        }
    }
}