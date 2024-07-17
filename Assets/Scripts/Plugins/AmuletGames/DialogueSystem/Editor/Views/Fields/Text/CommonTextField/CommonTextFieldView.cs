using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class CommonTextFieldView : IReversible
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
        /// The property of the serializable value of the view.
        /// </summary>
        public string Value
        {
            get
            {
                return m_value;
            }
            set
            {
                IsEmpty = value.IsNullOrWhiteSpace();

                m_value = IsEmpty ? "" : value; 

                Field.SetValueWithoutNotify(m_value);

                this.ToggleEmptyStyle();
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// </summary>
        [SerializeField] string m_value;


        /// <summary>
        /// Returns true if the view's field is currently empty.
        /// </summary>
        public bool IsEmpty { get; private set; }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the view values.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(string value)
        {
            Value = value;
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc/>
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize(memoryStream, Value);
            memoryStream.Close();

            return memoryStream.ToArray();
        }


        /// <inheritdoc/>
        public void ReverseTo(byte[] array)
        {
            if (array != null)
            {
                object obj = new BinaryFormatter().Deserialize(new MemoryStream(array));

                if (obj is string reverseValue)
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