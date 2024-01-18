namespace AG.DS
{
    public class MessageModifierSeeder
    {
        /// <summary>
        /// Generate a new message modifier.
        /// </summary>
        /// <param name="group">The message modifier group element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="data">The message modifier data to set for.</param>
        /// <returns>A new message modifier view.</returns>
        public MessageModifierView Generate
        (
            MessageModifierGroup group,
            LanguageHandler languageHandler,
            MessageModifierData data = null
        )
        {
            var view = new MessageModifierView(languageHandler);

            MessageModifierPresenter.CreateElement(view, index: group.NextIndex);

            new MessageModifierObserver(view, group).RegisterEvents();

            if (data != null)
            {
                new MessageModifierSerializer().Load(view, data);
            }

            new MessageModifierCallback().OnCreate(view, data == null);

            return view;
        }
    }
}