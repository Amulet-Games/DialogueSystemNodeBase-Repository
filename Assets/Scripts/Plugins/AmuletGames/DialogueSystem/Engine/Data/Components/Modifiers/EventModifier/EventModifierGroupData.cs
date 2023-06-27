using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierGroupData
    {
        /// <summary>
        /// The data's event modifier data array.
        /// </summary>
        [SerializeField] public EventModifierData[] ModifiersData;
    }
}