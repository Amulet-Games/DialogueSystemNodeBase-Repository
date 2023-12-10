using UnityEngine;
using UnityEngine.UIElements;

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
        public static CommonButton CreateElement
        (
            string buttonText,
            Sprite buttonIconSprite
        )
        {
            CommonButton button;

            Label textLabel;
            Image iconImage;

            CreateButton();

            CreateTextLabel();

            CreateIconImage();

            AddElementsToContentButton();

            AddStyleSheet();

            return button;

            void CreateButton()
            {
                button = new();
                button.AddToClassList(StyleConfig.ContentButton);
            }

            void CreateTextLabel()
            {
                textLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: buttonText,
                    labelUSS: StyleConfig.ContentButton_ButtonText_Label
                );
            }

            void CreateIconImage()
            {
                iconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: buttonIconSprite,
                    imageUSS01: StyleConfig.ContentButton_ButtonIcon_Image
                );
            }

            void AddElementsToContentButton()
            {
                button.Add(textLabel);
                button.Add(iconImage);
            }

            void AddStyleSheet()
            {
                button.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSContentButtonStyle);
            }
        }
    }
}