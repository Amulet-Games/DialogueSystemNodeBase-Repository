using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionBranchNodeStitcherModel
    {
        /// <summary>
        /// The stitcher's instance condition modifier models
        /// </summary>
        [SerializeField] public List<ConditionModifierModel> InstanceModifierModels;


        /// <summary>
        /// The stitcher's segment model.
        /// </summary>
        [SerializeField] public SegmentModel SegmentModel;


        /// <summary>
        /// The stitcher's unmet option display type enum value.
        /// </summary>
        [SerializeField] public int UnmetOptionDisplayTypeEnumIndex;


        /// <summary>
        /// Constructor of the option branch node stitcher model class.
        /// </summary>
        public OptionBranchNodeStitcherModel()
        {
            InstanceModifierModels = new();
            SegmentModel = new();
        }
    }
}