namespace AG.DS
{
    public class EventModifierViewFactory
    {
        /// <summary>
        /// Generate a new event modifier view class.
        /// </summary>
        /// <param name="groupView">The event modifier view group view to set for.</param>
        /// <param name="data">The event modifier view data to set for.</param>
        /// <returns>A new event modifier view.</returns>
        public static EventModifierView Generate
        (
            EventModifierViewGroupView groupView,
            EventModifierViewData data = null
        )
        {
            var view = new EventModifierView();

            EventModifierViewPresenter.CreateElement(view, index: groupView.NextIndex);

            new EventModifierViewObserver(view, groupView).RegisterEvents();

            if (data != null)
            {
                EventModifierViewSerializer.Load(view, data);
            }

            EventModifierViewCallback.OnCreate(view, byUser: data == null);

            return view;
        }
    }
}