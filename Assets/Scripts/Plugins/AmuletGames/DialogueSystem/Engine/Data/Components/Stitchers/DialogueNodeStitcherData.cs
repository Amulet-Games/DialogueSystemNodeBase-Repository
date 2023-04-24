using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class DialogueNodeStitcherData
    {
        /// <summary>
        /// The data's instance modifier data list.
        /// </summary>
        [SerializeField] public List<MessageModifierData> InstanceModifiersData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node stitcher data class.
        /// </summary>
        public DialogueNodeStitcherData()
        {
            InstanceModifiersData = new();
        }
    }
}