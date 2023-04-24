using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonImagePresenter
    {
        /// <summary>
        /// Method for creating a new common Image UIElement.
        /// </summary>
        /// <param name="pickingMode">The picking mode to set for the image.</param>
        /// <param name="imageSprite">The displaying sprite to set for the image.</param>
        /// <param name="imageUSS01">The first USS style to set for the image.</param>
        /// <param name="imageUSS02">The second USS style to set for the image.</param>
        /// <returns>A new common Image UIElement.</returns>
        public static Image CreateElements
        (
            PickingMode pickingMode = PickingMode.Ignore,
            Sprite imageSprite = null,
            string imageUSS01 = null,
            string imageUSS02 = null
        )
        {
            Image image;

            CreateImage();

            SetupDetails();

            AddImageToStyleClass();

            return image;

            void CreateImage()
            {
                image = new();
            }

            void SetupDetails()
            {
                if (imageSprite != null)
                    image.sprite = imageSprite;

                image.pickingMode = pickingMode;
            }

            void AddImageToStyleClass()
            {
                if (imageUSS01 != null)
                    image.AddToClassList(imageUSS01);

                if (imageUSS02 != null)
                    image.AddToClassList(imageUSS02);
            }
        }
    }
}