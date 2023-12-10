namespace AG.DS
{
    public class MessageModifierGroupSerializer
    {
        /// <summary>
        /// Save the message modifier group values.
        /// </summary>
        /// <param name="view">The message modifier group view to set for.</param>
        /// <param name="model">The message modifier group model to set for.</param>
        public void Save
        (
            MessageModifierGroupView view,
            MessageModifierGroupModel model
        )
        {
            model.ModifierModels = new MessageModifierModel[view.ModifiersCount];

            for (int i = 0; i < view.ModifiersCount; i++)
            {
                model.ModifierModels[i] = new();
                new MessageModifierSerializer().Save(view.Modifiers[i], model.ModifierModels[i]);
            }
        }


        /// <summary>
        /// Load the message modifier group values.
        /// </summary>
        /// <param name="view">The message modifier group view to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="model">The message modifier group model to set for.</param>
        public void Load
        (
            MessageModifierGroupView view,
            LanguageHandler languageHandler,
            MessageModifierGroupModel model
        )
        {
            for (int i = 0; i <= model.ModifierModels.Length; i++)
            {
                var modifier = new MessageModifierSeeder().Generate(
                    groupView: view,
                    languageHandler,
                    model: model.ModifierModels[i]
                );

                view.Add(modifier);
            }

            view.UpdateReferences();
        }
    }
}