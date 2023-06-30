using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierGroupModel
    {
        /// <summary>
        /// The group's event modifier models.
        /// </summary>
        [SerializeField] public EventModifierModel[] ModifierModels;
    }
}