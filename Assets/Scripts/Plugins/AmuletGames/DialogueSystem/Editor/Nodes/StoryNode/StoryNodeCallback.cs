namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeCallback : NodeCallbackFrameBase
    <
        StoryNode,
        StoryNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node callback module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public StoryNodeCallback
        (
            StoryNode node,
            StoryNodeModel model
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
                // Register to LanguageChangedEvent.
                LanguageChangedEvent.Register(LanguageChangedAction);

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


        // ----------------------------- Register additional Events Tasks -----------------------------
        /// <summary>
        /// Register new language changed actions to the connecting node module.
        /// </summary>
        void LanguageChangedAction()
        {
            Model.FirstTextlineTextContainer.UpdateLanguageField();
            Model.SecondTextlineTextContainer.UpdateLanguageField();
            Model.AudioClipContainer.UpdateLanguageField();
        }
    }
}