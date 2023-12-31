namespace AG.DS
{
    public class EventModifierGroupSerializer
    {
        /// <summary>
        /// Save the event modifier group values.
        /// </summary>
        /// <param name="view">The event modifier group view to set for.</param>
        /// <param name="data">The event modifier group data to set for.</param>
        public void Save
        (
            EventModifierGroupView view,
            EventModifierGroupData data
        )
        {
            data.ModifiersData = new EventModifierData[view.ModifiersCount];

            for (int i = 0; i < view.ModifiersCount; i++)
            {
                data.ModifiersData[i] = new();
                new EventModifierSerializer().Save(view.Modifiers[i], data.ModifiersData[i]);
            }
        }


        /// <summary>
        /// Load the event modifier group values.
        /// </summary>
        /// <param name="view">The event modifier group view to set for.</param>
        /// <param name="data">The event modifier group data to set for.</param>
        public void Load
        (
            EventModifierGroupView view,
            EventModifierGroupData data
        )
        {
            for (int i = 0; i <= data.ModifiersData.Length; i++)
            {
                var modifier = new EventModifierSeeder().Generate(
                    groupView: view,
                    data: data.ModifiersData[i]
                );

                view.Add(modifier);
            }

            view.UpdateReferences();
        }
    }
}