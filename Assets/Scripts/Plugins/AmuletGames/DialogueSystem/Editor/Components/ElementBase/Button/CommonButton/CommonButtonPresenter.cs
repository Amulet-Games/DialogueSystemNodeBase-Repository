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
        public static CommonButton CreateElement
        (
            string buttonText,
            string buttonUSS
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
                button = CreateElement(buttonUSS);
            }

            void CreateTextLabel()
            {
                textLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: buttonText,
                    labelUSS: StyleConfig.Button_ButtonText_Label
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
        /// <param name="buttonSprite">The button sprite to set for.</param>
        /// <param name="buttonUSS">The button USS style to set for.</param>
        /// <returns>A new common button element.</returns>
        public static CommonButton CreateElement
        (
            Sprite buttonSprite,
            string buttonUSS
        )
        {
            CommonButton button;

            CreateButton();

            SetupDetails();

            return button;

            void CreateButton()
            {
                button = CreateElement(buttonUSS);
            }
            
            void SetupDetails()
            {
                button.style.backgroundImage = buttonSprite.texture;
            }
        }


        /// <summary>
        /// Method for creating a new common button element.
        /// </summary>
        /// <param name="buttonUSS">The button USS style to set for.</param>
        /// <returns>A new common button element.</returns>
        public static CommonButton CreateElement(string buttonUSS)
        {
            CommonButton button = new();

            button.AddToClassList(buttonUSS);

            return button;
        }
    }
}