namespace AG.DS
{
    /// <summary>
    /// Holds the raw data that can be used when creating a new node.
    /// </summary>
    public class NodeCreateDetailBase
    {
        /// <summary>
        /// The horizontal alignment type to use when creating the node to the graph.
        /// </summary>
        public HorizontalAlignmentType HorizontalAlignmentType { get; private set; }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Set a new value to the horizontal alignment type.
        /// </summary>
        /// <param name="value">The horizontal alignment type to set for.</param>
        public void SetTypeHorizontalAlignment(HorizontalAlignmentType value) => HorizontalAlignmentType = value;
    }
}