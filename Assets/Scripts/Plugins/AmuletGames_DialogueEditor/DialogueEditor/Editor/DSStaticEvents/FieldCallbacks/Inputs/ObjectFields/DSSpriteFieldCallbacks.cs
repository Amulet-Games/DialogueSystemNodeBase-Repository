using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSSpriteFieldCallbacks : DSObjectFieldCallbacks
    {
        /// <summary>
        /// Add a new callback action to the base ValueChangedEvent,
        /// <br>The field will update the specified image visual element as well each time its value is changed.</br>
        /// </summary>
        /// <param name="objectContainer">The Object container of which the field is connecting to.</param>
        /// <param name="referedImage">The image of which this field is connecting to and will get updated.</param>
        public static void AddValueChangedListeners
        (
            DSObjectContainer<Sprite> objectContainer,
            Image referedImage
        )
        {
            objectContainer.ObjectField.RegisterValueChangedCallback(value =>
            {
                DSImageUtility.UpdateImagePreview(objectContainer.Value, referedImage);
            });
        }
    }
}