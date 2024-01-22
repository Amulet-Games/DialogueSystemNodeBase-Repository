using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public abstract class EnumFieldViewBase : IReversible
    {
        /// <summary>
        /// The serializable enum index from the view.
        /// </summary>
        [SerializeField] public int Value;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public UnityEngine.UIElements.EnumField EnumField;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the view values.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(int value)
        {
            // Load value.
            Value = value;

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
        /// Update the enum field's value to match the view's current value without
        /// <br>invoking the field's valueChangedEvent.</br>
        /// </summary>
        public abstract void UpdateFieldValueNonAlert();


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

                if (obj is EnumFieldViewBase reverseSource)
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