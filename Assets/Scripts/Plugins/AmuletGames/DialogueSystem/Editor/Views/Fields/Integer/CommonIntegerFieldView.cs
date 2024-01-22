using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class CommonIntegerFieldView : IReversible
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public IntegerField Field;


        /// <summary>
        /// The maximum value that can be set to the field.
        /// </summary>
        [NonSerialized] int? maxValue;


        /// <summary>
        /// The minimum value that can be set to the field.
        /// </summary>
        [NonSerialized] int? minValue;


        /// <summary>
        /// The property of the serializable value of the view.
        /// </summary>
        public int Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (maxValue != null && value > maxValue)
                {
                    value = (int)maxValue;
                }
                else if (minValue != null && value < minValue)
                {
                    value = (int)minValue;
                }

                m_value = value;

                Field.SetValueWithoutNotify(m_value);
                Field.ToggleEmptyStyle();
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// <para></para>
        /// The value here is to prevent boxing/unboxing when we push it to the reversible stack.<see cref="StashData"/>,
        /// <br>instead of serializing the value from the field, which will cause boxing, we'll serialize the view itself.</br>
        /// </summary>
        [SerializeField] int m_value;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the view values.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(int value)
        {
            Value = value;
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc/>
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize(memoryStream, this);
            memoryStream.Close();

            return memoryStream.ToArray();
        }


        /// <inheritdoc/>
        public void ReverseTo(byte[] array)
        {
            if (array != null)
            {
                object obj = new BinaryFormatter().Deserialize(new MemoryStream(array));

                if (obj is CommonIntegerFieldView reverseSource)
                {
                    Load(value: reverseSource.Value);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}