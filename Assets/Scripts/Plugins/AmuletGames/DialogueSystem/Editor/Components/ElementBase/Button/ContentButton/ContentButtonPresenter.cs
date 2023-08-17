using UnityEngine;

namespace AG.DS
{
    public class ContentButtonPresenter
    {
        /// <summary>
        /// Create a new content button element.
        /// </summary>
        /// <param name="buttonText">The name for this content button.</param>
        /// <param name="buttonIconSprite">The icon that displays beside the button text.</param>
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