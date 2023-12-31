using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class FlagElementPresenter
    {
        /// <summary>
        /// Create a new flag element.
        /// </summary>
        /// <typeparam name="TEnum">Type system.Enum</typeparam>
        /// <param name="labelText">The label text to set for.</param>
        /// <param name="selectedIconSprite">The selected icon sprite to set for.</param>
        /// <param name="flag">The flag to set for.</param>
        /// <returns>A new flag element.</returns>
        public static FlagElement<TEnum> CreateElement<TEnum>
        (
            string labelText,
            Sprite selectedIconSprite,
            TEnum flag
        )
            where TEnum : struct, Enum
        {
            FlagElement<TEnum> flagElement;

            CreateElement();

            CreateSelectedIconImage();

            CreateTextLabel();

            SetupDetails();

            AddElementsToFlagElement();

            AddStyleSheet();

            return flagElement;

            void CreateElement()
            {
                flagElement = new();
                flagElement.AddToClassList(StyleConfig.FlagElement);
            }

            void CreateSelectedIconImage()
            {
                flagElement.SelectedIconImage = CommonImagePresenter.CreateElement
                (
                    sprite: selectedIconSprite,
                    USS01: StyleConfig.FlagElement_SelectedIcon_Image
                );
            }

            void CreateTextLabel()
            {
                flagElement.TextLabel = CommonLabelPresenter.CreateElement
                (
                    text: labelText,
                    USS: StyleConfig.FlagElement_Text_Label
                );
            }

            void SetupDetails()
            {
                flagElement.Flag = flag;

                flagElement.focusable = true;
                flagElement.pickingMode = PickingMode.Position;

                flagElement.SelectedIconImage.pickingMode = PickingMode.Position;
            }

            void AddElementsToFlagElement()
            {
                flagElement.Add(flagElement.SelectedIconImage);
                flagElement.Add(flagElement.TextLabel);
            }

            void AddStyleSheet()
            {
                flagElement.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.FlagElementStyle);
            }
        }
    }
}