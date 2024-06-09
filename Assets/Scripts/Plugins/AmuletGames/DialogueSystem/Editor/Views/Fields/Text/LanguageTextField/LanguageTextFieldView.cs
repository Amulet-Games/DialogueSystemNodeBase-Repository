using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class LanguageTextFieldView : IReversible, ILanguageFieldView
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public TextField Field;


        /// <summary>
        /// Label for the text field placeholder text.
        /// </summary>
        [NonSerialized] public Label PlaceholderTextLabel;


        /// <summary>
        /// The property of the view's value that matches the current dialogue system window's language.
        /// </summary>
        public string CurrentLanguageValue
        {
            get
            {
                return LanguageValue.ValueByLanguageType[LanguageHandler.CurrentLanguage];
            }
            set
            {
                IsEmpty = value.IsNullOrWhiteSpace();

                LanguageValue.ValueByLanguageType[LanguageHandler.CurrentLanguage] = IsEmpty ? "" : value;

                Field.SetValueWithoutNotify(LanguageValue.ValueByLanguageType[LanguageHandler.CurrentLanguage]);

                this.ToggleEmptyStyle();
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> LanguageValue { get; }


        /// <summary>
        /// Returns true if the view's field is currently empty.
        /// </summary>
        [NonSerialized] public bool IsEmpty;


        /// <summary>
        /// Reference of the language handler.
        /// </summary>
        [NonSerialized] public LanguageHandler LanguageHandler;


        /// <summary>
        /// Constructor of the language text field view class.
        /// </summary>
        /// <param name="languageHandler">The language handler to set for.</param>
        public LanguageTextFieldView(LanguageHandler languageHandler)
        {
            LanguageHandler = languageHandler;
            LanguageValue = new();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the view values.
        /// </summary>
        /// <param name="value">The language generic component to set for.</param>
        public void Save(LanguageGeneric<string> value)
        {
            value.Save(LanguageValue);
        }


        /// <summary>
        /// Load the view values.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(LanguageGeneric<string> value)
        {
            LanguageValue.Load(value);
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Update the field value to match the current view's language value.
        /// </summary>
        public void UpdateFieldLanguageValue()
        {
            CurrentLanguageValue = LanguageValue.ValueByLanguageType[LanguageHandler.CurrentLanguage];
        }


        /// <inheritdoc />
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize
            (
                serializationStream: memoryStream,
                graph: Field.value
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
                    CurrentLanguageValue = reverseValue;
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}
