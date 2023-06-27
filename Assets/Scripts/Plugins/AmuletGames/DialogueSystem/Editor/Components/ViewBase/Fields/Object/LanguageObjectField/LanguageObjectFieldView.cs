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
        /// The serializable value from the view.
        /// </summary>
        [SerializeField] public LanguageGeneric<TObject> LanguageGeneric;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the language object field view class.
        /// </summary>
        public LanguageObjectFieldView()
        {
            // Setup language generic.
            LanguageGeneric = new();

            for (int i = 0; i < LanguageManager.Instance.SupportLanguageLength; i++)
            {
                LanguageGeneric.
                    ValueByLanguageType[LanguageManager.Instance.SupportLanguageTypes[i]] = null;
            }
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the view values to the given data.
        /// </summary>
        /// <param name="data">The data to save to.</param>
        public void Save(LanguageGeneric<TObject> data)
        {
            var languageManager = LanguageManager.Instance;

            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                data.ValueByLanguageType[languageManager.SupportLanguageTypes[i]] =
                    LanguageGeneric.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
            }
        }


        /// <summary>
        /// Load the view values from the given data.
        /// </summary>
        /// <param name="data">The data to load from.</param>
        public void Load(LanguageGeneric<TObject> data)
        {
            var languageManager = LanguageManager.Instance;

            for (int i = 0; i < languageManager.SupportLanguageLength; i++)
            {
                LanguageGeneric.ValueByLanguageType[languageManager.SupportLanguageTypes[i]] =
                           data.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
            }

            ObjectField.SetValueWithoutNotify
            (
                LanguageGeneric.ValueByLanguageType[languageManager.CurrentLanguage]
            );

            ObjectField.ToggleEmptyStyle();
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

                    ObjectField.ToggleEmptyStyle();
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

            ObjectField.ToggleEmptyStyle();
        }
    }
}