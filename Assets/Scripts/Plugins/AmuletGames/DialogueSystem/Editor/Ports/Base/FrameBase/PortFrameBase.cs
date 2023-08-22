using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
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


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Disconnect edge from port.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public virtual void Disconnect(TEdge edge) => base.Disconnect(edge);


        /// <summary>
        /// Disconnect any edges that are connecting with the port.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public void Disconnect(GraphViewer graphViewer)
        {
            if (!connected)
                return;

            if (this.IsSingle())
            {
                var edge = (TEdge)connections.First();

                m_Disconnect(edge);
            }
            else
            {
                var edges = (TEdge[])connections.ToArray();
                for (int i = 0; i < edges.Length; i++)
                {
                    m_Disconnect(edges[i]);
                }
            }

            void m_Disconnect(TEdge edge)
            {
                // Disconnect opponent port.
                {
                    if (this.IsInput())
                    {
                        edge.View.Output.Disconnect(edge);
                    }
                    else
                    {
                        edge.View.Input.Disconnect(edge);
                    }
                }

                Disconnect(edge);

                graphViewer.Remove(edge);
            }
        }
    }
}