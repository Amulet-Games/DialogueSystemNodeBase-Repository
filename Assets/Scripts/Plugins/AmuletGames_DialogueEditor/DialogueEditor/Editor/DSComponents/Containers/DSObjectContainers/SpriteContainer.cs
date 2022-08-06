using System;
using UnityEditor.UIElements;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class SpriteContainer : ObjectContainer<Sprite>
    {
        /// <summary>
        /// Overwrite the value of this container with the value that's from the source,
        /// and update the field to show the changes,
        /// and update the field's style depends on if it's empty or not.
        /// </summary>
        /// <param name="source">Target container to load from</param>
        public void LoadContainerValue(SpriteContainer source)
        {
            // Overwrite value
            Value = source.Value;

            // Set field's value without invoking field's value change event.
            ObjectField.SetValueWithoutNotify(Value);

            // USS
            DSObjectFieldUtility.ToggleEmptyStyle(ObjectField);
        }
    }
}