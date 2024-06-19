using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ConditionModifierViewGroupViewData
    {
        /// <summary>
        /// The group's condition modifier views data.
        /// </summary>
        [SerializeField] public List<ConditionModifierViewData> ModifierViewsData;


        /// <summary>
        /// Constructor of the condition modifier view group view data class.
        /// </summary>
        public ConditionModifierViewGroupViewData()
        {
            ModifierViewsData = new();
        }
    }
}