using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class SegmentBase
    {
        /// <summary>
        /// The box UIElement that stores all the visual elements that are included in the segment's content section.
        /// </summary>
        public Box ContentBox;


        /// <summary>
        /// Button that can expand or shrink the segment's content when clicked.
        /// </summary>
        protected Button ExpandButton;


        /// <summary>
        /// Is the segment expanded?
        /// </summary>
        protected bool IsExpanded;


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that are needed in the segment.
        /// </summary>
        /// <param name="node">Node of which this segment is created for.</param>
        public abstract void CreateRootElements(NodeBase node);


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
            VisualElementHelper.UpdateElementDisplay
            (
                condition: !IsExpanded,
                element: ContentBox
            );
        }
    }
}