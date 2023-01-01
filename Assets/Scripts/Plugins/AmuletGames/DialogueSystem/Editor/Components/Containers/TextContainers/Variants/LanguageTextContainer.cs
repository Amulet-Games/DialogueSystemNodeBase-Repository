using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class LanguageTextContainer : TextContainerBase, IReversible
    {
        /// <summary>
        /// The serializable value from the container.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> LanguageGeneric;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the language text container component class.
        /// </summary>
        public LanguageTextContainer()
        {
            LanguageGeneric = new();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the container values to the given data.
        /// </summary>
        /// <param name="data">The given data to save to.</param>
        public void SaveContainerValue(LanguageGeneric<string> data)
        {
            for (int i = 0; i < LanguagesConfig.SupportLanguageLength; i++)
            {
                // Save the TKey and TValue to the data.
                data.ValueByLanguageType[LanguagesConfig.SupportLanguageTypes[i]] =
                    LanguageGeneric.ValueByLanguageType[LanguagesConfig.SupportLanguageTypes[i]];
            }
        }

        
        /// <summary>
        /// Load the container values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadContainerValue(LanguageGeneric<string> data)
        {
            for (int i = 0; i < LanguagesConfig.SupportLanguageLength; i++)
            {
                // Load the TKey and TValue to the data.
                LanguageGeneric.ValueByLanguageType[LanguagesConfig.SupportLanguageTypes[i]] =
                    data.ValueByLanguageType[LanguagesConfig.SupportLanguageTypes[i]];
            }

            TextField.SetValueWithoutNotify
            (
                // Load field.
                LanguageGeneric.ValueByLanguageType[LanguagesConfig.SelectedLanguage]
            );

            // Toggle empty style.
            TextFieldHelper.ToggleEmptyStyle(this);
        }


        // ----------------------------- IReversible -----------------------------
        /// <inheritdoc />
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            string selectedLanguageValue =
                LanguageGeneric.ValueByLanguageType[LanguagesConfig.SelectedLanguage];

            binaryFormatter.Serialize
            (
                serializationStream: memoryStream,
                graph: selectedLanguageValue ?? ""
            );

            memoryStream.Close();
            return memoryStream.ToArray();
        }


        /// <inheritdoc />
        public void ReverseTo(byte[] array)
        {
            if (array != null)
            {
                object obj = new BinaryFormatter().Deserialize(new MemoryStream(array));

                if (obj is string reverseValue)
                {
                    // Load value.
                    LanguageGeneric.ValueByLanguageType[LanguagesConfig.SelectedLanguage] = reverseValue;

                    // Load field.
                    TextField.SetValueWithoutNotify(reverseValue);

                    // Toggle empty style.
                    TextFieldHelper.ToggleEmptyStyle(this);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }


        // ----------------------------- Update Language Field Services -----------------------------
        /// <summary>
        /// Update the field's value base on the current editor's language.
        /// </summary>
        public void UpdateLanguageField()
        {
            TextField.SetValueWithoutNotify
            (
                // Set the new value base on the language that the editor has changed to.
                newValue: LanguageGeneric.ValueByLanguageType[LanguagesConfig.SelectedLanguage]
            );

            // Toggle empty style.
            TextFieldHelper.ToggleEmptyStyle(this);
        }
    }
}
