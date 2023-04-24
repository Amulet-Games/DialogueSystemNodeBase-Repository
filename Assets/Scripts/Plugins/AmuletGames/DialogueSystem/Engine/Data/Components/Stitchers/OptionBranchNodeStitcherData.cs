using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionBranchNodeStitcherData
    {
        /// <summary>
        /// The data's modifier data list.
        /// </summary>
        [SerializeField] public List<ConditionModifierData> InstanceModifiersData;


        /// <summary>
        /// The data's segment data.
        /// </summary>
        [SerializeField] public SegmentData SegmentData;


        /// <summary>
        /// The data's unmet option display type enum value
        /// </summary>
        [SerializeField] public int UnmetOptionDisplayTypeEnumIndex;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option branch node stitcher data class.
        /// </summary>
        public OptionBranchNodeStitcherData()
        {
            InstanceModifiersData = new();
            SegmentData = new();
        }
    }
}