using UnityEngine;

namespace AG
{
    public class DSAssetsConfig
    {
        public static Sprite inputHintIconSprite;
        public static Sprite segmentExpandButtonIcon;
        public static Sprite addChoiceEntryButtonIconImage;
        public static Sprite addConditionModifierButtonIconImage;
        public static Sprite addEventModifierButtonIconImage;
        public static Sprite removeModifierButtonIconImage;

        #region Setup.
        public static void Setup()
        {
            SetupSpriteAssets();

            void SetupSpriteAssets()
            {
                inputHintIconSprite = Resources.Load<Sprite>("Assets/Sprites/InputHintIcon(PictoTotal)");
                segmentExpandButtonIcon = Resources.Load<Sprite>("Assets/Sprites/SegmentExpandButtonIcon(PictoTotal)");
                addChoiceEntryButtonIconImage = Resources.Load<Sprite>("Assets/Sprites/AddChoiceEntryButtonIcon(PictoTotal)");
                addConditionModifierButtonIconImage = Resources.Load<Sprite>("Assets/Sprites/AddConditionModifierButtonIcon(PictoTotal)");
                addEventModifierButtonIconImage = Resources.Load<Sprite>("Assets/Sprites/AddEventModifierButtonIcon(PictoTotal)");
                removeModifierButtonIconImage = Resources.Load<Sprite>("Assets/Sprites/RemoveModifierButtonIcon(PictoTotal)");
            }
        }
        #endregion
    }
}