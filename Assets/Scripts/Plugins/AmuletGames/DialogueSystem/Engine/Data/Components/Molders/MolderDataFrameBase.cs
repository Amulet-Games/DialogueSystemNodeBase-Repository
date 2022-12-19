using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class MolderDataFrameBase
    <
        TModifierData,
        TSegmentData
    >
        where TModifierData : ModifierDataBase, new()
        where TSegmentData : SegmentDataFrameBase.ModifierLayout<TModifierData>, new()
    {
        /// <summary>
        /// The data's modifier layout segment frame base data.
        /// </summary>
        [SerializeField] public TSegmentData SegmentData;


        /// <summary>
        /// The data's modfiier data base data.
        /// </summary>
        [SerializeField] public TModifierData RootModifierData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the molder data frame base class.
        /// </summary>
        public MolderDataFrameBase()
        {
            SegmentData = new();
            RootModifierData = new();
        }
    }
}