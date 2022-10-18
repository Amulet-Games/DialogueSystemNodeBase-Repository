using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    public class DSEndNodeCallback : DSNodeCallbackFrameBase<
        DSEndNode,
        DSEndNodeModel,
        DSEndNodeSerializer
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of end node's callback.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        /// <param name="serializer">Serializer of which this presenter is connecting upon.</param>
        public DSEndNodeCallback
        (
            DSEndNode node,
            DSEndNodeModel model,
            DSEndNodeSerializer serializer
        )
        {
            Node = node;
            Model = model;
            Serializer = serializer;
        }


        // ----------------------------- Callbacks -----------------------------
        /// <inheritdoc />
        public override void InitializedAction()
        {
            AddNodeToSerializeList();

            void AddNodeToSerializeList()
            {
                Node.GraphView.SerializeHandler.AddNodeToList(Node);
            }
        }


        /// <inheritdoc />
        public override void DelayedManualCreatedAction()
        {
            AlignConnectorPosition();

            ConnectConnectorPort();

            ShowNodeOnGraph();

            CommonDelayedCreatedAction();

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                // Height offset.
                result.y -= (Node.titleContainer.worldBound.height + Model.InputPort.localBound.position.y + DSNodesConfig.ManualCreateYOffset) / Node.GraphView.scale;

                if (Details.HorizontalAlignType == C_Alignment_HorizontalType.Middle)
                {
                    // width offset.
                    result.x -= Node.localBound.width / 2;
                }

                // Apply the final position result to the node.
                Node.SetPosition(new Rect(result, DSVector2Utility.Zero));
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
                    Node.GraphView.DisconnectPort(connectorPort);
                }

                // Connect the ports and retrieve the new edge.
                Edge edge = Node.GraphView.ConnectPorts(connectorPort, Model.InputPort);

                // Register default edge callbacks to the edge.
                DSDefaultEdgeCallbacks.Register(edge);
            }

            void ShowNodeOnGraph()
            {
                Node.RemoveFromClassList(DSStylesConfig.Global_Visible_Hidden);
            }
        }


        /// <inheritdoc />
        public override void DelayedLoadCreatedAction()
        {
            CommonDelayedCreatedAction();
        }


        /// <inheritdoc />
        public override void CommonDelayedCreatedAction()
        {
            SetNodeMinWidth();

            SetMaxWidthProperties();

            void SetNodeMinWidth()
            {
                Node.style.minWidth = DSNodesConfig.EndNodeMinWidth;
            }

            void SetMaxWidthProperties()
            {
                // Node
                Node.style.maxWidth = DSNodesConfig.EndNodeMinWidth + DSNodesConfig.EndNodeMaxWidthBuffer;

                // Node title field
                TextField nodeTitleField = Model.NodeTitle_TextContainer.TextField;
                nodeTitleField.RegisterCallback<GeometryChangedEvent>(GeometryChangedAction);

                void GeometryChangedAction(GeometryChangedEvent evt)
                {
                    // Set the title field max width once it's fully created in the editor.
                    nodeTitleField.style.maxWidth = nodeTitleField.contentRect.width + DSNodesConfig.EndNodeMaxWidthBuffer;

                    // Unregister the action once the setup is done.
                    nodeTitleField.UnregisterCallback<GeometryChangedEvent>(GeometryChangedAction);
                }
            }
        }


        /// <inheritdoc />
        public override void PreManualRemovedAction()
        {
            DisconnectInputPort();

            void DisconnectInputPort()
            {
                Model.InputPort.NodePreManualRemovedAction();
            }
        }


        /// <inheritdoc />
        public override void PostManualRemovedAction()
        {
            RemoveNodeFromSerializeList();

            void RemoveNodeFromSerializeList()
            {
                Node.GraphView.SerializeHandler.RemoveNodeFromList(Node);
            }
        }
    }
}