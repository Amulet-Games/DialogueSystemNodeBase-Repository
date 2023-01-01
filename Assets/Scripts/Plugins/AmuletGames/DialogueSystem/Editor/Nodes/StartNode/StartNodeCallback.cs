namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeCallback : NodeCallbackFrameBase
    <
        StartNode,
        StartNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node callback module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public StartNodeCallback
        (
            StartNode node,
            StartNodeModel model
        )
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void NodeCreatedAction()
        {
            AddSerializeCache();

            RegisterEvents();

            void AddSerializeCache()
            {
                var serializeHandler = Node.GraphViewer.SerializeHandler;

                // Add node to serialize handler's cache.
                serializeHandler.AddCacheNode(node: Node);

                // Add port to serialize handler's cache.
                serializeHandler.AddCachePort(port: Model.OutputPort);
            }

            void RegisterEvents()
            {
                // Register to PointerEnterEvent.
                RegisterPointerEnterEvent();

                // Register to PointerLeaveEvent.
                RegisterPointerLeaveEvent();
            }
        }


        /// <inheritdoc />
        public override void PreManualRemovedAction()
        {
            // Disconnect output port.
            Model.OutputPort.DisconnectPort();
        }


        /// <inheritdoc />
        public override void PostManualRemovedAction()
        {
            var serializeHandler = Node.GraphViewer.SerializeHandler;

            // Remove node from serialize handler's cache.
            serializeHandler.RemoveCacheNode(node: Node);

            // Remove port from serialize handler's cache.
            serializeHandler.RemoveCachePort(port: Model.OutputPort);
        }
    }
}