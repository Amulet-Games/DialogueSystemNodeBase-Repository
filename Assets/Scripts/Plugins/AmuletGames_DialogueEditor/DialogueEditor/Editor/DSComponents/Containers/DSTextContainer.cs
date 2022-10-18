using System;
using UnityEngine.UIElements;

namespace AG
{
    public abstract class TextContainerBase
    {
        /// <summary>
        /// The text that'll show up in the field when there's no actual content within it.
        /// </summary>
        public string PlaceholderText;


        /// <summary>
        /// Visual element
        /// </summary>
        public TextField TextField;
    }

    [Serializable]
    public class TextContainer : TextContainerBase
    {
        /// <summary>
        /// The serialzable value from the container.
        /// </summary>
        public string Value;


        /// <summary>
        /// Overwrite the value of this container with the value that's from the source,
        /// and update the field to show the changes.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(TextContainer source)
        {
            // Overwrite value
            Value = source.Value;

            // Set field's value without invoking field's value change event.
            TextField.SetValueWithoutNotify(Value);

            // Add the field to empty style class if it's content is empty.
            DSTextFieldUtility.ToggleEmptyStyle(this);
        }


        /// <summary>
        /// Overwrite the value in this container with the one that are from the source.
        /// </summary>
        /// <param name="source">Target container to save from.</param>
        public void SaveContainerValue(TextContainer source)
        {
            // Save value
            Value = source.Value;
        }
    }
}