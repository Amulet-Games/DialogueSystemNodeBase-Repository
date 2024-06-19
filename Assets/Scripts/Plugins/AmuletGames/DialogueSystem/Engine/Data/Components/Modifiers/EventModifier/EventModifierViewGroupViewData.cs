using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierViewGroupViewData
    {
        /// <summary>
        /// The group's event modifier views data.
        /// </summary>
        [SerializeField] public List<EventModifierViewData> ModifierViewsData;


        /// <summary>
        /// Constructor of the event modifier view group view data class.
        /// </summary>
        public EventModifierViewGroupViewData()
        {
            ModifierViewsData = new();
        }
    }
}