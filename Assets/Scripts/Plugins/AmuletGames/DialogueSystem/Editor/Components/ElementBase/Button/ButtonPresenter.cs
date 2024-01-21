using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ButtonPresenter
    {
        /// <summary>
        /// Create a new button element.
        /// </summary>
        /// <param name="text">The text to set for.</param>
        /// <param name="USS">The USS style to set for.</param>
        /// <returns>A new button element.</returns>
        public static Button CreateElement
        (
            string text,
            string USS
        )
        {
            Button button;

            Label textLabel;

            CreateButton();

            CreateTextLabel();

            AddElementsToButton();

            return button;

            void CreateButton()
            {
                button = CreateElement(USS);
            }

            void CreateTextLabel()
            {
                textLabel = LabelPresenter.CreateElement
                (
                    text: text,
                    USS: StyleConfig.Button_ButtonText_Label
                );
            }

            void AddElementsToButton()
            {
                button.Add(textLabel);
            }
        }


        /// <summary>
        /// Create a new button element.
        /// </summary>
        /// <param name="sprite">The sprite to set for.</param>
        /// <param name="USS">The USS style to set for.</param>
        /// <returns>A new button element.</returns>
        public static Button CreateElement
        (
            Sprite sprite,
            string USS
        )
        {
            Button button;

            CreateButton();

            SetupDetails();

            return button;

            void CreateButton()
            {
                button = CreateElement(USS);
            }
            
            void SetupDetails()
            {
                button.style.backgroundImage = sprite.texture;
            }
        }


        /// <summary>
        /// Create a new button element.
        /// </summary>
        /// <param name="USS">The USS style to set for.</param>
        /// <returns>A new button element.</returns>
        public static Button CreateElement(string USS)
        {
            Button button = new();

            button.AddToClassList(USS);

            return button;
        }
    }
}