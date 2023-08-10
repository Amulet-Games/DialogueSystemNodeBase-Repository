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
        [NonSerialized] public ObjectField Field;


        /// <summary>
        /// The text to display when the field is empty.
        /// </summary>
        [NonSerialized] string placeholderText;


        /// <summary>
        /// The property of the serializable value of the view.
        /// </summary>
        public TObject Value
        {
            get
            {
                return m_value.ValueByLanguageType[LanguageManager.Instance.CurrentLanguage];
            }
            set
            {
                m_value.ValueByLanguageType[LanguageManager.Instance.CurrentLanguage] = value;

                Field.SetValueWithoutNotify(value);
                Field.ToggleEmptyStyle(placeholderText);

                if (m_value != null)
                {
                    Field.Bind(obj: new SerializedObject(value));
                }
                else
                {
                    Field.Unbind();
                }
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// </summary>
        [SerializeField] LanguageGeneric<TObject> m_value;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the language object field view class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public LanguageObjectFieldView(string placeholderText)
        {
            this.placeholderText = placeholderText;

            m_value = new();
            for (int i = 0; i < LanguageManager.Instance.SupportLanguageLength; i++)
            {
                m_value.ValueByLanguageType[LanguageManager.Instance.SupportLanguageTypes[i]] = null;
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
                    m_value.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
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
                m_value.ValueByLanguageType[languageManager.SupportLanguageTypes[i]] =
                           value.ValueByLanguageType[languageManager.SupportLanguageTypes[i]];
            }

            Value = value.ValueByLanguageType[LanguageManager.Instance.CurrentLanguage];
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
                    Value = reverseValue;
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}