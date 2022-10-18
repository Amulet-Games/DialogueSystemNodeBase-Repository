using System;
using UnityEditor.UIElements;

namespace AG
{
    [Serializable]
    public class FloatContainer
    {
        /// <summary>
        /// The serialzable value from the container.
        /// </summary>
        public float Value;


        /// <summary>
        /// Visual element
        /// </summary>
        public FloatField FloatField;


        /// <summary>
        /// Overwrite the value of this container with the value that's from the source,
        /// and update the field to show the changes.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(FloatContainer source)
        {
            // Overwrite value
            Value = source.Value;

            // Set field's value without invoking field's value change event.
            FloatField.SetValueWithoutNotify(Value);

            // Add the field to empty style class if its value is empty.
            DSFloatFieldUtility.ToggleEmptyStyle(FloatField);
        }


        /// <summary>
        /// Overwrite the value in this container with the one that are from the source.
        /// </summary>
        /// <param name="source">Target container to save from.</param>
        public void SaveContainerValue(FloatContainer source)
        {
            // Save value
            Value = source.Value;
        }
    }
}