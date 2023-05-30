using System;

namespace AG.DS
{
    [Serializable]
    public class ConditionComparisonTypeIconicEnumFieldModel : IconicEnumFieldModelBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the condition comparison type iconic enum field model class.
        /// </summary>
        public ConditionComparisonTypeIconicEnumFieldModel()
        {
            Value = (int)M_Condition_ComparisonType.True;
        }


        // ----------------------------- Init Field Value -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue()
        {
            EnumField.Init((M_Condition_ComparisonType)Value);

            // Reset the symbol image to match the current value.
            UpdateIconImage();
        }


        // ----------------------------- Update Field Value -----------------------------
        /// <inheritdoc />
        public override void UpdateFieldValueNonAlert() =>
            EnumField.SetValueWithoutNotify((M_Condition_ComparisonType)Value);


        // ----------------------------- Reset Icon Image -----------------------------
        /// <inheritdoc />
        public override void UpdateIconImage()
        {
            var spriteConfig = ConfigResourcesManager.SpriteConfig;
            switch ((M_Condition_ComparisonType)Value)
            {
                case M_Condition_ComparisonType.True:
                    IconImage.sprite = spriteConfig.TrueOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.False:
                    IconImage.sprite = spriteConfig.FalseOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Matches:
                    IconImage.sprite = spriteConfig.MatchOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Equals:
                    IconImage.sprite = spriteConfig.EqualOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.EqualsOrBigger:
                    IconImage.sprite = spriteConfig.EqualOrBiggerOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.EqualsOrSmaller:
                    IconImage.sprite = spriteConfig.EqualOrSmallerOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Bigger:
                    IconImage.sprite = spriteConfig.BiggerOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Smaller:
                    IconImage.sprite = spriteConfig.SmallerOperatorButtonIconSprite;
                    break;
            }
        }


        // ----------------------------- Compare Enum's Value -----------------------------
        /// <summary>
        /// Returns true if the model's value is equal to "True" or "False". 
        /// </summary>
        /// <returns>True if the model's value is equal to "True" or "False".</returns>
        public bool IsTrueOrFalseComparisonType()
        {
            M_Condition_ComparisonType comparisonType = (M_Condition_ComparisonType)Value;

            return comparisonType == M_Condition_ComparisonType.True
                || comparisonType == M_Condition_ComparisonType.False;
        }
    }
}