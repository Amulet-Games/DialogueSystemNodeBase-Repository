using System;
using UnityEditor.UIElements;

namespace AG
{
    [Serializable]
    public class FloatContainer
    {
        public float Value;

#if UNITY_EDITOR
        /// <summary>
        /// Visual element
        /// </summary>
        public FloatField FloatField;

        /// <summary>
        /// Setup the float field internally after it's been connected to the newly created one.
        /// </summary>
        public void SetupContainerField()
        {
            FloatField.SetValueWithoutNotify(Value);
        }

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
        }

        /// <summary>
        /// Overwrite the target container's value with the value that's from this container.
        /// </summary>
        /// <param name="saveToContainer">Target container to save toward.</param>
        public void SaveContainerValue(FloatContainer saveToContainer)
        {
            // Save value
            saveToContainer.Value = Value;
        }
#endif
    }
}