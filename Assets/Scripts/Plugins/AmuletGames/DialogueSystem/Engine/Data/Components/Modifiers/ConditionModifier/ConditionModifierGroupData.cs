using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ConditionModifierGroupData
    {
        /// <summary>
        /// The group's condition modifiers data.
        /// </summary>
        [SerializeField] public List<ConditionModifierViewData> ModifiersData;


        /// <summary>
        /// Constructor of the condition modifier group data class.
        /// </summary>
        public ConditionModifierGroupData()
        {
            ModifiersData = new();
        }
    }
}