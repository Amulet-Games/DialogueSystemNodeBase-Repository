using UnityEditor.Experimental.GraphView;

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
        protected PortFrameBase
        (
            TEdgeConnectorCallback edgeConnectorCallback,
            Orientation orientation,
            Direction direction,
            Capacity capacity
        )
            : base(orientation, direction, capacity)
        {
            m_EdgeConnector = new EdgeConnector<TEdge>(edgeConnectorCallback);
        }


        /// <summary>
        /// Setup the default style class.
        /// </summary>
        protected void SetupDefaultStyleClass(bool isSiblings)
        {
            if (isSiblings)
            {
                AddToClassList(StyleConfig.Port_Sibling);
            }
        }
    }
}