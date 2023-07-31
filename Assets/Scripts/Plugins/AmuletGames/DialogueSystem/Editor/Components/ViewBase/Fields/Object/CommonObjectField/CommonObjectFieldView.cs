using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class CommonObjectFieldView<TObject> : IReversible
        where TObject : UnityEngine.Object
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public ObjectField ObjectField;


        /// <summary>
        /// The text to display when the field is empty.
        /// </summary>
        [NonSerialized] public string PlaceholderText;


        /// <summary>
        /// The serializable value of the field.
        /// </summary>
        [SerializeField] public TObject Value;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the common object field view class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public CommonObjectFieldView(string placeholderText)
        {
            PlaceholderText = placeholderText;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the view values from the given value.
        /// </summary>
        /// <param name="value">The value to set for.</param>
        public void Load(TObject value)
        {
            Value = value;

            ObjectField.SetValueWithoutNotify(Value);

            ObjectField.ToggleEmptyStyle(PlaceholderText);
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
                    Load(value: reverseValue);
                }
                else
                {
                    throw new ApplicationException($"Unable to deserialize reversible byte[] data, \"{GetType()}\"");
                }
            }
        }
    }
}