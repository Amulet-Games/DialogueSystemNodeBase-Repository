using UnityEngine.UIElements;

namespace AG
{
    public static class DSImagesMaker
    {
        /// <summary>
        /// Create a new image.
        /// </summary>
        /// <param name="USS01">The first style for the image to use when it appeared on the editor window.</param>
        /// <param name="USS02">The second style for the image to use when it appeared on the editor window.</param>
        /// <returns>A new image UIElement.</returns>
        public static Image GetNewImage(string USS01 = "", string USS02 = "")
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
                image.AddToClassList(USS01);
                image.AddToClassList(USS02);
            }
        }
    }
}