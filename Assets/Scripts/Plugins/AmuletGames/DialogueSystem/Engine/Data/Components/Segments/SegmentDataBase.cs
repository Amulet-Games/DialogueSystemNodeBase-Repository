using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public abstract class SegmentDataBase
    {
        /// <summary>
        /// The data's isExpanded value.
        /// </summary>
        [SerializeField] public bool IsExpanded;
    }
}