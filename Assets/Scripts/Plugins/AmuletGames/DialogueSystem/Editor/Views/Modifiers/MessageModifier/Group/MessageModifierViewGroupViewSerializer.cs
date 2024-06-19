namespace AG.DS
{
    public class MessageModifierViewGroupViewSerializer
    {
        /// <summary>
        /// Save the message modifier view group view values.
        /// </summary>
        /// <param name="view">The message modifier view group view to set for.</param>
        /// <param name="data">The message modifier view group view data to set for.</param>
        public void Save
        (
            MessageModifierViewGroupView view,
            MessageModifierViewGroupViewData data
        )
        {
            for (int i = 0; i < view.ModifiersCount; i++)
            {
                data.ModifierViewsData.Add(
                    MessageModifierViewDataFactory.Generate(view: view.Modifiers[i])
                );
            }
        }


        /// <summary>
        /// Load the message modifier view group view values.
        /// </summary>
        /// <param name="view">The message modifier view group view to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="data">The message modifier view group view data to set for.</param>
        public void Load
        (
            MessageModifierViewGroupView view,
            LanguageHandler languageHandler,
            MessageModifierViewGroupViewData data
        )
        {
            var count = data.ModifierViewsData.Count;
            for (int i = 0; i <= count; i++)
            {
                var modifier = MessageModifierViewFactory.Generate
                (
                    groupView: view,
                    languageHandler,
                    data: data.ModifierViewsData[i]
                );

                view.Add(modifier);
            }

            view.UpdateModifiersReferences();
        }
    }
}