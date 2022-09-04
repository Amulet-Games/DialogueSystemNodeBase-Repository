namespace AG
{
    public class DSEndNodeCallback : DSNodeCallbackFrameBase<DSEndNode, DSEndNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of end node's callback.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSEndNodeCallback(DSEndNode node, DSEndNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Callback action when the connecting node is added on the graph.
        /// <para>EndNode - Constructor.</para>
        /// </summary>
        public override void NodeAddedAction()
        {
            Node.GraphView.SerializeHandler.AddNodeToList(Node);
        }


        /// <summary>
        /// Callback action when any of the nodes is deleted by users from the graph manually.
        /// <para>GraphDeleteSelectionAction - DSGraphView</para>
        /// </summary>
        public override void NodeRemovedByManualAction()
        {
            Node.DisconnectAllPorts();
            Node.GraphView.SerializeHandler.RemoveNodeFromList(Node);
        }
    }
}