using System.Collections.Generic;
using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public partial class SegmentDataFrameBase
    {
        [Serializable]
        public abstract class ModifierLayout<TModifierData>
            : SegmentDataBase
            where TModifierData : ModifierDataBase
        {
            /// <summary>
            /// The data's isHidden value.
            /// </summary>
            [SerializeField] public bool IsHidden;


            /// <summary>
            /// The data's modifier data list.
            /// </summary>
            [SerializeField] public List<TModifierData> ModifierDataList;


            // ----------------------------- Constructor -----------------------------
            /// <summary>
            /// Constructor of the segment data frame base class.
            /// </summary>
            public ModifierLayout()
            {
                ModifierDataList = new();
            }
        }
    }
}