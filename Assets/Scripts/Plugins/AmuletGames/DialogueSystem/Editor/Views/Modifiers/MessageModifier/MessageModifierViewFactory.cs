namespace AG.DS
{
    public class MessageModifierViewFactory
    {
        /// <summary>
        /// Generate a new message modifier view class.
        /// </summary>
        /// <param name="groupView">The message modifier view group view to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="data">The message modifier view data to set for.</param>
        /// <returns>A new message modifier view class.</returns>
        public static MessageModifierView Generate
        (
            MessageModifierViewGroupView groupView,
            LanguageHandler languageHandler,
            MessageModifierViewData data = null
        )
        {
            var view = new MessageModifierView(languageHandler);

            MessageModifierViewPresenter.CreateElement(view, index: groupView.NextIndex);

            new MessageModifierViewObserver(view, groupView).RegisterEvents();

            if (data != null)
            {
                MessageModifierViewSerializer.Load(view, data);
            }

            MessageModifierViewCallback.OnCreate(view, byUser: data == null);

            return view;
        }
    }
}