using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ConditionModifierGroupData
    {
        /// <summary>
        /// The group's condition modifiers data.
        /// </summary>
        [SerializeField] public ConditionModifierData[] ModifiersData;
    }
}