namespace AG.DS
{
    public class EventModifierGroupSerializer
    {
        /// <summary>
        /// Save the event modifier group values.
        /// </summary>
        /// <param name="group">The event modifier group element to set for.</param>
        /// <param name="data">The event modifier group data to set for.</param>
        public void Save
        (
            EventModifierGroup group,
            EventModifierGroupData data
        )
        {
            data.ModifiersData = new EventModifierData[group.ModifiersCount];

            for (int i = 0; i < group.ModifiersCount; i++)
            {
                data.ModifiersData[i] = new();
                new EventModifierSerializer().Save(group.Modifiers[i], data.ModifiersData[i]);
            }
        }


        /// <summary>
        /// Load the event modifier group values.
        /// </summary>
        /// <param name="group">The event modifier group element to set for.</param>
        /// <param name="data">The event modifier group data to set for.</param>
        public void Load
        (
            EventModifierGroup group,
            EventModifierGroupData data
        )
        {
            for (int i = 0; i <= data.ModifiersData.Length; i++)
            {
                var modifier = new EventModifierSeeder().Generate(
                    group: group,
                    data: data.ModifiersData[i]
                );

                group.Add(modifier);
            }

            group.UpdateReferences();
        }
    }
}