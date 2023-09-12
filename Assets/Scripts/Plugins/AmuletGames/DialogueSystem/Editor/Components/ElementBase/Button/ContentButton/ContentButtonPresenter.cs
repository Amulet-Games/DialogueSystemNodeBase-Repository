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

            AddButtonTextLabel();

            AddButtonIconImage();

            AddElementsToContentButton();

            SetupStyleSheet();

            return contentButton;

            void SetupContainer()
            {
                contentButton = new();
                contentButton.AddToClassList(StyleConfig.ContentButton);
            }

            void AddButtonTextLabel()
            {
                contentButton.ButtonTextLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: buttonText,
                    labelUSS: StyleConfig.ContentButton_ButtonText_Label
                );
            }

            void AddButtonIconImage()
            {
                contentButton.ButtonIconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: buttonIconSprite,
                    imageUSS01: StyleConfig.ContentButton_ButtonIcon_Image
                );
            }

            void AddElementsToContentButton()
            {
                contentButton.Add(contentButton.ButtonTextLabel);
                contentButton.Add(contentButton.ButtonIconImage);
            }

            void SetupStyleSheet()
            {
                contentButton.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSContentButtonStyle);
            }
        }
    }
}