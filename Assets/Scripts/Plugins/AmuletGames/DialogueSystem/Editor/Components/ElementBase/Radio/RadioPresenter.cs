using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class RadioPresenter
    {
        /// <summary>
        /// Create a new radio element.
        /// </summary>
        /// <param name="radioText">The radio text to set for.</param>
        /// <param name="radioIconSprite">The radio icon sprite to set for.</param>
        /// <returns>A new radio element.</returns>
        public static Radio CreateElement
        (
            string radioText,
            Sprite radioIconSprite
        )
        {
            Radio radio;

            CreateRadio();

            CreateRadioIconImage();

            CreateRadioTextLabel();

            SetupDetails();

            AddElementsToRadio();

            AddStyleSheet();

            return radio;

            void CreateRadio()
            {
                radio = new();
                radio.AddToClassList(StyleConfig.Radio);
            }

            void CreateRadioIconImage()
            {
                radio.RadioIconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: radioIconSprite,
                    imageUSS01: StyleConfig.Radio_RadioIcon_Image
                );
            }

            void CreateRadioTextLabel()
            {
                radio.RadioTextLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: radioText,
                    labelUSS: StyleConfig.Radio_RadioText_Label
                );
            }

            void SetupDetails()
            {
                radio.focusable = true;
                radio.pickingMode = PickingMode.Position;

                radio.RadioIconImage.pickingMode = PickingMode.Position;
            }

            void AddElementsToRadio()
            {
                radio.Add(radio.RadioIconImage);
                radio.Add(radio.RadioTextLabel);
            }

            void AddStyleSheet()
            {
                radio.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSRadioStyle);
            }
        }
    }
}