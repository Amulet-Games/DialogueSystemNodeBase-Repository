namespace AG.DS
{
    /// <inheritdoc />
    public class PreviewNodeCallback : NodeCallbackFrameBase
    <
        PreviewNode,
        PreviewNodeModel
    >
    {
        /// <summary>
        /// Constructor of the preview node callback module class.
        /// </summary>
        /// <param name="node">The connecting node module to set for.</param>
        /// <param name="model">The connecting model module to set for.</param>
        public PreviewNodeCallback
        (
            PreviewNode node,
            PreviewNodeModel model
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

                // Add ports to serialize handler's cache.
                serializeHandler.AddCachePort(port: Model.InputPort);
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
            // Disconnect input port.
            Model.InputPort.DisconnectPort();

            // Disconnect output port.
            Model.OutputPort.DisconnectPort();
        }


        /// <inheritdoc />
        public override void PostManualRemovedAction()
        {
            var serializeHandler = Node.GraphViewer.SerializeHandler;

            // Remove node from serialize handler's cache.
            serializeHandler.RemoveCacheNode(node: Node);

            // Remove ports from serialize handler's cache.
            serializeHandler.RemoveCachePort(port: Model.InputPort);
            serializeHandler.RemoveCachePort(port: Model.OutputPort);
        }
    }
}