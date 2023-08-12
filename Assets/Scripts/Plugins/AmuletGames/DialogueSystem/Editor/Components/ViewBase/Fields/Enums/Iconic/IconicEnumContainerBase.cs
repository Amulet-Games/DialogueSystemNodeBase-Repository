using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public abstract class IconicEnumFieldViewBase : IReversible
    {
        /// <summary>
        /// The serializable enum index from the container.
        /// </summary>
        [SerializeField] public int Value;


        /// <summary>
        /// The image element to use for the enum field's icon.
        /// </summary>
        [NonSerialized] public Image Icon;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public EnumField EnumField;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the container values from the given value.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(int value)
        {
            // Load value.
            Value = value;

            // Load field.
            UpdateFieldValueNonAlert();

            // Update icon.
            UpdateIcon();
        }


        // ----------------------------- Init Field Value -----------------------------
        /// <summary>
        /// Initializes the field default value and its underlying type.
        /// </summary>
        public abstract void InitFieldValue();


        // ----------------------------- Update Field Value -----------------------------
        /// <summary>
        /// Update the enum field's value to match the container's current value without
        /// <br>invoking the field's valueChangedEvent.</br>
        /// </summary>
        public abstract void UpdateFieldValueNonAlert();


        // ----------------------------- Update Icon -----------------------------
        /// <summary>
        /// Reset the icon to match the current field's value.
        /// </summary>
        public abstract void UpdateIcon();


        // ----------------------------- Service -----------------------------
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

                if (obj is IconicEnumFieldViewBase reverseSource)
                {
                    // Load value.
                    Value = reverseSource.Value;

                    // Load field.
                    UpdateFieldValueNonAlert();

                    // Update icon.
                    UpdateIcon();
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}