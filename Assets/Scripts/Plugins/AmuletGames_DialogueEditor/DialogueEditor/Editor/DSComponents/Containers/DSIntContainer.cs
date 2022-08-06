using System;
using UnityEditor.UIElements;

namespace AG
{
    [Serializable]
    public class IntContainer
    {
        /// <summary>
        /// The serialzable value from the container.
        /// </summary>
        public int Value;


        /// <summary>
        /// Visual element
        /// </summary>
        public IntegerField IntField;


        /// <summary>
        /// Setup the int field internally after it's been connected to the newly created one.
        /// </summary>
        public void SetupContainerField()
        {
            IntField.SetValueWithoutNotify(Value);
        }


        /// <summary>
        /// Overwrite the value of this container with the value that's from the source,
        /// and update the field to show the changes.
        /// </summary>
        /// <param name="source">Target container to load from.</param>
        public void LoadContainerValue(IntContainer source)
        {
            // Overwrite value
            Value = source.Value;

            // Set field's value without invoking field's value change event.
            IntField.SetValueWithoutNotify(Value);
        }


        /// <summary>
        /// Overwrite the value in this container with the one that are from the source.
        /// </summary>
        /// <param name="source">Target container to save from.</param>
        public void SaveContainerValue(IntContainer source)
        {
            // Save value
            Value = source.Value;
        }
    }
}