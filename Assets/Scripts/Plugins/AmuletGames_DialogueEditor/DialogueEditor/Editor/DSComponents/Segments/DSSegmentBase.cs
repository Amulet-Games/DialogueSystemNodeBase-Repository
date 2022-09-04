using System;
using UnityEngine.UIElements;

namespace AG
{
    [Serializable]
    public abstract class DSSegmentBase
    {
        /// <summary>
        /// Is segment expanded or closed.
        /// </summary>
        public bool IsExpanded;

        /// <summary>
        /// A box container that store all it's content visual elements.
        /// </summary>
        public Box ContentBox;

        /// <summary>
        /// Button that can expand or shrink segment's content when pressed.
        /// </summary>
        public Button ExpandButton;


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in this segment.
        /// </summary>
        /// <param name="node">Node of which this segment is created for.</param>
        public abstract void SetupSegment(DSNodeBase node);


        // ----------------------------- Change IsExpanded Status Services -----------------------------
        /// <summary>
        /// Switch the isExpanded status and resize itself to show the changes.
        /// </summary>
        protected void SwitchSegmentIsExpanded()
        {
            IsExpanded = !IsExpanded;
            RefreshSegmentIsExpanded();
        }


        /// <summary>
        /// Load isExpanded status from another saved segment and resize itself to show the changes.
        /// </summary>
        /// <param name="source">The segment that was previously saved and now it's used to loaded from.</param>
        protected void LoadIsExpandedValue(DSSegmentBase source)
        {
            IsExpanded = source.IsExpanded;
            RefreshSegmentIsExpanded();
        }


        /// <summary>
        /// Expand or shrink segment based on its current isExpanded status.
        /// </summary>
        void RefreshSegmentIsExpanded()
        {
            DSElementDisplayUtility.ToggleElementDisplay(!IsExpanded, ContentBox);
        }
    }
}