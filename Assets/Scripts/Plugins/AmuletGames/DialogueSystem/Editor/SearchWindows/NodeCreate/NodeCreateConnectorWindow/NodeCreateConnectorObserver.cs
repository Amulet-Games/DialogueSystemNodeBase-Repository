using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
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
        public override NodeCreateConnectorObserver<TPort, TEdge, TEdgeView> Setup
        (
            NodeCreateConnectorDetail<TPort, TEdge, TEdgeView> detail,
            GraphViewer graphViewer
        )
        {
            base.Setup(detail, graphViewer);
            return this;
        }


        // ----------------------------- Event -----------------------------
        /// <inheritdoc />
        protected override void InitializeNewNodePositionEvent(GeometryChangedEvent evt)
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

            if (Node is StoryNode storyNode)
            {
                storyNode.ExecuteOnceOnGeometryChanged(storyNode.GeometryChangedEvent);
            }
            else
            {
                Node.ExecuteOnceOnGeometryChanged(NewNodeOnPostCreateEvent);
            }
        }

        
        /// <summary>
        /// Connect the new created node to the connector port.
        /// </summary>
        void ConnectNewNode()
        {
            if (Detail.ConnectorPort != null)
            {
                var port = Detail.ConnectorPort;
                var isInput = port.IsInput();

                if (port.connected)
                {
                    port.Disconnect(GraphViewer);
                }

                var edge = EdgeManager.Instance.Connect
                (
                    output: !isInput ? port : YAxisReferencePort,
                    input: isInput ? port : YAxisReferencePort
                );

                GraphViewer.Add(edge);
            }
        }
    }
}
