namespace AG.DS
{
    /// <summary>
    /// Holds all the different callbacks' method of the connecting node module.
    /// </summary>
    public abstract class NodeCallbackBase
    {
        /// <summary>
        /// Callback action when the node has finished its creation process and added on the graph fully.
        /// </summary>
        public abstract void NodeCreatedAction();


        /// <summary>
        /// Callback action when the nodes is going to be deleted by users from the graph manually.
        /// <br>This action happens before the node is being removed from the graph.</br>
        /// </summary>
        public abstract void PreManualRemovedAction();


        /// <summary>
        /// Callback action when the nodes is deleted by users from the graph manually.
        /// <br>This action happens after the <see cref="PreManualRemovedAction"/> is called.</br>
        /// </summary>
        public abstract void PostManualRemovedAction();
    }
}