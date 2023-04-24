using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonButtonPresenter
    {
        /// <summary>
        /// Method for creating a new common button UIElement.
        /// </summary>
        /// <param name="buttonUSS01">The first USS style to set for the button.</param>
        /// <param name="buttonText">The button label text to set for.</param>
        /// <returns>A new common button UIElement.</returns>
        public static Button CreateElements
        (
            string buttonText,
            string buttonUSS01
        )
        {
            Button button = new();

            button.text = buttonText;

            button.AddToClassList(buttonUSS01);

            return button;
        }


        /// <summary>
        /// Method for creating a new common button UIElement.
        /// </summary>
        /// <param name="buttonUSS01">The first USS style to set for the button.</param>
        /// <param name="buttonSprite">The button icon sprite to set for.</param>
        /// <returns>A new common button UIElement.</returns>
        public static Button CreateElements
        (
            Sprite buttonSprite,
            string buttonUSS01
        )
        {
            Button button = new();

            button.style.backgroundImage = buttonSprite.texture;

            button.AddToClassList(buttonUSS01);

            return button;
        }
    }
}