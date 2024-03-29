namespace AG.DS
{
    public class MessageModifierViewFactory
    {
        /// <summary>
        /// Generate a new message modifier view class.
        /// </summary>
        /// <param name="groupView">The message modifier group view to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="data">The message modifier data to set for.</param>
        /// <returns>A new message modifier view class.</returns>
        public static MessageModifierView Generate
        (
            MessageModifierGroupView groupView,
            LanguageHandler languageHandler,
            MessageModifierData data = null
        )
        {
            var view = new MessageModifierView(languageHandler);

            MessageModifierPresenter.CreateElement(view, index: groupView.NextIndex);

            new MessageModifierObserver(view, groupView).RegisterEvents();

            if (data != null)
            {
                MessageModifierSerializer.Load(view, data);
            }

            MessageModifierCallback.OnCreate(view, byUser: data == null);

            return view;
        }
    }
}