using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonButtonPresenter
    {
        /// <summary>
        /// Create a new common button element.
        /// </summary>
        /// <param name="buttonText">The button text to set for.</param>
        /// <param name="buttonUSS">The button USS style to set for.</param>
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
        /// <param name="buttonSprite">The button sprite to set for.</param>
        /// <param name="buttonUSS">The button USS style to set for.</param>
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