namespace AG.DS
{
    public class EventModifierSeeder
    {
        /// <summary>
        /// Generate a new event modifier.
        /// </summary>
        /// <param name="group">The event modifier group element to set for.</param>
        /// <param name="data">The event modifier data to set for.</param>
        /// <returns>A new event modifier view.</returns>
        public EventModifierView Generate
        (
            EventModifierGroup group,
            EventModifierData data = null
        )
        {
            var view = new EventModifierView();

            EventModifierPresenter.CreateElement(view, index: group.NextIndex);

            new EventModifierObserver(view, group).RegisterEvents();

            if (data != null)
            {
                new EventModifierSerializer().Load(view, data);
            }

            EventModifierCallback.OnCreate(view, byUser: data == null);

            return view;
        }
    }
}