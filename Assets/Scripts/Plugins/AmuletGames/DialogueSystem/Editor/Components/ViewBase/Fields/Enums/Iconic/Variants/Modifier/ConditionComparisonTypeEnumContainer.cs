using System;

namespace AG.DS
{
    [Serializable]
    public class ConditionComparisonTypeIconicEnumFieldView : IconicEnumFieldViewBase
    {
        /// <summary>
        /// Constructor of the condition comparison type iconic enum field view class.
        /// </summary>
        public ConditionComparisonTypeIconicEnumFieldView()
        {
            Value = (int)Legacy_Condition_ComparisonType.True;
        }


        // ----------------------------- Init Field Value -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue()
        {
            EnumField.Init((Legacy_Condition_ComparisonType)Value);

            // Update the symbol icon to match the current value.
            UpdateIcon();
        }


        // ----------------------------- Update Field Value -----------------------------
        /// <inheritdoc />
        public override void UpdateFieldValueNonAlert() =>
            EnumField.SetValueWithoutNotify((Legacy_Condition_ComparisonType)Value);


        // ----------------------------- Reset Icon -----------------------------
        /// <inheritdoc />
        public override void UpdateIcon()
        {
            var spriteConfig = ConfigResourcesManager.SpriteConfig;
            switch ((Legacy_Condition_ComparisonType)Value)
            {
                case Legacy_Condition_ComparisonType.True:
                    Icon.sprite = spriteConfig.TrueOperatorIconSprite;
                    break;
                case Legacy_Condition_ComparisonType.False:
                    Icon.sprite = spriteConfig.FalseOperatorIconSprite;
                    break;
                case Legacy_Condition_ComparisonType.Matches:
                    Icon.sprite = spriteConfig.MatchOperatorIconSprite;
                    break;
                case Legacy_Condition_ComparisonType.Equals:
                    Icon.sprite = spriteConfig.EqualOperatorIconSprite;
                    break;
                case Legacy_Condition_ComparisonType.EqualsOrBigger:
                    Icon.sprite = spriteConfig.EqualOrBiggerOperatorIconSprite;
                    break;
                case Legacy_Condition_ComparisonType.EqualsOrSmaller:
                    Icon.sprite = spriteConfig.EqualOrSmallerOperatorIconSprite;
                    break;
                case Legacy_Condition_ComparisonType.Bigger:
                    Icon.sprite = spriteConfig.BiggerOperatorIconSprite;
                    break;
                case Legacy_Condition_ComparisonType.Smaller:
                    Icon.sprite = spriteConfig.SmallerOperatorIconSprite;
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
            Legacy_Condition_ComparisonType comparisonType = (Legacy_Condition_ComparisonType)Value;

            return comparisonType == Legacy_Condition_ComparisonType.True
                || comparisonType == Legacy_Condition_ComparisonType.False;
        }
    }
}