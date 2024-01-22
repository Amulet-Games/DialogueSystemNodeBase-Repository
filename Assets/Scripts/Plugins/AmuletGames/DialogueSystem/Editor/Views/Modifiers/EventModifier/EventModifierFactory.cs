namespace AG.DS
{
    public class EventModifierFactory
    {
        /// <summary>
        /// Create a new event modifier view class.
        /// </summary>
        /// <param name="groupView">The event modifier group view to set for.</param>
        /// <param name="data">The event modifier data to set for.</param>
        /// <returns>A new event modifier view.</returns>
        public static EventModifierView Create
        (
            EventModifierGroupView groupView,
            EventModifierData data = null
        )
        {
            var view = new EventModifierView();

            EventModifierPresenter.CreateElement(view, index: groupView.NextIndex);

            new EventModifierObserver(view, groupView).RegisterEvents();

            if (data != null)
            {
                new EventModifierSerializer().Load(view, data);
            }

            EventModifierCallback.OnCreate(view, byUser: data == null);

            return view;
        }
    }
}