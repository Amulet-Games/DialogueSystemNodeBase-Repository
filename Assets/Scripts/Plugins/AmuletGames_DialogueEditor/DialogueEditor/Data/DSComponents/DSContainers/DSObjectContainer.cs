using System;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using Object = UnityEngine.Object;

namespace AG
{
    public class ObjectContainer<T> where T : Object
    {
        public T Value;

#if UNITY_EDITOR
        /// <summary>
        /// Visual element
        /// </summary>
        public ObjectField ObjectField;

        /// <summary>
        /// Setup the object field internally after it's been connected to the newly created one.
        /// </summary>
        public void SetupContainerField()
        {
            ObjectField.objectType = typeof(T);
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
        public void LoadContainerValue(ObjectContainer<T> source)
        {
            // Overwrite value
            Value = source.Value;

            // Set field's value without invoking field's value change event.
            ObjectField.SetValueWithoutNotify(Value);

            // USS
            DSObjectFieldUtility.ToggleEmptyStyle(ObjectField);
        }

        /// <summary>
        /// Overwrite the target container's value with the value that's from this container.
        /// </summary>
        /// <param name="saveToContainer">Target container to save toward.</param>
        public void SaveContainerValue(ObjectContainer<T> saveToContainer)
        {
            // Save value
            saveToContainer.Value = Value;
        }
#endif
    }

    [Serializable]
    public class SpriteObjectContainer : ObjectContainer<Sprite>
    {
#if UNITY_EDITOR
        /// <summary>
        /// Overwrite the value of this container with the value that's from the source,
        /// and update the field to show the changes,
        /// and update the field's style depends on if it's empty or not.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(SpriteObjectContainer source)
        {
            // Overwrite value
            Value = source.Value;

            // Set field's value without invoking field's value change event.
            ObjectField.SetValueWithoutNotify(Value);

            // USS
            DSObjectFieldUtility.ToggleEmptyStyle(ObjectField);
        }
#endif
    }
}