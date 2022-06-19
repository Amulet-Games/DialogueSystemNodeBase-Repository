using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class DSObjectFieldUtility
    {
        /// <summary>
        /// If object field is currently empty then use a special USS style for the field label.
        /// </summary>
        /// <param name="objectField">The object field of which the empty style is applying to.</param>
        public static void ToggleEmptyStyle(ObjectField objectField)
        {
            if (objectField.value != null)
            {
                objectField.RemoveFromClassList(DSStylesConfig.nodeShare_ObjectField_Empty);
            }
            else
            {
                objectField.AddToClassList(DSStylesConfig.nodeShare_ObjectField_Empty);
            }
        }

        /// <summary>
        /// Update the image element's texture to match the sprite's texture.
        /// </summary>
        /// <param name="sprite">The sprite to use to overwrite the image element's image with.</param>
        /// <param name="image">The image element of which it's image will be overwrited.</param>
        public static void UpdateImagePreview(Sprite sprite, Image imageElement)
        {
            imageElement.image = sprite != null ? sprite.texture : null;
        }
    }
}