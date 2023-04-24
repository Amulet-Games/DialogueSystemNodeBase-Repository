using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class CommonObjectFieldModel<TObject> : IReversible
        where TObject : UnityEngine.Object
    {
        /// <summary>
        /// The serializable value from the model.
        /// </summary>
        [SerializeField] public TObject Value;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public ObjectField ObjectField;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the model values from the given data.
        /// </summary>
        /// <param name="data">The data to load from.</param>
        public void Load(TObject data)
        {
            Value = data;

            ObjectField.SetValueWithoutNotify(Value);

            ObjectField.ToggleEmptyStyle();
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
                        ? AssetDatabase.GetAssetPath(Value)
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
                    Load(data: reverseValue);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}