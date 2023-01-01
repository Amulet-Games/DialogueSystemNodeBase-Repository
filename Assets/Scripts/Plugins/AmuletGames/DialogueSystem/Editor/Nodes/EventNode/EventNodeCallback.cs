using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeCallback : NodeCallbackFrameBase
    <
        EventNode,
        EventNodeModel
    >
    {
        /// <summary>
        /// The last pointer position found within the connecting node module. 
        /// </summary>
        Vector2 pointerMovePosition;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node callback module class.
        /// </summary>
        /// <param name="node">The connecting node module to set for.</param>
        /// <param name="model">The connecting model module to set for.</param>
        public EventNodeCallback
        (
            EventNode node,
            EventNodeModel model
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