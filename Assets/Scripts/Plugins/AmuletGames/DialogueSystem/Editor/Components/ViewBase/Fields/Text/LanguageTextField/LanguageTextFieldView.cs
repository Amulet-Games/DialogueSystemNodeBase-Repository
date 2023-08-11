using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class LanguageTextFieldView : IReversible
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public TextField TextField;


        /// <summary>
        /// The text to display when the field is empty.
        /// </summary>
        [NonSerialized] public string PlaceholderText;


        /// <summary>
        /// The serializable value of the view.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> value;


        /// <summary>
        /// Constructor of the language text field view class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public LanguageTextFieldView(string placeholderText)
        {
            PlaceholderText = placeholderText;

            value = new();
            for (int i = 0; i < LanguageManager.Instance.SupportLanguageLength; i++)
            {
                value.ValueByLanguageType[LanguageManager.Instance.SupportLanguageTypes[i]] = "";
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the view values to the given value.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Save(LanguageGeneric<string> value)
        {
            var languageManager = LanguageManager.Instance;

            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                value.ValueByLanguageType[languageManager.SupportLanguageTypes[i]] =
                    this.value.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
            }
        }


        /// <summary>
        /// Load the view values from the given value.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(LanguageGeneric<string> value)
        {
            var languageManager = LanguageManager.Instance;

            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                this.value.ValueByLanguageType[languageManager.SupportLanguageTypes[i]] =
                           value.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
            }

            TextField.SetValueWithoutNotify
            (
                this.value.ValueByLanguageType[languageManager.CurrentLanguage]
            );

            TextField.ToggleEmptyStyle(PlaceholderText);
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
                    value.ValueByLanguageType[LanguageManager.Instance.CurrentLanguage] = reverseValue;

                    TextField.SetValueWithoutNotify(reverseValue);

                    TextField.ToggleEmptyStyle(PlaceholderText);
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
                newValue: value.ValueByLanguageType[LanguageManager.Instance.CurrentLanguage]
            );

            TextField.ToggleEmptyStyle(PlaceholderText);
        }
    }
}
