using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class FloatContainer : ContainerFrameBase
    {
        /// <summary>
        /// The serialzable value from the container.
        /// </summary>
        [SerializeField] public float Value;


        /// <summary>
        /// Visual element
        /// </summary>
        [NonSerialized] public FloatField FloatField;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the container values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadContainerValue(float data)
        {
            // Load value.
            Value = data;

            // Load field.
            FloatField.SetValueWithoutNotify(Value);

            // Toggle empty style.
            FloatFieldHelper.ToggleEmptyStyle(FloatField);
        }


        // ----------------------------- IReversible -----------------------------
        /// <inheritdoc/>
        public override byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize(memoryStream, this);
            memoryStream.Close();

            return memoryStream.ToArray();
        }


        /// <inheritdoc/>
        public override void ReverseTo(byte[] array)
        {
            if (array != null)
            {
                object obj = new BinaryFormatter().Deserialize(new MemoryStream(array));

                if (obj is FloatContainer reverseSource)
                {
                    // Load value.
                    Value = reverseSource.Value;

                    // Load field.
                    FloatField.SetValueWithoutNotify(Value);

                    // Toggle empty style.
                    FloatFieldHelper.ToggleEmptyStyle(FloatField);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}