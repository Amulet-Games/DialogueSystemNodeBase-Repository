using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierGroupData
    {
        /// <summary>
        /// The group's event modifiers data.
        /// </summary>
        [SerializeField] public EventModifierData[] ModifiersData;
    }
}