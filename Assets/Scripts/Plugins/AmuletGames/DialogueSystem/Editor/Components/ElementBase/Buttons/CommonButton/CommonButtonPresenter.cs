using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonButtonPresenter
    {
        /// <summary>
        /// Method for creating a new common button element.
        /// </summary>
        /// <param name="buttonText">The button label text to set for.</param>
        /// <param name="buttonUSS">The USS style to set for the button.</param>
        /// <returns>A new common button element.</returns>
        public static Button CreateElement
        (
            string buttonText,
            string buttonUSS
        )
        {
            Button button = new();

            button.text = buttonText;

            button.AddToClassList(buttonUSS);

            return button;
        }


        /// <summary>
        /// Method for creating a new common button element.
        /// </summary>
        /// <param name="buttonSprite">The button icon sprite to set for.</param>
        /// <param name="buttonUSS">The USS style to set for the button.</param>
        /// <returns>A new common button element.</returns>
        public static Button CreateElement
        (
            Sprite buttonSprite,
            string buttonUSS
        )
        {
            Button button = new();

            button.style.backgroundImage = buttonSprite.texture;

            button.AddToClassList(buttonUSS);

            return button;
        }
    }
}