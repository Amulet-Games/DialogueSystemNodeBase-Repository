using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierGroupData
    {
        /// <summary>
        /// The group's event modifiers data.
        /// </summary>
        [SerializeField] public List<EventModifierData> ModifiersData;


        /// <summary>
        /// Constructor of the event modifier group data class.
        /// </summary>
        public EventModifierGroupData()
        {
            ModifiersData = new();
        }
    }
}