using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class TextContainer : TextContainerBase, IReversible
    {
        /// <summary>
        /// The serializable value from the container.
        /// </summary>
        [SerializeField] public string Value;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the container values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadContainerValue(string data)
        {
            // Load value.
            Value = data;

            // Load field.
            TextField.SetValueWithoutNotify(Value);

            // Toggle empty style.
            TextFieldHelper.ToggleEmptyStyle(this);
        }


        // ----------------------------- IReversible -----------------------------
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
                    // Load value.
                    Value = reverseValue;

                    // Load field.
                    TextField.SetValueWithoutNotify(Value);

                    // Toggle empty style.
                    TextFieldHelper.ToggleEmptyStyle(this);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}