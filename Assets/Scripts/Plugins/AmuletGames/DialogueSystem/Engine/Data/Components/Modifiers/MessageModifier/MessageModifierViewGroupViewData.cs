using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class MessageModifierViewGroupViewData
    {
        /// <summary>
        /// The group's message modifier views data.
        /// </summary>
        [SerializeField] public List<MessageModifierViewData> ModifierViewsData;


        /// <summary>
        /// Constructor of the message modifier view group view data class.
        /// </summary>
        public MessageModifierViewGroupViewData()
        {
            ModifierViewsData = new();
        }
    }
}