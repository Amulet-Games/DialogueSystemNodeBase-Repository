using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
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
        where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
        where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TEdge, TEdgeView>
    {
        /// <summary>
        /// The property of edge connector.
        /// </summary>
        public EdgeConnector EdgeConnector
        {
            get
            {
                return m_EdgeConnector;
            }
            set
            {
                if (m_EdgeConnector != null)
                    return;

                m_EdgeConnector = value;
                this.AddManipulator(manipulator: m_EdgeConnector);
            }
        }


        /// <summary>
        /// Constructor of the port frame base class.
        /// </summary>
        /// <param name="detail">The port create detail to set for.</param>
        protected PortFrameBase(PortCreateDetail detail) : base(detail.Direction, detail.Capacity) { }


        /// <summary>
        /// Setup for the port frame base class.
        /// </summary>
        /// <param name="edgeConnector">The edge connector to set for.</param>
        /// <param name="detail">The port create detail to set for.</param>
        public virtual TPort Setup(EdgeConnector edgeConnector, PortCreateDetail detail)
        {
            EdgeConnector = edgeConnector;
            portName = detail.Name;
            Guid = Guid.NewGuid();
            return null;
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
                var edges = connections.ToArray();
                for (int i = 0; i < edges.Length; i++)
                {
                    m_Disconnect((TEdge)edges[i]);
                }
            }

            void m_Disconnect(TEdge edge)
            {
                // Disconnect opponent port.
                {
                    if (this.IsInput())
                        edge.View.Output.Disconnect(edge);
                    else
                        edge.View.Input.Disconnect(edge);
                }

                Disconnect(edge);
                graphViewer.Remove(edge);
            }
        }
    }
}