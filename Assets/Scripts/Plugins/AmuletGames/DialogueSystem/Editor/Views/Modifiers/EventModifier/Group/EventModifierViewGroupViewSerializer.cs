namespace AG.DS
{
    public class EventModifierViewGroupViewSerializer
    {
        /// <summary>
        /// Save the event modifier view group view values.
        /// </summary>
        /// <param name="view">The event modifier view group view to set for.</param>
        /// <param name="data">The event modifier view group view data to set for.</param>
        public void Save
        (
            EventModifierViewGroupView view,
            EventModifierViewGroupViewData data
        )
        {
            for (int i = 0; i < view.ModifiersCount; i++)
            {
                data.ModifierViewsData.Add(
                    EventModifierViewDataFactory.Generate(view: view.Modifiers[i])
                );
            }
        }


        /// <summary>
        /// Load the event modifier view group view values.
        /// </summary>
        /// <param name="view">The event modifier view group view to set for.</param>
        /// <param name="data">The event modifier view group view data to set for.</param>
        public void Load
        (
            EventModifierViewGroupView view,
            EventModifierViewGroupViewData data
        )
        {
            var count = data.ModifierViewsData.Count;
            for (int i = 0; i <= count; i++)
            {
                var modifier = EventModifierViewFactory.Generate
                (
                    groupView: view,
                    data: data.ModifierViewsData[i]
                );

                view.Add(modifier);
            }

            view.UpdateModifiersReferences();
        }
    }
}