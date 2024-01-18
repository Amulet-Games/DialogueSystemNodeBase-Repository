namespace AG.DS
{
    public class MessageModifierGroupSerializer
    {
        /// <summary>
        /// Save the message modifier group values.
        /// </summary>
        /// <param name="group">The message modifier group element to set for.</param>
        /// <param name="data">The message modifier group data to set for.</param>
        public void Save
        (
            MessageModifierGroup group,
            MessageModifierGroupData data
        )
        {
            data.ModifiersData = new MessageModifierData[group.ModifiersCount];

            for (int i = 0; i < group.ModifiersCount; i++)
            {
                data.ModifiersData[i] = new();
                new MessageModifierSerializer().Save(group.Modifiers[i], data.ModifiersData[i]);
            }
        }


        /// <summary>
        /// Load the message modifier group values.
        /// </summary>
        /// <param name="group">The message modifier group element to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        /// <param name="data">The message modifier group data to set for.</param>
        public void Load
        (
            MessageModifierGroup group,
            LanguageHandler languageHandler,
            MessageModifierGroupData data
        )
        {
            for (int i = 0; i <= data.ModifiersData.Length; i++)
            {
                var modifier = new MessageModifierSeeder().Generate(
                    group: group,
                    languageHandler,
                    data: data.ModifiersData[i]
                );

                group.Add(modifier);
            }

            group.UpdateReferences();
        }
    }
}