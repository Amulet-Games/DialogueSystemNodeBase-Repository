using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ConditionModifierModel
    {
        /// <summary>
        /// The modifier's first term variable group model.
        /// </summary>
        [SerializeField] public VariableGroupModel FirstTermVariableGroupModel;


        /// <summary>
        /// The modifier's condition comparisons type enum value.
        /// </summary>
        [SerializeField] public int ConditionComparisonTypeEnumIndex;


        /// <summary>
        /// The modifier's second term text value.
        /// </summary>
        [SerializeField] public string SecondTermText;


        /// <summary>
        /// The modifier's second term float value.
        /// </summary>
        [SerializeField] public float SecondTermFloat;


        /// <summary>
        /// The modifier's second term variable group model.
        /// </summary>
        [SerializeField] public VariableGroupModel SecondTermVariableGroupModel;


        /// <summary>
        /// The modifier's isShowKeyboardInputField value.
        /// </summary>
        [SerializeField] public bool IsShowKeyboardInputField;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the condition modifier model class.
        /// </summary>
        public ConditionModifierModel()
        {
            FirstTermVariableGroupModel = new();
            SecondTermVariableGroupModel = new();
        }
    }
}