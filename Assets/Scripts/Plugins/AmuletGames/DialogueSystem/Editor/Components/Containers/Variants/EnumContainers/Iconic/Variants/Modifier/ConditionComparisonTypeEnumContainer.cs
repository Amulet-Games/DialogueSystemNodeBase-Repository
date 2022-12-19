using System;

namespace AG.DS
{
    [Serializable]
    public class ConditionComparisonTypeEnumContainer : IconicEnumContainerBase
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the condition comparison type enum container component class.
        /// </summary>
        public ConditionComparisonTypeEnumContainer()
        {
            Value = (int)M_Condition_ComparisonType.True;
        }


        // ----------------------------- Init Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue()
        {
            EnumField.Init((M_Condition_ComparisonType)Value);

            // Reset the symbol image to match the current value.
            UpdateIconImage();
        }


        // ----------------------------- Update Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void UpdateFieldValueNonAlert() =>
            EnumField.SetValueWithoutNotify((M_Condition_ComparisonType)Value);


        // ----------------------------- Reset Icon Image Services -----------------------------
        /// <inheritdoc />
        public override void UpdateIconImage()
        {
            switch ((M_Condition_ComparisonType)Value)
            {
                case M_Condition_ComparisonType.True:
                    IconImage.sprite = AssetsConfig.TrueOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.False:
                    IconImage.sprite = AssetsConfig.FalseOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Matches:
                    IconImage.sprite = AssetsConfig.MatchOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Equals:
                    IconImage.sprite = AssetsConfig.EqualOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.EqualsOrBigger:
                    IconImage.sprite = AssetsConfig.EqualOrBiggerOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.EqualsOrSmaller:
                    IconImage.sprite = AssetsConfig.EqualOrSmallerOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Bigger:
                    IconImage.sprite = AssetsConfig.BiggerOperatorButtonIconSprite;
                    break;
                case M_Condition_ComparisonType.Smaller:
                    IconImage.sprite = AssetsConfig.SmallerOperatorButtonIconSprite;
                    break;
            }
        }


        // ----------------------------- Compare Enum's Value Services -----------------------------
        /// <summary>
        /// Returns true if the enum container's value is equal to "True" or "False". 
        /// </summary>
        /// <returns>True if the enum container's value is equal to "True" or "False".</returns>
        public bool IsTrueOrFalseComparisonType()
        {
            M_Condition_ComparisonType comparisonType = (M_Condition_ComparisonType)Value;

            return comparisonType == M_Condition_ComparisonType.True
                || comparisonType == M_Condition_ComparisonType.False;
        }
    }
}