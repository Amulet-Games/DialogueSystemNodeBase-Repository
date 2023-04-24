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
        /// Responsible for communicating with the other module classes,
        /// <br>and creating the frame base when it's first initialized.</br>
        /// </summary>
        protected TNode Node;


        // ----------------------------- Remove Cache Ports All -----------------------------
        /// <summary>
        /// Remove any ports that are in the node from the serialize handler cache.
        /// </summary>
        public abstract void RemoveCachePortsAll();


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <summary>
        /// Disconnect any ports that are in the node.
        /// </summary>
        public abstract void DisconnectPortsAll();
    }
}