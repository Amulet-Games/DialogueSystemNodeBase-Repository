using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class PortFrameBase
    <
        TPort,
        TPortModel,
        TEdge,
        TEdgeView
    >
        : PortBase
        where TPort : PortFrameBase<TPort, TPortModel, TEdge, TEdgeView>
        where TPortModel : PortModel
        where TEdge : EdgeFrameBase<TPort, TPortModel, TEdge, TEdgeView>
        where TEdgeView : EdgeViewFrameBase<TPort, TPortModel, TEdge, TEdgeView>
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
        protected PortFrameBase(PortModel detail) : base(detail.Direction, detail.Capacity) { }


        /// <summary>
        /// Setup for the port frame base class.
        /// </summary>
        /// <param name="edgeConnector">The edge connector to set for.</param>
        /// <param name="detail">The port create detail to set for.</param>
        public virtual TPort Setup(EdgeConnector edgeConnector, PortModel detail)
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

            foreach (TEdge edge in connections.ToList())
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