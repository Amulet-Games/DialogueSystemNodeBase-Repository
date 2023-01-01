using UnityEngine;

namespace AG.DS
{
    public class AssetsConfig
    {
        // Add Component Buttons
        public static Sprite AddConditionModifierButtonIconSprite;
        public static Sprite AddChoiceEntryButtonIconSprite;
        public static Sprite AddEventModifierButtonIconSprite;
        public static Sprite AddMessageModifierButtonIconSprite;


        // Dropdown Arrows
        public static Sprite LanguageSelectionDropdownArrowIconSprite;


        // Edit Buttons
        public static Sprite NodeTitleEditButtonIconSprite;


        // Fields
        public static Sprite CharacterFieldIconSprite;
        public static Sprite HeadlineTextFieldIconSprite;
        public static Sprite ImageFieldIconSprite;
        public static Sprite KeyboardInputFieldIconSprite;
        public static Sprite LanguageFieldHintIconSprite;
        public static Sprite ScriptableObjectFieldIconSprite;

        // Folders
        public static Sprite FolderExpandButtonCloseIconSprite;
        public static Sprite FolderExpandButtonOpenIconSprite;

        // Modifiers
        public static Sprite ChangeFieldTypeButtonIconSprite;
        public static Sprite ChangeFieldTypeButtonBlockedIconSprite;
        public static Sprite MoveDownButtonIconSprite;
        public static Sprite MoveUpButtonIconSprite;


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
        public static Sprite RemoveButtonIcon1Sprite;
        public static Sprite RemoveButtonIcon2Sprite;


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

            SetupFoldersSpriteAssets();

            SetupModifiersSpriteAssets();

            SetupOperatorsSpriteAssets();

            SetupRemoveComponentButtonsSpriteAssets();

            SetupSegmentsSpriteAssets();

            void SetupAddComponentButtonsSpriteAssets()
            {
                AddConditionModifierButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/AddComponentButtons/AddConditionModifierButtonIcon(PictoTotal)");
                AddChoiceEntryButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/AddComponentButtons/AddChoiceEntryButtonIcon(PictoTotal)");
                AddEventModifierButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/AddComponentButtons/AddEventModifierButtonIcon(PictoTotal)");
                AddMessageModifierButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/AddComponentButtons/AddMessageModifierButtonIcon(PictoTotal)");
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
                CharacterFieldIconSprite = Resources.Load<Sprite>("Assets/Sprites/Fields/CharacterFieldIcon(PictoTotal)");
                HeadlineTextFieldIconSprite = Resources.Load<Sprite>("Assets/Sprites/Fields/HeadlineTextFieldIcon(PictoTotal)");
                ImageFieldIconSprite = Resources.Load<Sprite>("Assets/Sprites/Fields/ImageFieldIcon(PictoTotal)");
                KeyboardInputFieldIconSprite = Resources.Load<Sprite>("Assets/Sprites/Fields/KeyboardInputFieldIcon(PictoTotal)");
                LanguageFieldHintIconSprite = Resources.Load<Sprite>("Assets/Sprites/Fields/LanguageFieldHintIcon(PictoTotal)");
                ScriptableObjectFieldIconSprite = Resources.Load<Sprite>("Assets/Sprites/Fields/ScriptableObjectFieldIcon(RainbowArt)");
            }

            void SetupFoldersSpriteAssets()
            {
                FolderExpandButtonCloseIconSprite = Resources.Load<Sprite>("Assets/Sprites/Folders/FolderExpandButtonCloseIcon(RainbowArt)");
                FolderExpandButtonOpenIconSprite = Resources.Load<Sprite>("Assets/Sprites/Folders/FolderExpandButtonOpenIcon(RainbowArt)");
            }

            void SetupModifiersSpriteAssets()
            {
                ChangeFieldTypeButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Modifiers/ChangeFieldTypeButtonIcon(RainbowArt)");
                ChangeFieldTypeButtonBlockedIconSprite = Resources.Load<Sprite>("Assets/Sprites/Modifiers/ChangeFieldTypeButtonBlockedIcon(RainbowArt)");
                MoveDownButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Modifiers/MoveDownButtonIcon(PictoTotal)");
                MoveUpButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Modifiers/MoveUpButtonIcon(PictoTotal)");
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
                RemoveButtonIcon1Sprite = Resources.Load<Sprite>("Assets/Sprites/RemoveComponentButtons/RemoveButtonIcon1(PictoTotal)");
                RemoveButtonIcon2Sprite = Resources.Load<Sprite>("Assets/Sprites/RemoveComponentButtons/RemoveButtonIcon2(PictoTotal)");
            }

            void SetupSegmentsSpriteAssets()
            {
                SegmentExpandButtonIconSprite = Resources.Load<Sprite>("Assets/Sprites/Segments/SegmentExpandButtonIcon(PictoTotal)");
            }
        }
    }
}