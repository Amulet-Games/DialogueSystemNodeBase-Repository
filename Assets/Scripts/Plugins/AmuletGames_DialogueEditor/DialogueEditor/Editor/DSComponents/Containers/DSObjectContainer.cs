using System;
using UnityEditor.UIElements;
using Object = UnityEngine.Object;

namespace AG
{
    [Serializable]
    public class DSObjectContainer<TObject>
        where TObject : Object
    {
        /// <summary>
        /// The serialzable value from the container.
        /// </summary>
        public TObject Value;


        /// <summary>
        /// Visual element.
        /// </summary>
        public ObjectField ObjectField;


        /// <summary>
        /// Overwrite the value of this container with the value that's from the source,
        /// and update the field to show the changes,
        /// and update the field's style depends on if it's empty or not.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(DSObjectContainer<TObject> source)
        {
            // Overwrite value
            Value = source.Value;

            // Set field's value without invoking field's value change event.
            ObjectField.SetValueWithoutNotify(Value);

            // USS
            DSObjectFieldUtility.ToggleEmptyStyle(ObjectField);
        }


        /// <summary>
        /// Overwrite the value in this container with the one that are from the source.
        /// </summary>
        /// <param name="source">Target container to save from.</param>
        public void SaveContainerValue(DSObjectContainer<TObject> source)
        {
            // Save value
            Value = source.Value;
        }
    }
}