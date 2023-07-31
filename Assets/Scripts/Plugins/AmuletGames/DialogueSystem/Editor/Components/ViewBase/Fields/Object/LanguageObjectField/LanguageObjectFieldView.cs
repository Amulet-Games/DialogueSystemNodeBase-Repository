using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class LanguageObjectFieldView<TObject> : IReversible
        where TObject : UnityEngine.Object
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public ObjectField ObjectField;


        /// <summary>
        /// The text to display when the field is empty.
        /// </summary>
        [NonSerialized] public string PlaceholderText;


        /// <summary>
        /// The serializable value of the field.
        /// </summary>
        [SerializeField] public LanguageGeneric<TObject> LanguageGeneric;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the language object field view class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public LanguageObjectFieldView(string placeholderText)
        {
            PlaceholderText = placeholderText;

            LanguageGeneric = new();
            for (int i = 0; i < LanguageManager.Instance.SupportLanguageLength; i++)
            {
                LanguageGeneric.
                    ValueByLanguageType[LanguageManager.Instance.SupportLanguageTypes[i]] = null;
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the view values to the given value.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Save(LanguageGeneric<TObject> value)
        {
            var languageManager = LanguageManager.Instance;

            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                value.ValueByLanguageType[languageManager.SupportLanguageTypes[i]] =
                    LanguageGeneric.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
            }
        }


        /// <summary>
        /// Load the view values from the given value.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(LanguageGeneric<TObject> value)
        {
            var languageManager = LanguageManager.Instance;

            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                LanguageGeneric.ValueByLanguageType[languageManager.SupportLanguageTypes[i]] =
                           value.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
            }

            ObjectField.SetValueWithoutNotify
            (
                LanguageGeneric.ValueByLanguageType[languageManager.CurrentLanguage]
            );

            ObjectField.ToggleEmptyStyle(PlaceholderText);
        }


        // ----------------------------- IReversible -----------------------------
        /// <inheritdoc/>
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize
            (
                serializationStream: memoryStream,
                graph: ObjectField.value != null
                        ? AssetDatabase.GetAssetPath(ObjectField.value)
                        : ""
            );

            memoryStream.Close();
            return memoryStream.ToArray();
        }


        /// <inheritdoc/>
        public void ReverseTo(byte[] array)
        {
            if (array != null)
            {
                // Load the stashed asset's value path and retrieve it from asset data base.
                var reverseValue = (TObject)AssetDatabase.LoadAssetAtPath
                (
                    assetPath: (string)new BinaryFormatter().Deserialize(new MemoryStream(array)),
                    type: typeof(TObject)
                );

                if (reverseValue != null)
                {
                    LanguageGeneric.
                        ValueByLanguageType[LanguageManager.Instance.CurrentLanguage] = reverseValue;

                    ObjectField.SetValueWithoutNotify(reverseValue);

                    ObjectField.ToggleEmptyStyle(PlaceholderText);
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
            ObjectField.SetValueWithoutNotify
            (
                newValue: LanguageGeneric.ValueByLanguageType[LanguageManager.Instance.CurrentLanguage]
            );

            ObjectField.ToggleEmptyStyle(PlaceholderText);
        }
    }
}