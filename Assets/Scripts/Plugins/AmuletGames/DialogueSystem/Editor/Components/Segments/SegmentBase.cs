using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public abstract class SegmentBase
    {
        /// <summary>
        /// Is segment expanded or closed.
        /// </summary>
        public bool IsExpanded;


        /// <summary>
        /// The box UIElement that stores the content section's visual elements.
        /// </summary>
        public Box ContentBox;


        /// <summary>
        /// Button that can expand or shrink segment's content when pressed.
        /// </summary>
        public Button ExpandButton;


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in the segment.
        /// </summary>
        /// <param name="node">Node of which this segment is created for.</param>
        public abstract void SetupSegment(NodeBase node);


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Load the isExpanded value from the given data.
        /// </summary>
        /// <param name="data">The given data to load from.</param>
        protected void LoadIsExpandedValue(SegmentDataBase data)
        {
            IsExpanded = data.IsExpanded;
            UpdateSegmentIsExpanded();
        }


        // ----------------------------- IsExpanded Utility -----------------------------
        /// <summary>
        /// Force expand the segment if it's currently closed.
        /// </summary>
        public void ForceExpand()
        {
            if (!IsExpanded)
            {
                IsExpanded = true;
                UpdateSegmentIsExpanded();
            }
        }


        /// <summary>
        /// Switch the isExpanded status and resize itself to show the changes.
        /// </summary>
        protected void SwitchSegmentIsExpanded()
        {
            IsExpanded = !IsExpanded;
            UpdateSegmentIsExpanded();
        }


        // ----------------------------- Update Segment IsExpanded Tasks -----------------------------
        /// <summary>
        /// Expand or shrink segment based on its current isExpanded status.
        /// </summary>
        void UpdateSegmentIsExpanded()
        {
            VisualElementHelper.ToggleElementDisplay
            (
                condition: !IsExpanded,
                element: ContentBox
            );
        }
    }
}