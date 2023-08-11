using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class DialogueNodeStitcherModel
    {
        /// <summary>
        /// The stitcher's instance message modifier models.
        /// </summary>
        [SerializeField] public List<MessageModifierModel> InstanceModifierModels;


        /// <summary>
        /// Constructor of the dialogue node stitcher model class.
        /// </summary>
        public DialogueNodeStitcherModel()
        {
            InstanceModifierModels = new();
        }
    }
}