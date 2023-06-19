using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public abstract class EnumFieldModelBase : IReversible
    {
        /// <summary>
        /// The serializable enum index from the model.
        /// </summary>
        [SerializeField] public int Value;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public UnityEngine.UIElements.EnumField EnumField;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the model values from the given data.
        /// </summary>
        /// <param name="data">The data to load from.</param>
        public void Load(int data)
        {
            // Load value.
            Value = data;

            // Load field.
            UpdateFieldValueNonAlert();
        }


        // ----------------------------- Init Field Value -----------------------------
        /// <summary>
        /// Initializes the field default value and its underlying type.
        /// </summary>
        public abstract void InitFieldValue();


        // ----------------------------- Update Field Value -----------------------------
        /// <summary>
        /// Update the enum field's value to match the model's current value without
        /// <br>invoking the field's valueChangedEvent.</br>
        /// </summary>
        public abstract void UpdateFieldValueNonAlert();


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

                if (obj is EnumFieldModelBase reverseSource)
                {
                    // Load value.
                    Value = reverseSource.Value;

                    // Load field.
                    UpdateFieldValueNonAlert();
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}