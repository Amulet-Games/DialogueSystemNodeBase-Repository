using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionTrackNodeCallback : NodeCallbackFrameBase
    <
        OptionTrackNode,
        OptionTrackNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option track node callback module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        /// <param name="details">The connecting creation details to set for.</param>
        public OptionTrackNodeCallback
        (
            OptionTrackNode node,
            OptionTrackNodeModel model,
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
                serializeHandler.AddCachePort(port: Model.InputSingleOptionChannel.Port);
                serializeHandler.AddCachePort(port: Model.OutputPort);
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
                    Model.InputSingleOptionChannel.NodeDelayedManualCreatedAction
                    (
                        opponentChannelPort: Details.ConnectorPort
                    );
                }
                else
                {
                    AlignConnectorPosition();

                    ConnectConnectorPort();
                }

                void AlignConnectorPosition()
                {
                    // Create a new vector2 result variable to cache the node's current local bound position.
                    Vector2 result = Node.localBound.position;

                    switch (Details.HorizontalAlignType)
                    {
                        case C_Alignment_HorizontalType.Left:

                            // Height offset.
                            result.y -= (Node.titleContainer.worldBound.height + Model.OutputPort.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                            // Width offset.
                            result.x -= Node.localBound.width;

                            break;
                        case C_Alignment_HorizontalType.Middle:

                            // Height offset.
                            result.y -= (Node.titleContainer.worldBound.height + Model.InputSingleOptionChannel.Port.localBound.position.y + NodesConfig.ManualCreateYOffset) / Node.GraphViewer.scale;

                            // Width offset.
                            result.x -= Node.localBound.width / 2;
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
                                    outputPort: Model.OutputPort,
                                    inputPort: connectorPort
                                );

                    // Register default edge callbacks to the edge.
                    DefaultEdgeCallbacks.Register(defaultEdge: edge);
                }
            }

            void ShowNodeOnGraph()
            {
                Node.RemoveFromClassList(StylesConfig.Global_Visible_Hidden);
            }
        }


        /// <inheritdoc />
        public override void PreManualRemovedAction()
        {
            DisconnectInputSingleOptionChannel();

            DisconnecOutputPort();

            void DisconnectInputSingleOptionChannel()
            {
                Model.InputSingleOptionChannel.NodePreManualRemovedAction();
            }

            void DisconnecOutputPort()
            {
                Model.OutputPort.NodePreManualRemovedAction();
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
                serializeHandler.RemoveCachePort(port: Model.InputSingleOptionChannel.Port);
                serializeHandler.RemoveCachePort(port: Model.OutputPort);
            }
        }


        /// <inheritdoc />
        protected override void LanguageChangedAction()
        {
            UpdateLanguageField();

            void UpdateLanguageField()
            {
                Model.HeaderTextContainer.UpdateLanguageField();
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
                Node.style.minWidth = NodesConfig.OptionTrackNodeMinWidth;
            }

            void SetMaxWidthProperties()
            {
                // Node
                Node.style.maxWidth =
                    NodesConfig.OptionTrackNodeMinWidth + NodesConfig.OptionTrackNodeMaxWidthBuffer;

                // Node title field
                TextField nodeTitleField = Model.NodeTitle_TextContainer.TextField;
                nodeTitleField.RegisterCallback<GeometryChangedEvent>(GeometryChangedAction);

                void GeometryChangedAction(GeometryChangedEvent evt)
                {
                    // Set the title field max width once it's fully created in the editor.
                    nodeTitleField.style.maxWidth =
                        nodeTitleField.contentRect.width + NodesConfig.OptionTrackNodeMaxWidthBuffer;

                    // Unregister the action once the setup is done.
                    nodeTitleField.UnregisterCallback<GeometryChangedEvent>(GeometryChangedAction);
                }
            }
        }
    }
}