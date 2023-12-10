using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ConditionModifierGroupModel
    {
        /// <summary>
        /// The group's condition modifier models.
        /// </summary>
        [SerializeField] public ConditionModifierModel[] ModifierModels;
    }
}