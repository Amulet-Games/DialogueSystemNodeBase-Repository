using UnityEngine;

namespace AG
{
    public class DSAssetsConfig
    {
        public static Sprite InputHintIconSprite;
        public static Sprite SegmentExpandButtonIcon;
        public static Sprite AddOptionEntryButtonIconImage;
        public static Sprite AddConditionModifierButtonIconImage;
        public static Sprite AddEventModifierButtonIconImage;
        public static Sprite RemoveModifierButtonIconImage;
        public static Sprite RemoveEntryButtonIconImage;
        public static Sprite LanguageSelectionDropdownArrowIconImage;

        #region Setup.
        public static void Setup()
        {
            SetupSpriteAssets();

            void SetupSpriteAssets()
            {
                InputHintIconSprite = Resources.Load<Sprite>("Assets/Sprites/InputHintIcon(PictoTotal)");
                SegmentExpandButtonIcon = Resources.Load<Sprite>("Assets/Sprites/SegmentExpandButtonIcon(PictoTotal)");
                AddOptionEntryButtonIconImage = Resources.Load<Sprite>("Assets/Sprites/AddOptionEntryButtonIcon(PictoTotal)");
                AddConditionModifierButtonIconImage = Resources.Load<Sprite>("Assets/Sprites/AddConditionModifierButtonIcon(PictoTotal)");
                AddEventModifierButtonIconImage = Resources.Load<Sprite>("Assets/Sprites/AddEventModifierButtonIcon(PictoTotal)");
                RemoveModifierButtonIconImage = Resources.Load<Sprite>("Assets/Sprites/RemoveButtonIcon(PictoTotal)");
                RemoveEntryButtonIconImage = Resources.Load<Sprite>("Assets/Sprites/RemoveButtonIcon(PictoTotal)");
                LanguageSelectionDropdownArrowIconImage = Resources.Load<Sprite>("Assets/Sprites/LanguageSelectionDropdownArrowIcon(RainbowArt)");
            }
        }
        #endregion
    }
}