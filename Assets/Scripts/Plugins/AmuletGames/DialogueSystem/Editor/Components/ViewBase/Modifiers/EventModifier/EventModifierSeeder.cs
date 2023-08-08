namespace AG.DS
{
    public class EventModifierSeeder
    {
        /// <summary>
        /// Generate a new event modifier.
        /// </summary>
        /// <param name="groupView">The event modifier group view to set for.</param>
        /// <param name="model">The event modifier model to set for.</param>
        /// <returns>A new event modifier.</returns>
        public EventModifierView Generate
        (
            EventModifierGroupView groupView,
            EventModifierModel model = null
        )
        {
            var view = new EventModifierView();

            EventModifierPresenter.CreateElement(view, index: groupView.NextIndex);

            new EventModifierObserver(view, groupView).RegisterEvents();

            if (model != null)
            {
                view.LoadModifierValue(model);
            }

            return view;
        }
    }
}