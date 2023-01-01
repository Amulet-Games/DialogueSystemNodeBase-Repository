using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class FoldoutContainer : IReversible
    {
        /// <summary>
        /// The serializable value from the container.
        /// </summary>
        [SerializeField] public bool Value;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public Foldout Foldout;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the container values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadContainerValue(bool data)
        {
            // Load value.
            Value = data;

            // Load foldout.
            Foldout.SetValueWithoutNotify(data);
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

                if (obj is FoldoutContainer reverseSource)
                {
                    // Load value.
                    Value = reverseSource.Value;

                    // Load foldout.
                    Foldout.SetValueWithoutNotify(Value);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }

        }
    }
}