namespace AG
{
    public class DSEventNodeCallback : DSNodeCallbackFrameBase<DSEventNode, DSEventNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event node's callback.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSEventNodeCallback(DSEventNode node, DSEventNodeModel model)
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