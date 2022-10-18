using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public abstract class EnumContainerBase
    {
        /// <summary>
        /// The serialzable enum index from the container.
        /// </summary>
        public int Value;

        /// <summary>
        /// Visual element
        /// </summary>
        public EnumField EnumField;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Overwrite the value of this container with the value that's from the source,
        /// and update the field to show the changes.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(EnumContainerBase source)
        {
            // Overwrite value
            Value = source.Value;
            
            // Set field's value without invoking field's value change event.
            SetFieldValueNonAlert(Value);
        }


        /// <summary>
        /// Overwrite the value in this container with the one that are from the source.
        /// </summary>
        /// <param name="source">Target container to save from.</param>
        public void SaveContainerValue(EnumContainerBase source)
        {
            // Save value
            Value = source.Value;
        }


        // ----------------------------- Init Field Value Tasks -----------------------------
        /// <summary>
        /// Initializes the EnumField with a default value, and initializes its underlying type.
        /// </summary>
        public abstract void InitFieldValue();


        // ----------------------------- Set Field Value Tasks -----------------------------
        /// <summary>
        /// Assign a new value to the enum field.
        /// <para>Changing the field using this method will not invoke the enum field's OnValueChangedEvent.</para>
        /// </summary>
        /// <param name="newValue">The new enum index to assign for the field, which'll be converted into the derived class's enum type.</param>
        public abstract void SetFieldValueNonAlert(int newValue);
    }
}