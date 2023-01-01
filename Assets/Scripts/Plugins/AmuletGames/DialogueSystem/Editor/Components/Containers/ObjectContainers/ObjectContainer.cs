using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEditor.UIElements;
using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ObjectContainer<TObject> : IReversible
        where TObject : UnityEngine.Object
    {
        /// <summary>
        /// The serializable value from the container.
        /// </summary>
        [SerializeField] public TObject Value;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public ObjectField ObjectField;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the container values from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        public void LoadContainerValue(TObject data)
        {
            // Load value.
            Value = data;

            // Load field.
            ObjectField.SetValueWithoutNotify(Value);

            // Toggle empty style.
            ObjectFieldHelper.ToggleEmptyStyle(ObjectField);
        }


        // ----------------------------- IReversible -----------------------------
        /// <inheritdoc/>
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize
            (
                serializationStream: memoryStream,
                graph: Value != null

                        // Serialize value's asset path.
                        ? AssetDatabase.GetAssetPath(Value)

                        // Serialize empty string.
                        : ""
            );

            memoryStream.Close();
            return memoryStream.ToArray();
        }


        /// <inheritdoc/>
        public void ReverseTo(byte[] array)
        {
            if (array != null)
            {
                // Load the stashed asset's value path and retrieve it from asset data base.
                var reverseValue = (TObject)AssetDatabase.LoadAssetAtPath
                (
                    assetPath: (string)new BinaryFormatter().Deserialize(new MemoryStream(array)),
                    type: typeof(TObject)
                );

                if (reverseValue != null)
                {
                    // Load value.
                    Value = reverseValue;

                    // Load field.
                    ObjectField.SetValueWithoutNotify(Value);

                    // Toggle empty style.
                    ObjectFieldHelper.ToggleEmptyStyle(ObjectField);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}