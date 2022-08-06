using UnityEditor.UIElements;
using Object = UnityEngine.Object;

namespace AG
{
    public class ObjectContainer<TObject> where TObject : Object
    {
        /// <summary>
        /// The serialzable value from the container.
        /// </summary>
        public TObject Value;


        /// <summary>
        /// Visual element
        /// </summary>
        public ObjectField ObjectField;


        /// <summary>
        /// Setup the object field internally after it's been connected to the newly created one.
        /// </summary>
        public void SetupContainerField()
        {
            ObjectField.objectType = typeof(TObject);
            ObjectField.allowSceneObjects = false;

            ObjectField.value = Value;

            // Update field's empty style
            DSObjectFieldUtility.ToggleEmptyStyle(ObjectField);
        }


        /// <summary>
        /// Overwrite the value of this container with the value that's from the source,
        /// and update the field to show the changes,
        /// and update the field's style depends on if it's empty or not.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(ObjectContainer<TObject> source)
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
        public void SaveContainerValue(ObjectContainer<TObject> source)
        {
            // Save value
            Value = source.Value;
        }
    }
}