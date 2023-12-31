using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class MessageModifierGroupData
    {
        /// <summary>
        /// The group's message modifiers data.
        /// </summary>
        [SerializeField] public MessageModifierData[] ModifiersData;
    }
}