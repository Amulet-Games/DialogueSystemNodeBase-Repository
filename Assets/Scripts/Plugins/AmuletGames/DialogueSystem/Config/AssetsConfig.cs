using UnityEngine;

namespace AG.DS
{
    public class AssetsConfig
    {
        // Add Component Buttons
        public static Sprite AddConditionModifierButtonIconSprite;
        public static Sprite AddEventModifierButtonIconSprite;
        public static Sprite AddEntryButtonIconSprite;


        // Dropdown Arrows
        public static Sprite LanguageSelectionDropdownArrowIconSprite;


        // Edit Buttons
        public static Sprite NodeTitleEditButtonIconSprite;


        // Fields
        public static Sprite HeadlineTextFieldIcon;
        public static Sprite ImageFieldIconSprite;
        public static Sprite KeyboardInputFieldIconSprite;
        public static Sprite LanguageFieldHintIconSprite;
        public static Sprite ScriptableObjectFieldIconSprite;


        // Modifiers
        public static Sprite ChangeFieldTypeButtonIconSprite;
        public static Sprite ChangeFieldTypeButtonBlockedIconSprite;


        // Operators
        public static Sprite BiggerOperatorButtonIconSprite;
        public static Sprite EqualOperatorButtonIconSprite;
        public static Sprite EqualOrBiggerOperatorButtonIconSprite;
        public static Sprite EqualOrSmallerOperatorButtonIconSprite;
        public static Sprite FalseOperatorButtonIconSprite;
        public static Sprite MatchOperatorButtonIconSprite;
        public static Sprite SmallerOperatorButtonIconSprite;
        public static Sprite TrueOperatorButtonIconSprite;


        // Remove Component Buttons
        public static Sprite RemoveChannelButtonIconSprite;
        public static Sprite RemoveModifierButtonIconSprite;


        // Segments
        public static Sprite SegmentExpandButtonIconSprite;


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class, used to initialize internal fields.
        /// </summary>
        public static void Setup()
        {
            SetupAddComponentButtonsSpriteAssets();

            SetupDropdownArrowsSpriteAssets();

            SetupEditButtonsSpriteAssets();

            SetupFieldsSpriteAssets();

            SetupModifiersSpriteAssets();

            SetupOperatorsSpriteAssets();

            SetupRemoveComponentButtonsSpriteAssets();

            SetupSegmentsSpriteAssets();

            void SetupAddComponentButtonsSpriteAssets()
            {
                AddConditionModifierButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/AddComponentButtons/AddConditionModifierButtonIcon(PictoTotal)");
                AddEventModifierButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/AddComponentButtons/AddEventModifierButtonIcon(PictoTotal)");
                AddEntryButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/AddComponentButtons/AddEntryButtonIcon(PictoTotal)");
            }

            void SetupDropdownArrowsSpriteAssets()
            {
                LanguageSelectionDropdownArrowIconSprite = Resources.Load<Sprite>("Assets/Sprites/DropdownArrows/LanguageSelectionDropdownArrowIcon(RainbowArt)");
            }

            void SetupEditButtonsSpriteAssets()
            {
                NodeTitleEditButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/EditButtons/NodeTitleEditButtonIcon(PictoTotal)");
            }

            void SetupFieldsSpriteAssets()
            {
                HeadlineTextFieldIcon = Resources.Load<Sprite>("Assets/Sprites/Fields/HeadlineTextFieldIcon(PictoTotal)");
                ImageFieldIconSprite = Resources.Load<Sprite>("Assets/Sprites/Fields/ImageFieldIcon(PictoTotal)");
                KeyboardInputFieldIconSprite = Resources.Load<Sprite>("Assets/Sprites/Fields/KeyboardInputFieldIcon(PictoTotal)");
                LanguageFieldHintIconSprite = Resources.Load<Sprite>("Assets/Sprites/Fields/LanguageFieldHintIcon(PictoTotal)");
                ScriptableObjectFieldIconSprite = Resources.Load<Sprite>("Assets/Sprites/Fields/ScriptableObjectFieldIcon(RainbowArt)");
            }

            void SetupModifiersSpriteAssets()
            {
                ChangeFieldTypeButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Modifiers/ChangeFieldTypeButtonIcon(RainbowArt)");
                ChangeFieldTypeButtonBlockedIconSprite = Resources.Load<Sprite>("Assets/Sprites/Modifiers/ChangeFieldTypeButtonBlockedIcon(RainbowArt)");
            }

            void SetupOperatorsSpriteAssets()
            {
                BiggerOperatorButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Operators/BiggerOperatorButtonIcon(RainbowArt)");
                EqualOperatorButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Operators/EqualOperatorButtonIcon(RainbowArt)");
                EqualOrBiggerOperatorButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Operators/EqualOrBiggerOperatorButtonIcon(RainbowArt)");
                EqualOrSmallerOperatorButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Operators/EqualOrSmallerOperatorButtonIcon(RainbowArt)");
                FalseOperatorButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Operators/FalseOperatorButtonIcon(RainbowArt)");
                MatchOperatorButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Operators/MatchOperatorButtonIcon(RainbowArt)");
                SmallerOperatorButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Operators/SmallerOperatorButtonIcon(RainbowArt)");
                TrueOperatorButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Operators/TrueOperatorButtonIcon(RainbowArt)");
            }

            void SetupRemoveComponentButtonsSpriteAssets()
            {
                RemoveChannelButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/RemoveComponentButtons/RemoveChannelButtonIcon(PictoTotal)");
                RemoveModifierButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/RemoveComponentButtons/RemoveModifierButtonIcon(PictoTotal)");
            }

            void SetupSegmentsSpriteAssets()
            {
                SegmentExpandButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Segments/SegmentExpandButtonIcon(PictoTotal)");
            }
        }
    }
}