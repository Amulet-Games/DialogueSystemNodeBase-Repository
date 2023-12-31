using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class RadioPresenter
    {
        /// <summary>
        /// Create a new radio element.
        /// </summary>
        /// <param name="labelText">The label text to set for.</param>
        /// <param name="iconSprite">The icon sprite to set for.</param>
        /// <returns>A new radio element.</returns>
        public static Radio CreateElement
        (
            string labelText,
            Sprite iconSprite
        )
        {
            Radio radio;

            CreateRadio();

            CreateIconImage();

            CreateTextLabel();

            SetupDetails();

            AddElementsToRadio();

            AddStyleSheet();

            return radio;

            void CreateRadio()
            {
                radio = new();
                radio.AddToClassList(StyleConfig.Radio);
            }

            void CreateIconImage()
            {
                radio.IconImage = CommonImagePresenter.CreateElement
                (
                    sprite: iconSprite,
                    USS01: StyleConfig.Radio_Icon_Image
                );
            }

            void CreateTextLabel()
            {
                radio.TextLabel = CommonLabelPresenter.CreateElement
                (
                    text: labelText,
                    USS: StyleConfig.Radio_Text_Label
                );
            }

            void SetupDetails()
            {
                radio.focusable = true;
                radio.pickingMode = PickingMode.Position;

                radio.IconImage.pickingMode = PickingMode.Position;
            }

            void AddElementsToRadio()
            {
                radio.Add(radio.IconImage);
                radio.Add(radio.TextLabel);
            }

            void AddStyleSheet()
            {
                radio.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.RadioStyle);
            }
        }
    }
}