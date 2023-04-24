using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventNodeStitcherData
    {
        /// <summary>
        /// The data's modfiier data base data.
        /// </summary>
        [SerializeField] public EventModifierData RootModifierData;


        /// <summary>
        /// The data's instance modifier data list.
        /// </summary>
        [SerializeField] public List<EventModifierData> InstanceModifiersData;


        /// <summary>
        /// The data's segment data.
        /// </summary>
        [SerializeField] public SegmentData SegmentData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node stitcher data class.
        /// </summary>
        public EventNodeStitcherData()
        {
            RootModifierData = new();
            InstanceModifiersData = new();
            SegmentData = new();
        }
    }
}