using System;

namespace AG.DS
{
    [Serializable]
    public class ConditionComparisonTypeIconicEnumFieldView : IconicEnumFieldViewBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the condition comparison type iconic enum field view class.
        /// </summary>
        public ConditionComparisonTypeIconicEnumFieldView()
        {
            Value = (int)M_Condition_ComparisonType.True;
        }


        // ----------------------------- Init Field Value -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue()
        {
            EnumField.Init((M_Condition_ComparisonType)Value);

            // Update the symbol icon to match the current value.
            UpdateIcon();
        }


        // ----------------------------- Update Field Value -----------------------------
        /// <inheritdoc />
        public override void UpdateFieldValueNonAlert() =>
            EnumField.SetValueWithoutNotify((M_Condition_ComparisonType)Value);


        // ----------------------------- Reset Icon -----------------------------
        /// <inheritdoc />
        public override void UpdateIcon()
        {
            var spriteConfig = ConfigResourcesManager.SpriteConfig;
            switch ((M_Condition_ComparisonType)Value)
            {
                case M_Condition_ComparisonType.True:
                    Icon.sprite = spriteConfig.TrueOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.False:
                    Icon.sprite = spriteConfig.FalseOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Matches:
                    Icon.sprite = spriteConfig.MatchOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Equals:
                    Icon.sprite = spriteConfig.EqualOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.EqualsOrBigger:
                    Icon.sprite = spriteConfig.EqualOrBiggerOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.EqualsOrSmaller:
                    Icon.sprite = spriteConfig.EqualOrSmallerOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Bigger:
                    Icon.sprite = spriteConfig.BiggerOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Smaller:
                    Icon.sprite = spriteConfig.SmallerOperatorButtonIconSprite;
                    break;
            }
        }


        // ----------------------------- Compare Enum's Value -----------------------------
        /// <summary>
        /// Returns true if the view's value is equal to "True" or "False". 
        /// </summary>
        /// <returns>True if the view's value is equal to "True" or "False".</returns>
        public bool IsTrueOrFalseComparisonType()
        {
            M_Condition_ComparisonType comparisonType = (M_Condition_ComparisonType)Value;

            return comparisonType == M_Condition_ComparisonType.True
                || comparisonType == M_Condition_ComparisonType.False;
        }
    }
}