using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSImageUtility
    {
        /// <summary>
        /// Update the image element's texture to match the sprite's texture.
        /// </summary>
        /// <param name="sprite">The sprite to use to overwrite the image element's image with.</param>
        /// <param name="image">The image element of which it's image will be overwrited.</param>
        public static void UpdateImagePreview(Sprite sprite, Image image)
        {
            image.image = sprite != null ? sprite.texture : null;
        }
    }
}