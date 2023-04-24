using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class LanguageTextFieldModel : IReversible
    {
        /// <summary>
        /// The text to show when the text field has no actual value in it.
        /// </summary>
        [NonSerialized] public string PlaceholderText;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public TextField TextField;


        /// <summary>
        /// The serializable value from the container.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> LanguageGeneric;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the language text field model class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public LanguageTextFieldModel(string placeholderText)
        {
            PlaceholderText = placeholderText;

            LanguageGeneric = new();
            for (int i = 0; i < LanguageManager.Instance.SupportLanguageLength; i++)
            {
                LanguageGeneric.
                    ValueByLanguageType[LanguageManager.Instance.SupportLanguageTypes[i]] = "";
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the model values to the given data.
        /// </summary>
        /// <param name="data">The data to save to.</param>
        public void Save(LanguageGeneric<string> data)
        {
            var languageManager = LanguageManager.Instance;

            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                data.ValueByLanguageType[languageManager.SupportLanguageTypes[i]] =
                    LanguageGeneric.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
            }
        }

        
        /// <summary>
        /// Load the model values from the given data.
        /// </summary>
        /// <param name="data">The data to load from.</param>
        public void Load(LanguageGeneric<string> data)
        {
            var languageManager = LanguageManager.Instance;

            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                LanguageGeneric.ValueByLanguageType[languageManager.SupportLanguageTypes[i]] =
                           data.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
            }

            TextField.SetValueWithoutNotify
            (
                LanguageGeneric.ValueByLanguageType[languageManager.SelectedLanguage]
            );

            TextField.ToggleEmptyStyle(placeholderText: PlaceholderText);
        }


        // ----------------------------- IReversible -----------------------------
        /// <inheritdoc />
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize
            (
                serializationStream: memoryStream,
                graph: TextField.value
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
                    LanguageGeneric.
                        ValueByLanguageType[LanguageManager.Instance.SelectedLanguage] = reverseValue;

                    TextField.SetValueWithoutNotify(reverseValue);

                    TextField.ToggleEmptyStyle(placeholderText: PlaceholderText);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }


        // ----------------------------- Update Language Field -----------------------------
        /// <summary>
        /// Update the field's value base on the current editor's language.
        /// </summary>
        public void UpdateLanguageField()
        {
            TextField.SetValueWithoutNotify
            (
                newValue: LanguageGeneric.ValueByLanguageType[LanguageManager.Instance.SelectedLanguage]
            );

            TextField.ToggleEmptyStyle(placeholderText: PlaceholderText);
        }
    }
}
