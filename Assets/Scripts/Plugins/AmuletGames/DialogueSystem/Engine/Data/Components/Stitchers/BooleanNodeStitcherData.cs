using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class BooleanNodeStitcherData
    {
        /// <summary>
        /// The data's modfiier data base data.
        /// </summary>
        [SerializeField] public ConditionModifierData RootModifierData;


        /// <summary>
        /// The data's instance modifier data list.
        /// </summary>
        [SerializeField] public List<ConditionModifierData> InstanceModifiersData;


        /// <summary>
        /// The data's segment data.
        /// </summary>
        [SerializeField] public SegmentData SegmentData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node stitcher data class.
        /// </summary>
        public BooleanNodeStitcherData()
        {
            RootModifierData = new();
            InstanceModifiersData = new();
            SegmentData = new();
        }
    }
}