using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ConditionSegmentData
        : SegmentDataFrameBase.ModifierLayout<ConditionModifierData>
    {
        /// <summary>
        /// The data's unmet option display type enum value
        /// </summary>
        [SerializeField] public int UnmetOptionDisplayTypeEnumIndex;
    }
}