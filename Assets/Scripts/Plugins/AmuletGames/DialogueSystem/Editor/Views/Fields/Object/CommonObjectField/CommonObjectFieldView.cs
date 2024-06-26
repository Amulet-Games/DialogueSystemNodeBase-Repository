using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class CommonObjectFieldView<TObject> : IReversible
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
                return m_value;
            }
            set
            {
                m_value = value;

                Field.SetValueWithoutNotify(m_value);
                Field.ToggleEmptyStyle(placeholderText);
                
                if (m_value != null)
                {
                    Field.Bind(obj: new SerializedObject(m_value));
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
        [SerializeField] TObject m_value;


        /// <summary>
        /// Constructor of the common object field view class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public CommonObjectFieldView(string placeholderText)
        {
            this.placeholderText = placeholderText;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the view values.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(TObject value)
        {
            Value = value;
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc/>
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize
            (
                serializationStream: memoryStream,
                graph: Value != null
                        ? AssetDatabase.GetAssetPath(Value)
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
                    Load(value: reverseValue);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}