using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierModelGroupData
    {
        /// <summary>
        /// The data's event modifier data array.
        /// </summary>
        [SerializeField] public EventModifierData[] ModifiersData;
    }
}