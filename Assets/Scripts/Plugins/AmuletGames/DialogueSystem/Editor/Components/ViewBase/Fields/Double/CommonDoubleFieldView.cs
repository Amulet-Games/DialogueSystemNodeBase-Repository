using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class CommonDoubleFieldView : IReversible
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public DoubleField Field;


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
        public double Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (maxValue != null && value > maxValue)
                {
                    value = (double)maxValue;
                }
                else if (minValue != null && value < minValue)
                {
                    value = (double)minValue;
                }

                m_value = Math.Round(value, 2);

                Field.SetValueWithoutNotify(m_value);
                Field.ToggleEmptyStyle();
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// <para></para>
        /// The value here is to prevent boxing/unboxing when we push it to the reversible stack.<see cref="StashData"/>,
        /// <br>instead of serializing the value from the field, which will cause boxing,</br>
        /// <br>we'll serialize the view itself which the included the value.</br>
        /// </summary>
        [SerializeField] double m_value;


        /// <summary>
        /// Constructor of the common double field view class.
        /// </summary>
        /// <param name="maxValue">The max value to set for.</param>
        /// <param name="minValue">The min value to set for.</param>
        public CommonDoubleFieldView
        (
            int? maxValue = null,
            int? minValue = null
        )
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the view values from the given value.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(double value)
        {
            Value = value;
        }


        // ----------------------------- IReversible -----------------------------
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

                if (obj is CommonDoubleFieldView reverseSource)
                {
                    Load(reverseSource.Value);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}