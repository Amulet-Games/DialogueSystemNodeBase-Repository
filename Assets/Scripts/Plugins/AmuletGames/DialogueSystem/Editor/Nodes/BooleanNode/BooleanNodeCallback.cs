using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeCallback : NodeCallbackFrameBase
    <
        BooleanNode,
        BooleanNodeModel
    >
    {
        /// <summary>
        /// The last pointer position found within the connecting node module. 
        /// </summary>
        Vector2 pointerMovePosition;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node callback module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public BooleanNodeCallback
        (
            BooleanNode node,
            BooleanNodeModel model
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
                serializeHandler.AddCachePort(port: Model.TrueOutputPort);
                serializeHandler.AddCachePort(port: Model.FalseOutputPort);
            }

            void RegisterEvents()
            {
                // Register to PointerEnterEvent.
                RegisterPointerEnterEvent();

                // Register to PointerLeaveEvent.
                RegisterPointerLeaveEvent();

                // Register to PointerMoveEvent.
                RegisterPointerMoveEvent();

                // Register to GeometryChangedEvent.
                RegisterGeometryChangedEvent();
            }
        }


        /// <inheritdoc />
        public override void PreManualRemovedAction()
        {
            // Disconnect input port.
            Model.InputPort.DisconnectPort();

            // Disconnect true output port.
            Model.TrueOutputPort.DisconnectPort();

            // Disconnect false output port.
            Model.FalseOutputPort.DisconnectPort();
        }


        /// <inheritdoc />
        public override void PostManualRemovedAction()
        {
            var serializeHandler = Node.GraphViewer.SerializeHandler;

            // Remove node from serialize handler's cache.
            serializeHandler.RemoveCacheNode(node: Node);

            // Remove ports from serialize handler's cache.
            serializeHandler.RemoveCachePort(port: Model.InputPort);
            serializeHandler.RemoveCachePort(port: Model.TrueOutputPort);
            serializeHandler.RemoveCachePort(port: Model.FalseOutputPort);
        }


        // ----------------------------- Register additional Events Tasks -----------------------------
        /// <summary>
        /// Register new pointer move actions to the connecting node module.
        /// </summary>
        void RegisterPointerMoveEvent()
        {
            Node.RegisterCallback<PointerMoveEvent>(callback =>
            {
                pointerMovePosition = callback.position;
            });
        }


        /// <summary>
        /// Register new geometry changed actions to the connecting node module.
        /// </summary>
        void RegisterGeometryChangedEvent()
        {
            Node.RegisterCallback<GeometryChangedEvent>(callback =>
            {
                if (!Node.worldBound.Contains(pointerMovePosition))
                {
                    // Remove from hover class.
                    Node.NodeBorder.RemoveFromClassList(StylesConfig.Node_Border_Hover);
                }
            });
        }
    }
}