using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownElementPresenter
    {
        /// <summary>
        /// Create a new dropdown element.
        /// </summary>
        /// <param name="labelText">The label text to set for.</param>
        /// <param name="iconSprite">The icon sprite to set for.</param>
        /// <param name="additionalInfo">The additional info to set for.</param>
        /// <returns>A new dropdown element.</returns>
        public static DropdownElement CreateElement
        (
            string labelText,
            Sprite iconSprite,
            string additionalInfo
        )
        {
            DropdownElement dropdownElement;

            CreateElement();

            CreateIconImage();

            CreateTextLabel();

            SetupDetails();

            AddElementsToDropdownElement();

            AddStyleSheet();

            return dropdownElement;

            void CreateElement()
            {
                dropdownElement = new();
                dropdownElement.AddToClassList(StyleConfig.DropdownElement);
            }

            void CreateIconImage()
            {
                dropdownElement.IconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: iconSprite,
                    imageUSS01: StyleConfig.DropdownElement_Icon_Image
                );
            }

            void CreateTextLabel()
            {
                dropdownElement.TextLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: labelText,
                    labelUSS: StyleConfig.DropdownElement_Text_Label
                );
            }

            void SetupDetails()
            {
                dropdownElement.AdditionalInfo = additionalInfo;

                dropdownElement.focusable = true;
                dropdownElement.pickingMode = PickingMode.Position;

                dropdownElement.IconImage.pickingMode = PickingMode.Position;
            }

            void AddElementsToDropdownElement()
            {
                dropdownElement.Add(dropdownElement.IconImage);
                dropdownElement.Add(dropdownElement.TextLabel);
            }

            void AddStyleSheet()
            {
                dropdownElement.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DropdownElementStyle);
            }
        }
    }
}