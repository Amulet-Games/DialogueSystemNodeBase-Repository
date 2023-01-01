namespace AG.DS
{
    /// <inheritdoc />
    public class OptionWindowNodeCallback : NodeCallbackFrameBase
    <
        OptionWindowNode,
        OptionWindowNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option window node callback module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public OptionWindowNodeCallback
        (
            OptionWindowNode node,
            OptionWindowNodeModel model
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
                serializeHandler.AddCachePort(port: Model.OutputSingleOptionChannel.Port);
                serializeHandler.AddCachePort(port: Model.InputPort);
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

            // Disconnect output single option channel.
            Model.OutputSingleOptionChannel.DisconnectPort();

            // Disconnect output multi option channel group.
            Model.OutputMultiOptionChannelGroup.DisconnectPorts();
        }


        /// <inheritdoc />
        public override void PostManualRemovedAction()
        {
            RemoveSerializeCache();

            UnRegisterEvents();

            void RemoveSerializeCache()
            {
                var serializeHandler = Node.GraphViewer.SerializeHandler;

                // Remove node from serialize handler's cache.
                serializeHandler.RemoveCacheNode(node: Node);

                // Remove ports from serialize handler's cache.
                serializeHandler.RemoveCachePort(port: Model.OutputSingleOptionChannel.Port);
                serializeHandler.RemoveCachePort(port: Model.InputPort);

                // Remove channel group's ports from serialize handler's cache.
                Model.OutputMultiOptionChannelGroup.RemoveCachePorts();
            }

            void UnRegisterEvents()
            {
                LanguageChangedEvent.UnRegister(LanguageChangedAction);
            }
        }


        // ----------------------------- Register additional Events Tasks -----------------------------
        /// <summary>
        /// Register new language changed actions to the connecting node module.
        /// </summary>
        void LanguageChangedAction()
        {
            // Update header text's language
            Model.HeaderTextContainer.UpdateLanguageField();
        }
    }
}