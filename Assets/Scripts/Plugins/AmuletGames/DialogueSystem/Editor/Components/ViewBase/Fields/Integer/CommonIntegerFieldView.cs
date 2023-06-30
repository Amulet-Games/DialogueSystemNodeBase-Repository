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
        /// The serializable value of the view.
        /// <para></para>
        /// The value here is to prevent boxing/unboxing when we push it to the reversible stack.<see cref="StashData"/>,
        /// <br>instead of serializing the value from the field, which will cause boxing,</br>
        /// <br>we'll serialize the view itself which the included the value.</br>
        /// </summary>
        [SerializeField] public int Value;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public IntegerField IntegerField;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the view values from the given value.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(int value)
        {
            Value = value;

            IntegerField.SetValueWithoutNotify(Value);
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