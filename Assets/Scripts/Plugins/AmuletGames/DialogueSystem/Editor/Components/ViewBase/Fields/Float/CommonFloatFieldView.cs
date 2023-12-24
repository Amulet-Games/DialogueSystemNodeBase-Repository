using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class CommonFloatFieldView : IReversible
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public FloatField Field;


        /// <summary>
        /// The maximum value that can be set to the field.
        /// </summary>
        [NonSerialized] float? maxValue;


        /// <summary>
        /// The minimum value that can be set to the field.
        /// </summary>
        [NonSerialized] float? minValue;


        /// <summary>
        /// The property of the serializable value of the view.
        /// </summary>
        public float Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (maxValue != null && value > maxValue)
                {
                    value = (float)maxValue;
                }
                else if (minValue != null && value < minValue)
                {
                    value = (float)minValue;
                }

                if (roundDigits != -1)
                {
                    value = MathF.Round(value, roundDigits, MidpointRounding.AwayFromZero);
                }

                m_value = value;

                Field.SetValueWithoutNotify(m_value);
                Field.ToggleEmptyStyle();
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// <br>If rounding is applied, the type will be MidpointRounding.AwayFromZero.</br>
        /// <para></para>
        /// The value here is to prevent boxing/unboxing when we push it to the reversible stack.<see cref="StashData"/>,
        /// <br>instead of serializing the value from the field, which will cause boxing,we'll serialize the view itself. </br>
        /// </summary>
        [SerializeField] float m_value;


        /// <summary>
        /// The number of fractional digits to which the serializable value will be rounded to and saved.
        /// <br>if the value is -1, the serializable value won't be rounded.</br>
        /// </summary>
        int roundDigits;


        /// <summary>
        /// Constructor of the common float field view class.
        /// </summary>
        /// <param name="maxValue">The max value to set for.</param>
        /// <param name="minValue">The min value to set for.</param>
        /// <param name="roundDigits">The round digits to set for.</param>
        public CommonFloatFieldView
        (
            int? maxValue = null,
            int? minValue = null,
            int roundDigits = -1
        )
        {
            this.maxValue = maxValue;
            this.minValue = minValue;
            this.roundDigits = roundDigits;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the view values.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(float value)
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

                if (obj is CommonFloatFieldView reverseSource)
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