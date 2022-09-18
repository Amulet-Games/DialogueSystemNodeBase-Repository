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
        /// <inheritdoc />
        public override void InitializedAction()
        {
            Node.GraphView.SerializeHandler.AddNodeToList(Node);
        }


        /// <inheritdoc />
        public override void ManualCreatedAction()
        {
            Node.SetupNewManualCreatedNode();
        }


        /// <inheritdoc />
        public override void PreManualRemovedAction()
        {
            Node.DisconnectAllPorts();
        }


        /// <inheritdoc />
        public override void PostManualRemovedAction()
        {
            Node.GraphView.SerializeHandler.RemoveNodeFromList(Node);
        }
    }
}