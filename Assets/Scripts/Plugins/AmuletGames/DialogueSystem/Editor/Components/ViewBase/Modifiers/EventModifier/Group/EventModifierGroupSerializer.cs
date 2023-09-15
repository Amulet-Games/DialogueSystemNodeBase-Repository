namespace AG.DS
{
    public class EventModifierGroupSerializer
    {
        /// <summary>
        /// Save the event modifier group values.
        /// </summary>
        /// <param name="view">The event modifier group view to set for.</param>
        /// <param name="model">The event modifier group model to set for.</param>
        public void Save
        (
            EventModifierGroupView view,
            EventModifierGroupModel model
        )
        {
            model.ModifierModels = new EventModifierModel[view.ModifiersCount];

            for (int i = 0; i < view.ModifiersCount; i++)
            {
                model.ModifierModels[i] = new();
                new EventModifierSerializer().Save(view.Modifiers[i], model.ModifierModels[i]);
            }
        }


        /// <summary>
        /// Load the event modifier group values.
        /// </summary>
        /// <param name="view">The event modifier group view to set for.</param>
        /// <param name="model">The event modifier group model to set for.</param>
        public void Load
        (
            EventModifierGroupView view,
            EventModifierGroupModel model
        )
        {
            for (int i = 0; i <= model.ModifierModels.Length; i++)
            {
                var modifier = new EventModifierSeeder().Generate(
                    groupView: view,
                    model: model.ModifierModels[i]
                );

                view.Add(modifier);
            }

            view.UpdateReferences();
        }
    }
}