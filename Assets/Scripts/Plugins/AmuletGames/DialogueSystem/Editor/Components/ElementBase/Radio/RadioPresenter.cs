using UnityEngine;

namespace AG.DS
{
    public class RadioPresenter
    {
        /// <summary>
        /// Create a new radio element.
        /// </summary>
        /// <param name="radioText">The radio text to set for.</param>
        /// <param name="radioSprite">The radio sprite to set for.</param>
        /// <returns>A new radio element.</returns>
        public static Radio CreateElement
        (
            string radioText,
            Sprite radioSprite
        )
        {
            Radio radio;

            CreateRadio();

            CreateRadioIconImage();

            CreateRadioTextLabel();

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
                    imageSprite: radioSprite,
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