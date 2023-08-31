using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class PortFrameBase
    <
        TPort,
        TEdge,
        TEdgeView
    >
        : PortBase
        where TPort : PortBase
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdgeView>
    {
        /// <summary>
        /// Reference of the edge connector.
        /// </summary>
        public EdgeConnector EdgeConnector
        {
            get
            {
                return m_EdgeConnector;
            }
            set
            {
                m_EdgeConnector = value;
                this.AddManipulator(manipulator: m_EdgeConnector);
            }
        }


        /// <inheritdoc />
        protected PortFrameBase(Direction direction, Capacity capacity)
            : base(direction, capacity) { }


        /// <summary>
        /// Setup the edge connector.
        /// </summary>
        /// <param name="edgeConnector">The edge connector to set for.</param>
        protected void SetupEdgeConnector(EdgeConnector edgeConnector)
        {
            EdgeConnector = edgeConnector;
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