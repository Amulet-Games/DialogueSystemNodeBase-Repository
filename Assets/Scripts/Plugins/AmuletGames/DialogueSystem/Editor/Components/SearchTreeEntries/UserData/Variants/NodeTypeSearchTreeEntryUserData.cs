namespace AG.DS
{
    public class NodeTypeSearchTreeEntryUserData
    {
        /// <summary>
        /// The node type of the entry.
        /// </summary>
        public Node NodeType { get; }


        /// <summary>
        /// Constructor of the node type search tree entry user data class.
        /// </summary>
        /// <param name="entry">The search tree entry to set for.</param>
        /// <param name="nodeType">The node type to set for.</param>
        public NodeTypeSearchTreeEntryUserData(Node nodeType)
        {
            NodeType = nodeType;
        }
    }
}