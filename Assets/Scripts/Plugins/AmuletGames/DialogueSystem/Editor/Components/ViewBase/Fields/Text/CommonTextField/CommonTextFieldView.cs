using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class CommonTextFieldView : IReversible
    {
        /// <summary>
        /// The text to show when the text field has no actual value in it.
        /// </summary>
        [NonSerialized] public string PlaceholderText;


        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public TextField TextField;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the common text field view class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public CommonTextFieldView(string placeholderText)
        {
            PlaceholderText = placeholderText;
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the container values from the given data.
        /// </summary>
        /// <param name="data">The data to load from.</param>
        public void Load(string data)
        {
            TextField.SetValueWithoutNotify(data);
            TextField.ToggleEmptyStyle(placeholderText: PlaceholderText);
        }


        // ----------------------------- IReversible -----------------------------
        /// <inheritdoc/>
        public byte[] StashData()
        {
            MemoryStream memoryStream = new();
            BinaryFormatter binaryFormatter = new();

            binaryFormatter.Serialize(memoryStream, TextField.value);
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