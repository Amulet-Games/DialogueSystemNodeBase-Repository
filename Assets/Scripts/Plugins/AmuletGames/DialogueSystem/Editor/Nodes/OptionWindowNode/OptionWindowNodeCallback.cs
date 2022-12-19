using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

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
        /// <param name="details">The connecting creation details to set for.</param>
        public OptionWindowNodeCallback
        (
            OptionWindowNode node,
            OptionWindowNodeModel model,
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
            RegisterLanguageChangedEvent();

            AddSerializeCache();

            void RegisterLanguageChangedEvent()
            {
                LanguageChangedEvent.Register(LanguageChangedAction);
            }

            void AddSerializeCache()
            {
                var serializeHandler = Node.GraphViewer.SerializeHandler;

                // Node
                serializeHandler.AddCacheNode(node: Node);

                // Port
                serializeHandler.AddCachePort(port: Model.OutputSingleOptionChannel.Port);
                serializeHandler.AddCachePort(port: Model.InputPort);
            }
        }


        /// <inheritdoc />
        public override void DelayedManualCreatedAction()
        {
            CheckIsOptionChannelCreation();

            ShowNodeOnGraph();

            void CheckIsOptionChannelCreation()
            {
                if (Details.ConnectorType == P_ConnectorType.OptionChannel)
                {
                    Model.OutputSingleOptionChannel.NodeDelayedManualCreatedAction
                    (
                        opponentChannelPort: Details.ConnectorPort
                    );
                }
                else
                {
                    AlignConnectorPosition();

                    ConnectConnectorPort();
                }
            }

            void AlignConnectorPosition()
            {
                // Create a new vector2 result variable to cache the node's current local bound position.
                Vector2 result = Node.localBound.position;

                switch (Details.HorizontalAlignType)
                {
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
                Edge edge = Node.GraphViewer.ConnectPorts
                            (
                                outputPort: connectorPort,
                                inputPort: Model.InputPort
                            );

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

            DisconnectOutputSingleOptionChannel();

            DisconnectOutputMultiOptionChannelGroup();

            void DisconnectInputPort()
            {
                Model.InputPort.NodePreManualRemovedAction();
            }

            void DisconnectOutputSingleOptionChannel()
            {
                Model.OutputSingleOptionChannel.NodePreManualRemovedAction();
            }

            void DisconnectOutputMultiOptionChannelGroup()
            {
                Model.OutputMultiOptionChannelGroup.NodePreManualRemovedAction();
            }
        }


        /// <inheritdoc />
        public override void PostManualRemovedAction()
        {
            UnRegisterLanguageChangedEvent();

            RemoveSerializeCache();

            void UnRegisterLanguageChangedEvent()
            {
                LanguageChangedEvent.UnRegister(LanguageChangedAction);
            }

            void RemoveSerializeCache()
            {
                var serializeHandler = Node.GraphViewer.SerializeHandler;

                // Node
                serializeHandler.RemoveCacheNode(node: Node);

                // Port
                serializeHandler.RemoveCachePort(port: Model.OutputSingleOptionChannel.Port);
                serializeHandler.RemoveCachePort(port: Model.InputPort);

                // Channel Group
                Model.OutputMultiOptionChannelGroup.NodePostManualRemovedAction();
            }
        }


        /// <inheritdoc />
        protected override void LanguageChangedAction()
        {
            UpdateLanguageField();

            void UpdateLanguageField()
            {
                Model.HeaderTextContainer.UpdateLanguageField();
                Model.DialogueSegment.UpdateLanguageFields();
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
                Node.style.minWidth = NodesConfig.OptionWindowNodeMinWidth;
            }

            void SetMaxWidthProperties()
            {
                // Node
                Node.style.maxWidth =
                    NodesConfig.OptionWindowNodeMinWidth + NodesConfig.OptionWindowMaxWidthBuffer;

                // Node title field
                TextField nodeTitleField = Model.NodeTitle_TextContainer.TextField;
                nodeTitleField.RegisterCallback<GeometryChangedEvent>(GeometryChangedAction);

                void GeometryChangedAction(GeometryChangedEvent evt)
                {
                    // Set the title field max width once it's fully created in the editor.
                    nodeTitleField.style.maxWidth =
                        nodeTitleField.contentRect.width + NodesConfig.OptionWindowMaxWidthBuffer;

                    // Unregister the action once the setup is done.
                    nodeTitleField.UnregisterCallback<GeometryChangedEvent>(GeometryChangedAction);
                }
            }
        }
    }
}