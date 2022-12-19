using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ConditionModifierData : ModifierDataBase
    {
        /// <summary>
        /// The data's first term variable group data.
        /// </summary>
        [SerializeField] public VariableGroupData FirstTermVariableGroupData;


        /// <summary>
        /// The data's condition comparions type enum value.
        /// </summary>
        [SerializeField] public int ConditionComparisonTypeEnumIndex;


        /// <summary>
        /// The data's second term text value.
        /// </summary>
        [SerializeField] public string SecondTermText;


        /// <summary>
        /// The data's second term float value.
        /// </summary>
        [SerializeField] public float SecondTermFloat;


        /// <summary>
        /// The data's second term variable group data.
        /// </summary>
        [SerializeField] public VariableGroupData SecondTermVariableGoupData;


        /// <summary>
        /// The data's isShowKeyboardInputField value.
        /// </summary>
        [SerializeField] public bool IsShowKeyboardInputField;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the condition modifier data class.
        /// </summary>
        public ConditionModifierData()
        {
            FirstTermVariableGroupData = new();
            SecondTermVariableGoupData = new();
        }
    }
}