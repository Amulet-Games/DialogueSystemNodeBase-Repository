using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class EnumFlagsItemPresenter
    {
        /// <summary>
        /// Create a new enum flags item element.
        /// </summary>
        /// <typeparam name="TEnum">Type system.Enum</typeparam>
        /// <param name="labelText">The label text to set for.</param>
        /// <param name="checkmarkSprite">The checkmark sprite to set for.</param>
        /// <param name="flag">The flag to set for.</param>
        /// <returns>A new enum flags item element.</returns>
        public static EnumFlagsItem<TEnum> CreateElement<TEnum>
        (
            string labelText,
            Sprite checkmarkSprite,
            TEnum flag
        )
            where TEnum : struct, Enum
        {
            EnumFlagsItem<TEnum> enumFlagsItem;

            CreateItem();

            CreateCheckmarkImage();

            CreateTextLabel();

            SetupDetails();

            AddElementsToItem();

            AddStyleSheet();

            return enumFlagsItem;

            void CreateItem()
            {
                enumFlagsItem = new();
                enumFlagsItem.AddToClassList(StyleConfig.EnumFlagsItem);
            }

            void CreateCheckmarkImage()
            {
                enumFlagsItem.CheckmarkImage = CommonImagePresenter.CreateElement
                (
                    sprite: checkmarkSprite,
                    USS01: StyleConfig.EnumFlagsItem_Checkmark_Image
                );
            }

            void CreateTextLabel()
            {
                enumFlagsItem.TextLabel = CommonLabelPresenter.CreateElement
                (
                    text: labelText,
                    USS: StyleConfig.EnumFlagsItem_Text_Label
                );
            }

            void SetupDetails()
            {
                enumFlagsItem.Flag = flag;

                enumFlagsItem.focusable = true;
                enumFlagsItem.pickingMode = PickingMode.Position;

                enumFlagsItem.CheckmarkImage.pickingMode = PickingMode.Position;
            }

            void AddElementsToItem()
            {
                enumFlagsItem.Add(enumFlagsItem.CheckmarkImage);
                enumFlagsItem.Add(enumFlagsItem.TextLabel);
            }

            void AddStyleSheet()
            {
                enumFlagsItem.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.EnumFlagsItemStyle);
            }
        }
    }
}