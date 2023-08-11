using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class FolderTitleTextFieldView : IReversible
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public TextField Field;


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
                if (value != "")
                {
                    m_value = value;
                }

                Field.SetValueWithoutNotify(m_value);
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// </summary>
        [SerializeField] string m_value;


        /// <summary>
        /// Constructor of the node title text field view class.
        /// </summary>
        /// <param name="value">The value of the view to set for.</param>
        public FolderTitleTextFieldView(string value)
        {
            m_value = value;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the view values from the given value.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(string value)
        {
            Value = value;
        }


        // ----------------------------- IReversible -----------------------------
        /// <inheritdoc/>
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize(memoryStream, Field.value);
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