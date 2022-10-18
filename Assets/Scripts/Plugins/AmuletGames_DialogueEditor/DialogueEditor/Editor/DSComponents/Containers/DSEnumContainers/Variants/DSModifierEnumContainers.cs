using System;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public class ConditionComparisonTypeEnumContainer : EnumContainerBase
    {
        /// <summary>
        /// Constructor of condition comparison type enum container.
        /// </summary>
        public ConditionComparisonTypeEnumContainer()
        {
            Value = (int)M_Condition_ComparisonType.True;
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


        // ----------------------------- Set Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void SetFieldValueNonAlert(int newValue)
            =>
            EnumField.SetValueWithoutNotify((M_Condition_ComparisonType)newValue);


        // ----------------------------- Init Field Value Tasks -----------------------------
        /// <inheritdoc />
        public override void InitFieldValue()
            =>
            EnumField.Init((M_Condition_ComparisonType)Value);
    }
}