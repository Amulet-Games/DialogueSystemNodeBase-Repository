namespace AG.DS
{
    /// <summary>
    /// Holds the raw data that can be used when creating a new node.
    /// </summary>
    public class NodeCreateDetailBase
    {
        //public enum HorizontalAlignment
        //{
        //    Left,

        //    Middle,

        //    Right,

        //    Free
        //}

        /// <summary>
        /// The horizontal alignment type to use when creating the node to the graph.
        /// </summary>
        public HorizontalAlignment HorizontalAlignmentType { get; private set; }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set a new value to the horizontal alignment type.
        /// </summary>
        /// <param name="value">The new value to set for.</param>
        public void SetHorizontalAlignmentType(HorizontalAlignment value) => HorizontalAlignmentType = value;
    }
}