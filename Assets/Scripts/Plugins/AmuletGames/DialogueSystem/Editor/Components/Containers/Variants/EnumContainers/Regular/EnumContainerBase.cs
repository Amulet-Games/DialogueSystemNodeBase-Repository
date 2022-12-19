using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEditor.UIElements;
using UnityEngine;


namespace AG.DS
{
    [Serializable]
    public abstract class EnumContainerBase : ContainerFrameBase
    {
        /// <summary>
        /// The serialzable enum index from the container.
        /// </summary>
        [SerializeField] public int Value;


        /// <summary>
        /// Visual element
        /// </summary>
        [NonSerialized] public EnumField EnumField;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the container values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadContainerValue(int data)
        {
            // Load value.
            Value = data;

            // Load field.
            UpdateFieldValueNonAlert();
        }


        // ----------------------------- Init Field Value Tasks -----------------------------
        /// <summary>
        /// Initializes the field default value and its underlying type.
        /// </summary>
        public abstract void InitFieldValue();


        // ----------------------------- Update Field Value Tasks -----------------------------
        /// <summary>
        /// Update the enum field's value to match the container's current value without
        /// <br>invoking the field's valueChangedEvent.</br>
        /// </summary>
        public abstract void UpdateFieldValueNonAlert();


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

                if (obj is EnumContainerBase reverseSource)
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