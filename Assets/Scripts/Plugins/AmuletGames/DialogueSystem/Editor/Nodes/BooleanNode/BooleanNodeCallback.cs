using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeCallback : NodeCallbackFrameBase
    <
        BooleanNode,
        BooleanNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node callback module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        /// <param name="details">The connecting creation details to set for.</param>
        public BooleanNodeCallback
        (
            BooleanNode node,
            BooleanNodeModel model,
            NodeCreationDetails details
        )
        {
            Node = node;
            Model = model;
            Details = details;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void PostCreatedAction()
        {
            AddSerializeCache();

            void AddSerializeCache()
            {
                var serializeHandler = Node.GraphViewer.SerializeHandler;

                // Node
                serializeHandler.AddCacheNode(node: Node);

                // Port
                serializeHandler.AddCachePort(port: Model.InputPort);
                serializeHandler.AddCachePort(port: Model.TrueOutputPort);
                serializeHandler.AddCachePort(port: Model.FalseOutputPort);
            }
        }


        /// <inheritdoc />
        public override void DelayedManualCreatedAction()
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            ShowNodeOnGraph();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                switch (Details.HorizontalAlignType)
                {
                    case C_Alignment_HorizontalType.Left:
                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.TrueOutputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                        // Width offset.
                        result.x -= Node.localBound.width;

                        break;
                    case C_Alignment_HorizontalType.Middle:
                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                        // Width offset.
                        result.x -= Node.localBound.width / 2;

                        break;
                    case C_Alignment_HorizontalType.Right:
                        // Height offset.
                        result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;
                        break;
                }

                // Apply the final position result to the node.
                Node.SetPosition(newPos: new Rect(result, Vector2Utility.Zero));
            }

            void ConnectConnectorPort()
            {
                // If connnector port is null then return.
                if (Details.ConnectorPort == null)
                    return;

                // Create local reference for the connector port.
                Port connectorPort = Details.ConnectorPort;

                // If the connector port is connecting to another port, disconnect them first.
                if (connectorPort.connected)
                {
                    Node.GraphViewer.DisconnectPort(port: connectorPort);
                }

                // Connect the ports and retrieve the new edge.
                Edge edge;
                if (connectorPort.IsInput())
                {
                    edge = Node.GraphViewer.ConnectPorts
                           (
                               outputPort: Model.TrueOutputPort,
                               inputPort: connectorPort
                           );
                }
                else
                {
                    edge = Node.GraphViewer.ConnectPorts
                           (
                               outputPort: connectorPort,
                               inputPort: Model.InputPort
                           );
                }

                // Register default edge callbacks to the edge.
                DefaultEdgeCallbacks.Register(defaultEdge: edge);
            }

            void ShowNodeOnGraph()
            {
                Node.RemoveFromClassList(StylesConfig.Global_Visible_Hidden);
            }
        }


        /// <inheritdoc />
        public override void PreManualRemovedAction()
        {
            DisconnectInputPort();

            DisconnectTrueOutputPort();

            DisconnectFalseOutputPort();

            void DisconnectInputPort()
            {
                Model.InputPort.NodePreManualRemovedAction();
            }

            void DisconnectTrueOutputPort()
            {
                Model.TrueOutputPort.NodePreManualRemovedAction();
            }

            void DisconnectFalseOutputPort()
            {
                Model.FalseOutputPort.NodePreManualRemovedAction();
            }
        }


        /// <inheritdoc />
        public override void PostManualRemovedAction()
        {
            RemoveSerializeCache();

            void RemoveSerializeCache()
            {
                var serializeHandler = Node.GraphViewer.SerializeHandler;

                // Node
                serializeHandler.RemoveCacheNode(node: Node);

                // Port
                serializeHandler.RemoveCachePort(port: Model.InputPort);
                serializeHandler.RemoveCachePort(port: Model.TrueOutputPort);
                serializeHandler.RemoveCachePort(port: Model.FalseOutputPort);
            }
        }


        // ----------------------------- Set Node Min Max Width Task -----------------------------
        /// <inheritdoc />
        protected override void SetNodeMinMaxWidth()
        {
            SetNodeMinWidth();

            SetMaxWidthProperties();

            void SetNodeMinWidth()
            {
                Node.style.minWidth = NodesConfig.BooleanNodeMinWidth;
            }

            void SetMaxWidthProperties()
            {
                // Node
                Node.style.maxWidth =
                    NodesConfig.BooleanNodeMinWidth + NodesConfig.BooleanNodeMaxWidthBuffer;

                // Node title field
                TextField nodeTitleField = Model.NodeTitle_TextContainer.TextField;
                nodeTitleField.RegisterCallback<GeometryChangedEvent>(GeometryChangedAction);

                void GeometryChangedAction(GeometryChangedEvent evt)
                {
                    // Set the title field max width once it's fully created in the editor.
                    nodeTitleField.style.maxWidth =
                        nodeTitleField.contentRect.width + NodesConfig.BooleanNodeMaxWidthBuffer;

                    // Unregister the action once the setup is done.
                    nodeTitleField.UnregisterCallback<GeometryChangedEvent>(GeometryChangedAction);
                }
            }
        }
    }
}