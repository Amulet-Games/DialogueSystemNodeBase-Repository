using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownElementPresenter
    {
        /// <summary>
        /// Create a new dropdown element.
        /// </summary>
        /// <param name="elementText">The element text to set for.</param>
        /// <param name="elementIconSprite">The element icon sprite to set for.</param>
        /// <returns>A new dropdown element.</returns>
        public static DropdownElement CreateElement
        (
            string elementText,
            Sprite elementIconSprite
        )
        {
            DropdownElement dropElement;

            CreateDropElement();

            CreateElementIconImage();

            CreateElementTextLabel();

            SetupDetails();

            AddElementsToDropdownElement();

            AddStyleSheet();

            return dropElement;

            void CreateDropElement()
            {
                dropElement = new();
                dropElement.AddToClassList(StyleConfig.DropdownElement);
            }

            void CreateElementIconImage()
            {
                dropElement.ElementIconImage = CommonImagePresenter.CreateElement
                (
                    imageSprite: elementIconSprite,
                    imageUSS01: StyleConfig.DropdownElement_ElementIcon_Image
                );
            }

            void CreateElementTextLabel()
            {
                dropElement.ElementTextLabel = CommonLabelPresenter.CreateElement
                (
                    labelText: elementText,
                    labelUSS: StyleConfig.DropdownElement_ElementText_Label
                );
            }

            void SetupDetails()
            {
                dropElement.focusable = true;
                dropElement.pickingMode = PickingMode.Position;

                dropElement.ElementIconImage.pickingMode = PickingMode.Position;
            }

            void AddElementsToDropdownElement()
            {
                dropElement.Add(dropElement.ElementIconImage);
                dropElement.Add(dropElement.ElementTextLabel);
            }

            void AddStyleSheet()
            {
                dropElement.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSDropdownElementStyle);
            }
        }
    }
}