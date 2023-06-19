using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class CommonFloatFieldModel : IReversible
    {
        /// <summary>
        /// The serializable value of the model.
        /// <para></para>
        /// The value here is to prevent boxing/unboxing when we push it to the reversable stack.<see cref="StashData"/>,
        /// <br>instead of serializing the value from the field, which'll cause boxing,</br>
        /// <br>we'll serialize the model itself which the included the value.</br>
        /// </summary>
        [SerializeField] public float Value;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public UnityEngine.UIElements.FloatField FloatField;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the model values from the given data.
        /// </summary>
        /// <param name="data">The data to load from.</param>
        public void Load(float data)
        {
            Value = data;

            FloatField.SetValueWithoutNotify(data);
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

                if (obj is CommonFloatFieldModel reverseSource)
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