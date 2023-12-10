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

            AddStyleClass();

            void CreateButton()
            {
                button = new();
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

            void AddStyleClass()
            {
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
        public static CommonButton CreateElement
        (
            Sprite buttonSprite,
            string buttonUSS
        )
        {
            CommonButton button;

            CreateButton();

            SetupDetails();

            AddStyleClass();

            void CreateButton()
            {
                button = new();
            }

            void SetupDetails()
            {
                button.style.backgroundImage = buttonSprite.texture;
            }

            void AddStyleClass()
            {
                button.AddToClassList(buttonUSS);
            }

            return button;
        }
    }
}