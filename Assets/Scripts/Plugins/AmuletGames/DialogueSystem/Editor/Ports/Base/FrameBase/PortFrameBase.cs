using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class PortFrameBase
    <
        TEdge,
        TEdgeView,
        TEdgeConnectorCallback,
        TPort
    >
        : PortBase
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>, new()
        where TEdgeView : EdgeViewFrameBase<TPort, TEdgeView>
        where TEdgeConnectorCallback : EdgeConnectorCallbackFrameBase<TEdge, TPort, TEdgeConnectorCallback>
        where TPort : PortBase
    {
        /// <inheritdoc />
        protected PortFrameBase(Direction direction, Capacity capacity)
            : base(direction, capacity) { }


        /// <summary>
        /// Setup the edge connector.
        /// </summary>
        /// <param name="edgeConnectorCallback">The edge connector callback to set for.</param>
        protected void SetupEdgeConnector(TEdgeConnectorCallback edgeConnectorCallback)
        {
            m_EdgeConnector = new EdgeConnector<TEdge>(edgeConnectorCallback);
            this.AddManipulator(manipulator: m_EdgeConnector);
        }
    }
}