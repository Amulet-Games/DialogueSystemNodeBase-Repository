using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonButtonPresenter
    {
        /// <summary>
        /// Create a new common button element.
        /// </summary>
        /// <param name="buttonText">The text to set for the button.</param>
        /// <param name="buttonUSS">The USS style to set for the button.</param>
        /// <returns>A new common button element.</returns>
        public static Button CreateElement
        (
            string buttonText,
            string buttonUSS
        )
        {
            Button button;

            CreateButton();

            SetButtonDetails();

            SetupStyleClass();

            void CreateButton()
            {
                button = new();
            }

            void SetButtonDetails()
            {
                button.text = buttonText;
            }

            void SetupStyleClass()
            {
                button.ClearClassList();
                button.AddToClassList(buttonUSS);
            }
            
            return button;
        }


        /// <summary>
        /// Method for creating a new common button element.
        /// </summary>
        /// <param name="buttonSprite">The sprite to set for the button.</param>
        /// <param name="buttonUSS">The USS style to set for the button.</param>
        /// <returns>A new common button element.</returns>
        public static Button CreateElement
        (
            Sprite buttonSprite,
            string buttonUSS
        )
        {
            Button button;

            CreateButton();

            SetButtonDetails();

            SetupStyleClass();

            void CreateButton()
            {
                button = new();
            }

            void SetButtonDetails()
            {
                button.style.backgroundImage = buttonSprite.texture;
            }

            void SetupStyleClass()
            {
                button.ClearClassList();
                button.AddToClassList(buttonUSS);
            }

            return button;
        }
    }
}