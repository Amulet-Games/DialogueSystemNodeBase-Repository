namespace AG
{
    public class DSStartNodeCallback : DSNodeCallbackFrameBase<DSStartNode, DSStartNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of start node's callback.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSStartNodeCallback(DSStartNode node, DSStartNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Callback action when the connecting node is added on the graph.
        /// <para>StartNode - Constructor.</para>
        /// </summary>
        public override void NodeAddedAction()
        {
            Node.GraphView.SerializeHandler.AddNodeToList(Node);
        }


        /// <summary>
        /// Callback action when the connecting node is removed from the graph.
        /// <para>GraphDeleteSelectionAction - DSGraphView</para>
        /// </summary>
        public override void NodeRemovedAction()
        {
            Node.DisconnectAllPorts();
            Node.GraphView.SerializeHandler.RemoveNodeFromList(Node);
        }
    }
}