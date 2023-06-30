using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventNodeStitcherModel
    {
        /// <summary>
        /// The stitcher's root event modifier model.
        /// </summary>
        [SerializeField] public EventModifierModel RootModifierModel;


        /// <summary>
        /// The stitcher's instance event modifier models.
        /// </summary>
        [SerializeField] public List<EventModifierModel> InstanceModifierModels;


        /// <summary>
        /// The stitcher's segment model.
        /// </summary>
        [SerializeField] public SegmentModel SegmentModel;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node stitcher model class.
        /// </summary>
        public EventNodeStitcherModel()
        {
            RootModifierModel = new();
            InstanceModifierModels = new();
            SegmentModel = new();
        }
    }
}