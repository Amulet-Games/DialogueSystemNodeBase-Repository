using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonImagePresenter
    {
        /// <summary>
        /// Create a new common Image element.
        /// </summary>
        /// <param name="sprite">The sprite to set for.</param>
        /// <param name="USS01">The first image USS style to set for.</param>
        /// <param name="USS02">The second image USS style to set for.</param>
        /// <returns>A new common Image element.</returns>
        public static Image CreateElement
        (
            Sprite sprite = null,
            string USS01 = null,
            string USS02 = null
        )
        {
            Image image;

            CreateImage();

            SetupDetails();

            AddStyleClass();

            return image;

            void CreateImage()
            {
                image = new();
            }

            void SetupDetails()
            {
                if (sprite != null)
                    image.sprite = sprite;

                image.pickingMode = PickingMode.Ignore;
            }

            void AddStyleClass()
            {
                image.ClearClassList();

                if (USS01 != null)
                    image.AddToClassList(USS01);

                if (USS02 != null)
                    image.AddToClassList(USS02);
            }
        }
    }
}