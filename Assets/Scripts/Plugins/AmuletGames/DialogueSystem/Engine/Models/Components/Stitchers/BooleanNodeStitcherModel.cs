using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class BooleanNodeStitcherModel
    {
        /// <summary>
        /// The stitcher's root condition modifier model.
        /// </summary>
        [SerializeField] public ConditionModifierModel RootModifierModel;


        /// <summary>
        /// The stitcher's instance condition modifier models.
        /// </summary>
        [SerializeField] public List<ConditionModifierModel> InstanceModifiersModels;


        /// <summary>
        /// The stitcher's segment model.
        /// </summary>
        [SerializeField] public SegmentModel SegmentModel;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node stitcher model class.
        /// </summary>
        public BooleanNodeStitcherModel()
        {
            RootModifierModel = new();
            InstanceModifiersModels = new();
            SegmentModel = new();
        }
    }
}