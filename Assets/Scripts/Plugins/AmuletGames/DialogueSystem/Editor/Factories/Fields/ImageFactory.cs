using UnityEngine.UIElements;

namespace AG.DS
{
    public static class ImageFactory
    {
        /// <summary>
        /// Returns a new image UIElement.
        /// </summary>
        /// <param name="imageUSS01">The first USS style to set for the image.</param>
        /// <param name="imageUSS02">The second USS style to set for the image.</param>
        /// <returns>A new image UIElement.</returns>
        public static Image GetNewImage
        (
            string imageUSS01 = "",
            string imageUSS02 = ""
        )
        {
            Image image;

            SetupImage();

            AddImageToStyleClass();

            return image;

            void SetupImage()
            {
                image = new Image();
            }

            void AddImageToStyleClass()
            {
                image.AddToClassList(imageUSS01);
                image.AddToClassList(imageUSS02);
            }
        }
    }
}