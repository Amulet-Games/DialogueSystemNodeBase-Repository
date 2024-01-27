using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class MessageModifierGroupData
    {
        /// <summary>
        /// The group's message modifiers data.
        /// </summary>
        [SerializeField] public List<MessageModifierData> ModifiersData;


        /// <summary>
        /// Constructor of the message modifier group data class.
        /// </summary>
        public MessageModifierGroupData()
        {
            ModifiersData = new();
        }
    }
}