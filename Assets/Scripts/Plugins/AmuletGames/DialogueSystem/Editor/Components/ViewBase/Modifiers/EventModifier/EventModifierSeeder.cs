namespace AG.DS
{
    public class EventModifierSeeder
    {
        /// <summary>
        /// Generate a new event modifier.
        /// </summary>
        /// <param name="groupView">The event modifier group view to set for.</param>
        /// <param name="data">The event modifier data to set for.</param>
        /// <returns>A new event modifier view.</returns>
        public EventModifierView Generate
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

            new EventModifierCallback().OnCreate(view, data == null);

            return view;
        }
    }
}