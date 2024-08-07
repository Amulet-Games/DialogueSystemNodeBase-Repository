using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class LanguageObjectFieldView<TObject> : IReversible, ILanguageFieldView
        where TObject : UnityEngine.Object
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public ObjectField Field;


        /// <summary>
        /// The text to display when the field is empty.
        /// </summary>
        [NonSerialized] string placeholderText;


        /// <summary>
        /// The property of the view's value that matches the current dialogue system window's language.
        /// </summary>
        public TObject CurrentLanguageValue
        {
            get
            {
                return LanguageValue.ValueByLanguageType[LanguageHandler.CurrentLanguage];
            }
            set
            {
                LanguageValue.ValueByLanguageType[LanguageHandler.CurrentLanguage] = value;
                UpdateFieldLanguageValue();
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// </summary>
        [SerializeField] public LanguageGeneric<TObject> LanguageValue { get; }


        /// <summary>
        /// Reference of the language handler.
        /// </summary>
        [NonSerialized] public LanguageHandler LanguageHandler;


        /// <summary>
        /// Constructor of the language object field view class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        /// <param name="languageHandler">The language handler to set for.</param>
        public LanguageObjectFieldView
        (
            string placeholderText,
            LanguageHandler languageHandler
        )
        {
            this.placeholderText = placeholderText;
            LanguageHandler = languageHandler;
            LanguageValue = new();
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the view values.
        /// </summary>
        /// <param name="value">The language generic component to set for.</param>
        public void Save(LanguageGeneric<TObject> value)
        {
            value.Save(LanguageValue);
        }


        /// <summary>
        /// Load the view values.
        /// </summary>
        /// <param name="value">The language generic component to set for.</param>
        public void Load(LanguageGeneric<TObject> value)
        {
            LanguageValue.Load(value);

            UpdateFieldLanguageValue();
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Update the field value to match the current view's language value.
        /// </summary>
        public void UpdateFieldLanguageValue()
        {
            Field.SetValueWithoutNotify(CurrentLanguageValue);
            Field.ToggleEmptyStyle(placeholderText);
            
            if (CurrentLanguageValue != null)
            {
                Field.Bind(obj: new SerializedObject(CurrentLanguageValue));
            }
            else
            {
                Field.Unbind();
            }
        }


        /// <inheritdoc/>
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize
            (
                serializationStream: memoryStream,
                graph: Field.value != null
                        ? AssetDatabase.GetAssetPath(Field.value)
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