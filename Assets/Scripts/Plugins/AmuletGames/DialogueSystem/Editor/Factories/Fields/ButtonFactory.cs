using System;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class ButtonFactory
    {
        /// <summary>
        /// Factory method for creating a new button UIElement.
        /// </summary>
        /// <param name="isAlert">Is pressing the button invokes WindowChangedEvent?</param>
        /// <param name="btnText">The button label text to set for.</param>
        /// <param name="btnPressedAction">The action to invoke when the button is pressed.</param>
        /// <param name="buttonUSS01">The first USS style to set for the button.</param>
        /// <returns>A new button UIElement.</returns>
        public static Button GetNewButton
        (
            bool isAlert,
            string btnText,
            Action btnPressedAction,
            string buttonUSS01 = ""
        )
        {
            Button btn;

            SetupButton();

            RegisterButtonAction();

            AddButtonToStyleClass();

            return btn;

            void SetupButton()
            {
                btn = new Button();
                btn.text = btnText;
            }

            void RegisterButtonAction()
            {
                if (isAlert)
                {
                    ButtonCallbacks.RegisterButtonClickedEvent
                    (
                        button: btn,
                        buttonClickedAction: btnPressedAction
                    );
                }
                else
                {
                    btn.clicked += btnPressedAction;
                }
            }

            void AddButtonToStyleClass()
            {
                btn.AddToClassList(buttonUSS01);
            }
        }


        /// <summary>
        /// Factory method for creating a new button UIElement.
        /// </summary>
        /// <param name="isAlert">Is pressing the button invokes WindowChangedEvent?</param>
        /// <param name="btnSprite">The button icon sprite to set for.</param>
        /// <param name="btnPressedAction">The action to invoke when the button is pressed.</param>
        /// <param name="buttonUSS01">The first USS style to set for the button.</param>
        /// <returns>A new button UIElement.</returns>
        public static Button GetNewButton
        (
            bool isAlert,
            Sprite btnSprite,
            Action btnPressedAction,
            string buttonUSS01 = ""
        )
        {
            Button btn;

            SetupButton();

            RegisterButtonAction();

            AddButtonToStyleClass();

            return btn;

            void SetupButton()
            {
                btn = new Button();
                btn.style.backgroundImage = btnSprite.texture;
            }

            void RegisterButtonAction()
            {
                if (isAlert)
                {
                    ButtonCallbacks.RegisterButtonClickedEvent
                    (
                        button: btn,
                        buttonClickedAction: btnPressedAction
                    );
                }
                else
                {
                    btn.clicked += btnPressedAction;
                }
            }

            void AddButtonToStyleClass()
            {
                btn.AddToClassList(buttonUSS01);
            }
        }
    }
}