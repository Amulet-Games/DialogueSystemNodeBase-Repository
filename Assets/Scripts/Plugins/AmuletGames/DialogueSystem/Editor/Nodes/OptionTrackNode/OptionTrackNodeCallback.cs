using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionTrackNodeCallback : NodeCallbackFrameBase
    <
        OptionTrackNode,
        OptionTrackNodeModel
    >
    {
        /// <summary>
        /// The last pointer position found within the connecting node module. 
        /// </summary>
        Vector2 pointerMovePosition;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option track node callback module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public OptionTrackNodeCallback
        (
            OptionTrackNode node,
            OptionTrackNodeModel model
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
                serializeHandler.AddCachePort(port: Model.InputSingleOptionChannel.Port);
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

                // Register to PointerMoveEvent.
                RegisterPointerMoveEvent();

                // Register to GeometryChangedEvent.
                RegisterGeometryChangedEvent();
            }
        }


        /// <inheritdoc />
        public override void PreManualRemovedAction()
        {
            // Disconnect input single option channel.
            Model.InputSingleOptionChannel.DisconnectPort();

            // Disconnect output port.
            Model.OutputPort.DisconnectPort();
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
                serializeHandler.RemoveCachePort(port: Model.InputSingleOptionChannel.Port);
                serializeHandler.RemoveCachePort(port: Model.OutputPort);
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