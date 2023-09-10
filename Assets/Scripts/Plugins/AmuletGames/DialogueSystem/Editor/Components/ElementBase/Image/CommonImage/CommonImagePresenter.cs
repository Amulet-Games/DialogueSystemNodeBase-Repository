using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonImagePresenter
    {
        /// <summary>
        /// Create a new common Image element.
        /// </summary>
        /// <param name="imageSprite">The image sprite to set for.</param>
        /// <param name="imageUSS01">The first image USS style to set for.</param>
        /// <param name="imageUSS02">The second image USS style to set for.</param>
        /// <returns>A new common Image element.</returns>
        public static Image CreateElement
        (
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

                image.pickingMode = PickingMode.Ignore;
            }

            void AddImageToStyleClass()
            {
                image.ClearClassList();

                if (imageUSS01 != null)
                    image.AddToClassList(imageUSS01);

                if (imageUSS02 != null)
                    image.AddToClassList(imageUSS02);
            }
        }
    }
}