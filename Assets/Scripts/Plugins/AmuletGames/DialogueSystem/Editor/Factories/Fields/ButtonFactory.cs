using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ButtonFactory
    {
        /// <summary>
        /// Factory method for creating a new button UIElement.
        /// </summary>
        /// <param name="isAlert">Is pressing the button invokes WindowChangedEvent?</param>
        /// <param name="buttonText">The button label text to set for.</param>
        /// <param name="buttonClickAction">The action to invoke when the button is clicked.</param>
        /// <param name="buttonUSS01">The first USS style to set for the button.</param>
        /// <returns>A new button UIElement.</returns>
        public static Button GetNewButton
        (
            bool isAlert,
            string buttonText,
            Action buttonClickAction,
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
                btn = new();
                btn.text = buttonText;
            }

            void RegisterButtonAction()
            {
                if (isAlert)
                {
                    ButtonCallbacks.RegisterClickEvent
                    (
                        button: btn,
                        clickAction: buttonClickAction
                    );
                }
                else
                {
                    ButtonCallbacks.RegisterClickEventNonAlert
                    (
                        button: btn,
                        clickAction: buttonClickAction
                    );
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
        /// <param name="buttonSprite">The button icon sprite to set for.</param>
        /// <param name="buttonClickAction">The action to invoke when the button is clicked.</param>
        /// <param name="buttonUSS01">The first USS style to set for the button.</param>
        /// <returns>A new button UIElement.</returns>
        public static Button GetNewButton
        (
            bool isAlert,
            Sprite buttonSprite,
            Action buttonClickAction,
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
                btn = new();
                btn.style.backgroundImage = buttonSprite.texture;
            }

            void RegisterButtonAction()
            {
                if (isAlert)
                {
                    ButtonCallbacks.RegisterClickEvent
                    (
                        button: btn,
                        clickAction: buttonClickAction
                    );
                }
                else
                {
                    ButtonCallbacks.RegisterClickEventNonAlert
                    (
                        button: btn,
                        clickAction: buttonClickAction
                    );
                }
            }

            void AddButtonToStyleClass()
            {
                btn.AddToClassList(buttonUSS01);
            }
        }


        /// <summary>
        /// Factory method for creating a new content button UIElement.
        /// <para></para>
        /// It locates on the top right corner of the given node, can be used to add a new segment or modifier component inside the given node when pressed.
        /// </summary>
        /// <param name="node">The node of which this button is created for.</param>
        /// <param name="buttonText">The name for this content button.</param>
        /// <param name="buttonIconSprite">The icon that'll display along side with the name's text.</param>
        /// <param name="buttonClickAction">The action to invoke when the button is clicked.</param>
        /// <param name="buttonIconUSS01">The first USS style to set for the content button icon image.</param>
        public static void CreateNewContentButton
        (
            NodeBase node,
            string buttonText,
            Sprite buttonIconSprite,
            Action buttonClickAction,
            string buttonIconUSS01
        )
        {
            Box mainBox;

            Label contentButtonLabel;
            Image contentButtonIconImage;

            SetupBoxContainer();

            RegisterBoxAction();

            SetupContentButtonLabel();

            SetupContentButtonIconImage();

            AddFieldsToBox();

            AddBoxToTitleContainer();

            void SetupBoxContainer()
            {
                mainBox = new();
                mainBox.AddToClassList(StylesConfig.Integrant_ContentButton_Main_Box);
            }

            void RegisterBoxAction()
            {
                BoxCallbacks.RegisterMouseDownEvent
                (
                    box: mainBox,
                    clickAction: BoxClickedAction
                );

                void BoxClickedAction()
                {
                    // Release the focus of the owner's node's border visual element.
                    node.NodeBorder.Blur();

                    // Invoke the box clicked action.
                    buttonClickAction();
                }
            }

            void SetupContentButtonLabel()
            {
                contentButtonLabel = LabelFactory.GetNewLabel
                (
                    labelText: buttonText,
                    labelUSS01: StylesConfig.Integrant_ContentButton_Label
                );
            }

            void SetupContentButtonIconImage()
            {
                contentButtonIconImage = ImageFactory.GetNewImage(imageUSS01: buttonIconUSS01);
                contentButtonIconImage.sprite = buttonIconSprite;
                contentButtonIconImage.pickingMode = PickingMode.Ignore;
            }

            void AddFieldsToBox()
            {
                mainBox.Add(contentButtonLabel);
                mainBox.Add(contentButtonIconImage);
            }

            void AddBoxToTitleContainer()
            {
                node.titleContainer.Add(mainBox);
            }
        }
    }
}