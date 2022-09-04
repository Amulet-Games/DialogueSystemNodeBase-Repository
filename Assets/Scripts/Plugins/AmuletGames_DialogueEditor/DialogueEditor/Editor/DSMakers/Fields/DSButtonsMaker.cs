using System;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSButtonsMaker
    {
        /// <summary>
        /// Create a new button.
        /// <para>
        /// Note that by pressing the button, it'll invoke DSWindowChangedEvent right after the specified buttonClickedAction.
        /// To avoid this, use DSButtonMaker.GetNewButtonNonAlert() instead.
        /// </para>
        /// </summary>
        /// <param name="btnText">The text that'll appear on the botton as a label.</param>
        /// <param name="buttonClickedAction">The action to invoke when the button is pressed.</param>
        /// <param name="USS01">The first style for the button to use when it appeared on the editor window.</param>
        /// <returns>A new button UIElement.</returns>
        public static Button GetNewButton(string btnText, Action buttonClickedAction, string USS01 = "")
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
                DSButtonEventRegister.DSButtonClickedAction(btn, buttonClickedAction);
            }

            void AddButtonToStyleClass()
            {
                btn.AddToClassList(USS01);
            }
        }

        /// <summary>
        /// Create a new button.
        /// <para>
        /// Note that by pressing the button, it'll invoke DSWindowChangedEvent right after the specified buttonClickedAction.
        /// To avoid this, use DSButtonMaker.GetNewButtonNonAlert() instead.
        /// </para>
        /// </summary>
        /// <param name="btnSprite">The sprite icon that'll appear on top of the botton.</param>
        /// <param name="buttonClickedAction">The action to invoke when the button is pressed.</param>
        /// <param name="USS01">The first style for the button to use when it appeared on the editor window.</param>
        /// <returns>A new button UIElement.</returns>
        public static Button GetNewButton(Sprite btnSprite, Action buttonClickedAction, string USS01 = "")
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
                DSButtonEventRegister.DSButtonClickedAction(btn, buttonClickedAction);
            }

            void AddButtonToStyleClass()
            {
                btn.AddToClassList(USS01);
            }
        }

        /// <summary>
        /// Create a new button.
        /// <para>
        /// Note that by using this method, the button will only invoked the specified buttonClickedAction and will not trigger DSWindowChangedEvent.
        /// To avoid this, use DSButtonMaker.GetNewButton() instead.
        /// </para>
        /// </summary>
        /// <param name="btnText">The text that'll appear on top of the botton.</param>
        /// <param name="buttonClickedAction">The action to invoke when the button is pressed.</param>
        /// <param name="USS01">The first style for the button to use when it appeared on the editor window.</param>
        /// /// <returns>A new button UIElement.</returns>
        public static Button GetNewButtonNonAlert(string btnText, Action buttonClickedAction, string USS01 = "")
        {
            // Create and return a button UIElement,
            // however its clicked action doesn't invoke DSWindowChangedEvent.

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
                btn.clicked += buttonClickedAction;
            }

            void AddButtonToStyleClass()
            {
                btn.AddToClassList(USS01);
            }
        }

        /// <summary>
        /// Create a new button.
        /// <para>
        /// Note that by using this method, the button will only invoked the specified buttonClickedAction and will not trigger DSWindowChangedEvent.
        /// To avoid this, use DSButtonMaker.GetNewButton() instead.
        /// </para>
        /// </summary>
        /// <param name="btnSprite">The sprite icon that'll appear on top of the botton.</param>
        /// <param name="buttonClickedAction">The action to invoke when the button is pressed.</param>
        /// <param name="USS01">The first style for the button to use when it appeared on the editor window.</param>
        /// <returns>A new button UIElement.</returns>
        public static Button GetNewButtonNonAlert(Sprite btnSprite, Action buttonClickedAction, string USS01 = "")
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
                btn.clicked += buttonClickedAction;
            }

            void AddButtonToStyleClass()
            {
                btn.AddToClassList(USS01);
            }
        }
    }
}