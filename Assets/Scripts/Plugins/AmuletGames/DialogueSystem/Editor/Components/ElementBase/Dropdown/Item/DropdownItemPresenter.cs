using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class DropdownItemPresenter
    {
        /// <summary>
        /// Create a new dropdown item element.
        /// </summary>
        /// <param name="labelText">The label text to set for.</param>
        /// <param name="iconSprite">The icon sprite to set for.</param>
        /// <param name="additionalInfo">The additional info to set for.</param>
        /// <returns>A new dropdown item element.</returns>
        public static DropdownItem CreateElement
        (
            string labelText,
            Sprite iconSprite,
            string additionalInfo
        )
        {
            DropdownItem dropdownItem;

            CreateItem();

            CreateIconImage();

            CreateTextLabel();

            SetupDetails();

            AddElementsToItem();

            AddStyleSheet();

            return dropdownItem;

            void CreateItem()
            {
                dropdownItem = new();
                dropdownItem.AddToClassList(StyleConfig.DropdownItem);
            }

            void CreateIconImage()
            {
                dropdownItem.IconImage = CommonImagePresenter.CreateElement
                (
                    sprite: iconSprite,
                    USS01: StyleConfig.DropdownItem_Icon_Image
                );
            }

            void CreateTextLabel()
            {
                dropdownItem.TextLabel = LabelPresenter.CreateElement
                (
                    text: labelText,
                    USS: StyleConfig.DropdownItem_Text_Label
                );
            }

            void SetupDetails()
            {
                dropdownItem.AdditionalInfo = additionalInfo;

                dropdownItem.focusable = true;
                dropdownItem.pickingMode = PickingMode.Position;

                dropdownItem.IconImage.pickingMode = PickingMode.Position;
            }

            void AddElementsToItem()
            {
                dropdownItem.Add(dropdownItem.IconImage);
                dropdownItem.Add(dropdownItem.TextLabel);
            }

            void AddStyleSheet()
            {
                dropdownItem.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DropdownItemStyle);
            }
        }
    }
}