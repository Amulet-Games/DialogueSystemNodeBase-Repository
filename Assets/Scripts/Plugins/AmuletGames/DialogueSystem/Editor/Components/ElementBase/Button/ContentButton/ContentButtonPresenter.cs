using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ContentButtonPresenter
    {
        /// <summary>
        /// Method for creating a new content button element.
        /// <para></para>
        /// It locates on the top right corner of the given node, can be used to add a new segment or modifier component to the given node when clicked.
        /// </summary>
        /// <param name="buttonText">The name for this content button.</param>
        /// <param name="buttonIconSprite">The icon that'll display along side with the name's text.</param>
        /// <returns>A new content button element.</returns>
        public static ContentButton CreateElement
        (
            string buttonText,
            Sprite buttonIconSprite
        )
        {
            ContentButton contentButton;

            SetupContainer();

            AddButtonLabel();

            AddButtonIconImage();

            AddElementsToContentButton();

            SetupStyleSheet();

            return contentButton;

            void SetupContainer()
            {
                contentButton = new();
                contentButton.AddToClassList(StyleConfig.ContentButton_Main);
            }

            void AddButtonLabel()
            {
                contentButton.Label = CommonLabelPresenter.CreateElement
                (
                    labelText: buttonText,
                    labelUSS: StyleConfig.ContentButton_Label
                );
            }

            void AddButtonIconImage()
            {
                contentButton.IconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: buttonIconSprite,
                    imageUSS01: StyleConfig.ContentButton_Icon
                );
            }

            void AddElementsToContentButton()
            {
                contentButton.Add(contentButton.Label);
                contentButton.Add(contentButton.IconImage);
            }

            void SetupStyleSheet()
            {
                contentButton.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSContentButtonStyle);
            }
        }
    }
}