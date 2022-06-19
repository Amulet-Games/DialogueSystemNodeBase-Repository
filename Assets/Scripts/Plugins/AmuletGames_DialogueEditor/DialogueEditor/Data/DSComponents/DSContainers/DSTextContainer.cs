using System;
using UnityEngine.UIElements;

namespace AG
{
    public abstract class TextContainerBase
    {
        public string PlaceholderText;

#if UNITY_EDITOR
        /// <summary>
        /// Visual element
        /// </summary>
        public TextField TextField;
#endif
    }

    [Serializable]
    public class TextContainer : TextContainerBase
    {
        public string Value;

#if UNITY_EDITOR
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

            // Set fields value to placeholder text if the field is empty.
            DSTextFieldUtility.ToggleEmptyStyle(this);
        }

        /// <summary>
        /// Overwrite the target container's value with the value that's from this container.
        /// </summary>
        /// <param name="saveToContainer">Target container to save toward.</param>
        public void SaveContainerValue(TextContainer saveToContainer)
        {
            // Save value
            saveToContainer.Value = Value;
        }
#endif
    }
}