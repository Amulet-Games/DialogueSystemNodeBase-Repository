using System;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class IntegrantFactory
    {
        /// <summary>
        /// Factory method for creating a new content button UIElement. Located on the top right corner of the given node.
        /// <br>It's can be used to add a new segment or modifier component inside the node when pressed.</br>
        /// </summary>
        /// <param name="node">The node of which this button is created for.</param>
        /// <param name="btnText">The name for this content button.</param>
        /// <param name="btnIconSprite">The icon that'll display along side with the name's text.</param>
        /// <param name="btnIconImageUSS01">The first USS style to set for the content button icon image.</param>
        /// <param name="action">The action to invoke when the button is pressed.</param>
        public static void CreateNewContentButton
        (
            NodeBase node,
            string btnText,
            Sprite btnIconSprite,
            string btnIconImageUSS01,
            Action action
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
                mainBox = new Box();
                mainBox.AddToClassList(StylesConfig.Integrant_ContentButton_MainBox);
            }

            void RegisterBoxAction()
            {
                BoxElementCallbacks.RegisterMouseDownEvent
                (
                    box: mainBox,
                    boxClickedAction: BoxClickedAction
                );

                void BoxClickedAction()
                {
                    // Release the focus of the owner's node's border visual element.
                    node.NodeBorder.Blur();

                    // Invoke the box clicked action.
                    action();
                }
            }

            void SetupContentButtonLabel()
            {
                contentButtonLabel = LabelFactory.GetNewLabel
                (
                    labelText: btnText,
                    labelUSS01: StylesConfig.Integrant_ContentButton_Label
                );
            }

            void SetupContentButtonIconImage()
            {
                contentButtonIconImage = ImageFactory.GetNewImage(imageUSS01: btnIconImageUSS01);
                contentButtonIconImage.sprite = btnIconSprite;
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