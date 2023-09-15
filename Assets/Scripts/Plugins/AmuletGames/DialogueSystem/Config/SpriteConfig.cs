using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/Config/New Sprite Config")]
    public class SpriteConfig : ScriptableObject
    {
        #region Commons.
        [Header("Commons")]
        public Sprite EditButtonIconSprite;
        public Sprite MoveDownButtonIconSprite;
        public Sprite MoveUpButtonIconSprite;
        public Sprite RemoveButtonIconSprite;
        #endregion

        #region Conditions.
        [Header("Conditions")]
        public Sprite LinkConditionIconSprite;
        public Sprite UnlinkConditionIconSprite;
        #endregion

        #region Content Buttons.
        [Header("Content Buttons")]
        public Sprite AddConditionButtonIconSprite;
        public Sprite AddEntryButtonIconSprite;
        public Sprite AddEventButtonIconSprite;
        public Sprite AddMessageButtonIconSprite;
        #endregion

        #region Dropdown Arrows
        [Header("Dropdown Arrows")]
        public Sprite DropdownArrowIcon1Sprite;
        public Sprite DropdownArrowIcon2Sprite;
        #endregion

        #region Fields.
        [Header("Fields")]
        public Sprite AudioClipFieldIconSprite;
        public Sprite AutoProgressTypeIconSprite;
        public Sprite ChangeFieldTypeButtonDisableIconSprite;
        public Sprite ChangeFieldTypeButtonHoverIconSprite;
        public Sprite ChangeFieldTypeButtonNormalIconSprite;
        public Sprite EventFieldIconSprite;
        public Sprite ImageFieldIconSprite;
        public Sprite KeyboardInputFieldIconSprite;
        public Sprite LanguageFieldHintIconSprite;
        public Sprite BranchTitleFieldSprite;
        public Sprite RootTitleFieldSprite;
        public Sprite ScriptableObjectFieldIconSprite;
        public Sprite DialogueSpeakerFieldSprite;
        public Sprite TextFieldIcon1Sprite;
        #endregion

        #region Folders.
        [Header("Folders")]
        public Sprite FolderExpandButtonCloseIconSprite;
        public Sprite FolderExpandButtonOpenIconSprite;
        #endregion

        #region Operators.
        [Header("Operators")]
        public Sprite BiggerOperatorButtonIconSprite;
        public Sprite EqualOperatorButtonIconSprite;
        public Sprite EqualOrBiggerOperatorButtonIconSprite;
        public Sprite EqualOrSmallerOperatorButtonIconSprite;
        public Sprite FalseOperatorButtonIconSprite;
        public Sprite MatchOperatorButtonIconSprite;
        public Sprite SmallerOperatorButtonIconSprite;
        public Sprite TrueOperatorButtonIconSprite;
        #endregion

        #region Segments.
        [Header("Segments")]
        public Sprite SegmentExpandButtonIconSprite;
        #endregion

        #region Apply Design Sample.
        [Header("Apply Design Sample.")]
        public Sprite ApplyDesignSampleImage;
        #endregion

        #region Obsoletes
        [Header("Obsoletes")]
        public Sprite CharacterFieldIconSprite;
        public Sprite ChangeFieldTypeButtonIconSprite;
        public Sprite ChangeFieldTypeButtonBlockedIconSprite;
        public Sprite RemoveButtonIcon2Sprite;
        #endregion
    }
}