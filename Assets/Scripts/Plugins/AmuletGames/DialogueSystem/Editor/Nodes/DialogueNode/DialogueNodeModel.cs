namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeModel : NodeModelBase
    {
        /// <summary>
        /// Port that allows the other nodes to connect to this node.
        /// </summary>
        public DefaultPort InputPort;


        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public DefaultPort OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node model module class.
        /// </summary>
        /// <param name="node">The connecting node to set for.</param>
        public DialogueNodeModel(DialogueNode node)
        {
        }
    }
}