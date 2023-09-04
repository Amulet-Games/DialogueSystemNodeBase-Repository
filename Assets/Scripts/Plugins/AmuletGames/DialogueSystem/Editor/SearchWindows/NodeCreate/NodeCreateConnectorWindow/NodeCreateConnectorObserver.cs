using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    public class NodeCreateConnectorObserver
    <
        TPort,
        TEdge,
        TEdgeView
    >
        : NodeCreateObserverFrameBase
    <
        NodeCreateConnectorDetail<TPort, TEdge, TEdgeView>,
        NodeCreateConnectorObserver<TPort, TEdge, TEdgeView>
    >
        where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdgeView>
    {
        /// <inheritdoc />
        public override NodeCreateConnectorObserver<TPort, TEdge, TEdgeView> Setup()
        {
            NodeCreateRequestDetail detail,
            GraphView graphViewer
        }
        {
            base.NodeCreateConnectorObserver(detail, graphViewer);
            return this;
        }


        // ----------------------------- Event -----------------------------
        /// <inheritdoc />
        public override void InitializeNewNodePositionEvent(GeometryChangedEvent evt)
        {
            Node.SetPosition
            (
                newPos: new Rect
                (
                    position: CalculateFinalCreatePosition(),
                    size: Vector2Utility.Zero
                )
            );

            ConnectNewNode();

            if (node is StoryNode storyNode)
            {
                storyNode.ExecuteOnceOnGeometryChanged(storyNode.GeometryChangedEvent);
            }
            else
            {
                node.ExecuteOnceOnGeometryChanged(NewNodeOnPostCreateEvent);
            }
        }

        
        /// <summary>
        /// Connect the new created node to the connector port.
        /// </summary>
        void ConnectNewNode()
        {
            if (detail.ConnectorPort != null)
            {
                var port = detail.ConnectorPort;
                var isInput = port.IsInput();

                if (port.connected)
                {
                    port.Disconnect(graphViewer);
                }

                var edge = EdgeManager.Instance.Connect
                (
                    output: !isInput ? port : yAxisReferencePort,
                    input: isInput ? port : yAxisReferencePort
                );

                graphViewer.Add(edge);
            }
        }
    }
}
