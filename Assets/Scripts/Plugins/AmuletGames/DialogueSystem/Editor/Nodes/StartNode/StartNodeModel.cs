using System;

namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeModel : NodeModelBase
    {
        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public DefaultPort OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of the start node model module class.
        /// </summary>
        public StartNodeModel()
        {
        }
    }
}
