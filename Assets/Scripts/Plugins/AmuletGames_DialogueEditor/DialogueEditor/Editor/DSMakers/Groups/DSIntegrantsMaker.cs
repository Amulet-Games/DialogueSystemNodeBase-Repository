using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSIntegrantsMaker
    {
        /// <summary>
        /// Create all the UIElements that are needed in this content button.
        /// </summary>
        /// <param name="node">The node of which this button is created for and connect to.</param>
        /// <param name="btnText">The name for this content button.</param>
        /// <param name="contentButtonIconSprite">The icon that'll display along side with the name's text.</param>
        /// <param name="contentButtonIconImageUSS01">The style for the content button icon image to use when it appeared on the editor window.</param>
        /// <param name="contentButtonClickedAction">The action to invoke when content button is pressed.</param>
        public static void GetNewContentButton
            (Node node, string btnText, Sprite contentButtonIconSprite, string contentButtonIconImageUSS01, Action contentButtonClickedAction)
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
                mainBox.AddToClassList(DSStylesConfig.Integrant_ContentButton_MainBox);
            }

            void RegisterBoxAction()
            {
                DSBoxEventRegister.DSBoxClickedAction(mainBox, contentButtonClickedAction);
            }

            void SetupContentButtonLabel()
            {
                contentButtonLabel = DSLabelsMaker.GetNewLabel(btnText, DSStylesConfig.Integrant_ContentButton_Label);
            }

            void SetupContentButtonIconImage()
            {
                contentButtonIconImage = DSImagesMaker.GetNewImage(contentButtonIconImageUSS01);
                contentButtonIconImage.image = contentButtonIconSprite.texture;
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