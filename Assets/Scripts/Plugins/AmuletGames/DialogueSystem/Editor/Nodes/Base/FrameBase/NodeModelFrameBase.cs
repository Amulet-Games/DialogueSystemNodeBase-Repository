namespace AG.DS
{
    public abstract class NodeModelFrameBase
    <
        TNode
    >
        : NodeModelBase
        where TNode : NodeBase
    {
        /// <summary>
        /// Reference of the node element.
        /// </summary>
        protected TNode Node;


        // ----------------------------- Remove Cache Ports All -----------------------------
        /// <summary>
        /// Remove any ports that are in the node from the serialize handler cache.
        /// </summary>
        public abstract void RemovePortsAll();


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <summary>
        /// Disconnect any ports that are in the node.
        /// </summary>
        public abstract void DisconnectPortsAll();
    }
}