using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class NodeCreateConnectorObserver
    <
        TPort,
        TPortCreateDetail
    >
        : NodeCreateObserverFrameBase
    <
        NodeCreateConnectorDetail<TPort, TPortCreateDetail>,
        NodeCreateConnectorObserver<TPort, TPortCreateDetail>
    >
        where TPort : PortFrameBase<TPort, TPortCreateDetail>
        where TPortCreateDetail : PortModel
    {
        /// <inheritdoc />
        public override NodeCreateConnectorObserver<TPort, TPortCreateDetail> Setup
        (
            NodeCreateConnectorDetail<TPort, TPortCreateDetail> detail,
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
                Node.ExecuteOnceOnGeometryChanged(NewNodeOnCreateEvent);
            }
        }

        
        /// <summary>
        /// Connect the new created node to the connector port.
        /// </summary>
        void ConnectNewNode()
        {
            var port = Detail.ConnectorPort;
            var isInput = port.IsInput();

            if (port.IsSingle() && port.connected)
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
