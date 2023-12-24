using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ContentButtonPresenter
    {
        /// <summary>
        /// Create a new content button element.
        /// </summary>
        /// <param name="buttonText">The button text to set for.</param>
        /// <param name="buttonIconSprite">The button icon sprite to set for.</param>
        /// <returns>A new content button element.</returns>
        public static CommonButton CreateElement
        (
            string buttonText,
            Sprite buttonIconSprite
        )
        {
            CommonButton button;

            Label buttonLabel;
            Image iconImage;

            CreateButton();

            CreateButtonLabel();

            CreateIconImage();

            AddElementsToContentButton();

            AddStyleSheet();

            return button;

            void CreateButton()
            {
                button = new();
                button.AddToClassList(StyleConfig.ContentButton);
            }

            void CreateButtonLabel()
            {
                buttonLabel = CommonLabelPresenter.CreateElement
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
                button.Add(buttonLabel);
                button.Add(iconImage);
            }

            void AddStyleSheet()
            {
                button.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.ContentButtonStyle);
            }
        }
    }
}