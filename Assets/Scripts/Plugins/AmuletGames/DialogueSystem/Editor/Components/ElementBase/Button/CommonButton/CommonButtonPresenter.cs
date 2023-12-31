using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonButtonPresenter
    {
        /// <summary>
        /// Create a new common button element.
        /// </summary>
        /// <param name="text">The text to set for.</param>
        /// <param name="USS">The USS style to set for.</param>
        /// <returns>A new common button element.</returns>
        public static CommonButton CreateElement
        (
            string text,
            string USS
        )
        {
            CommonButton button;

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
                textLabel = CommonLabelPresenter.CreateElement
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
        /// Method for creating a new common button element.
        /// </summary>
        /// <param name="sprite">The sprite to set for.</param>
        /// <param name="USS">The USS style to set for.</param>
        /// <returns>A new common button element.</returns>
        public static CommonButton CreateElement
        (
            Sprite sprite,
            string USS
        )
        {
            CommonButton button;

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
        /// Method for creating a new common button element.
        /// </summary>
        /// <param name="USS">The USS style to set for.</param>
        /// <returns>A new common button element.</returns>
        public static CommonButton CreateElement(string USS)
        {
            CommonButton button = new();

            button.AddToClassList(USS);

            return button;
        }
    }
}