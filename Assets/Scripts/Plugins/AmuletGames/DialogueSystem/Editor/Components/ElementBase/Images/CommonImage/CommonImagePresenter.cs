using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonImagePresenter
    {
        /// <summary>
        /// Method for creating a new common Image element.
        /// </summary>
        /// <param name="pickingMode">The picking mode to set for the image.</param>
        /// <param name="imageSprite">The displaying sprite to set for the image.</param>
        /// <param name="imageUSS01">The first USS style to set for the image.</param>
        /// <param name="imageUSS02">The second USS style to set for the image.</param>
        /// <returns>A new common Image element.</returns>
        public static Image CreateElement
        (
            PickingMode pickingMode = PickingMode.Ignore,
            Sprite imageSprite = null,
            string imageUSS01 = null,
            string imageUSS02 = null
        )
        {
            Image image;

            CreateImage();

            SetupDetail();

            AddImageToStyleClass();

            return image;

            void CreateImage()
            {
                image = new();
            }

            void SetupDetail()
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