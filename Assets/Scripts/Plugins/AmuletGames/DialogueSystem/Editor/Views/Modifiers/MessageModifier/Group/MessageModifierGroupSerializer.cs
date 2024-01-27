namespace AG.DS
{
    public class MessageModifierGroupSerializer
    {
        /// <summary>
        /// Save the message modifier group values.
        /// </summary>
        /// <param name="view">The message modifier group view to set for.</param>
        /// <param name="data">The message modifier group data to set for.</param>
        public void Save
        (
            MessageModifierGroupView view,
            MessageModifierGroupData data
        )
        {
            for (int i = 0; i < view.ModifiersCount; i++)
            {
                data.ModifiersData.Add(
                    MessageModifierDataFactory.Generate(view: view.Modifiers[i])
                );
            }
        }


        /// <summary>
        /// Load the message modifier group values.
        /// </summary>
        /// <param name="view">The message modifier group view to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="data">The message modifier group data to set for.</param>
        public void Load
        (
            MessageModifierGroupView view,
            LanguageHandler languageHandler,
            MessageModifierGroupData data
        )
        {
            var count = data.ModifiersData.Count;
            for (int i = 0; i <= count; i++)
            {
                var modifier = MessageModifierViewFactory.Generate
                (
                    groupView: view,
                    languageHandler,
                    data: data.ModifiersData[i]
                );

                view.Add(modifier);
            }

            view.UpdateReferences();
        }
    }
}