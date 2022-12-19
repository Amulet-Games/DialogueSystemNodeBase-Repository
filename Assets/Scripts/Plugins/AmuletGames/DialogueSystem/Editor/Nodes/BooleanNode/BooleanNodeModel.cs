namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeModel : NodeModelBase
    {
        /// <summary>
        /// A special node's UI style that combined the use of segment, modifier and content button together.
        /// </summary>
        public ConditionMolder ConditionMolder;


        // ----------------------------- Ports -----------------------------
        /// <summary>
        /// Port that allows other nodes to connect to this node.
        /// </summary>
        public DefaultPort InputPort;


        /// <summary>
        /// Port that allows this node to branch out and move on from the "True" marked branch.
        /// </summary>
        public DefaultPort TrueOutputPort;


        /// <summary>
        /// Port that allows this node to branch out and move on from the "False" marked branch.
        /// </summary>
        public DefaultPort FalseOutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of the boolean node model module class.
        /// </summary>
        /// <param name="node">The connecting node to set for.</param>
        public BooleanNodeModel(BooleanNode node)
        {
            ConditionMolder = new();
        }
    }
}
