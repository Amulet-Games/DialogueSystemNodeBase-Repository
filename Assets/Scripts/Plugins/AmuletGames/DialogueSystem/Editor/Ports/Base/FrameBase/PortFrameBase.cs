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
        /// <param name="model">The port model to set for.</param>
        protected PortFrameBase(PortModel model) : base(model.Direction, model.Capacity)
        {
            portName = model.Name;
            portColor = model.Color;
        }


        /// <summary>
        /// Setup for the port frame base class.
        /// </summary>
        /// <param name="edgeConnector">The edge connector to set for.</param>
        public virtual TPort Setup(EdgeConnector edgeConnector)
        {
            EdgeConnector = edgeConnector;
            Guid = Guid.NewGuid();
            return null;
        }


        /// <summary>
        /// Setup the connector box element.
        /// </summary>
        protected void SetupConnectorBox()
        {
            // Setup style class
            {
                ConnectorBox.name = "";
                ConnectorBox.AddToClassList(this.IsInput() ? StyleConfig.Input_Connector : StyleConfig.Output_Connector);
            }
        }


        /// <summary>
        /// Setup the connector text element.
        /// </summary>
        protected void SetupConnectorText()
        {
            // Setup style class
            {
                ConnectorText.name = "";
                ConnectorText.ClearClassList();
                ConnectorText.AddToClassList(this.IsInput() ? StyleConfig.Input_Label : StyleConfig.Output_Label);
            }
        }


        /// <summary>
        /// Setup the connector box cap element.
        /// </summary>
        protected void SetupConnectorBoxCap()
        {
            SetupDetails();

            SetupStyleClass();

            void SetupDetails()
            {
                ConnectorBoxCap.pickingMode = PickingMode.Position;
            }

            void SetupStyleClass()
            {
                ConnectorBoxCap.name = "";
                ConnectorBoxCap.AddToClassList(this.IsInput() ? StyleConfig.Input_Cap : StyleConfig.Output_Cap);
            }
        }


        /// <summary>
        /// Add the style class.
        /// </summary>
        protected void AddStyleClass()
        {
            name = "";
            ClearClassList();
            AddToClassList(this.IsInput() ? StyleConfig.Input_Port : StyleConfig.Output_Port);
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
                    (this.IsInput() ? edge.View.Output : edge.View.Input).Disconnect(edge);
                }

                Disconnect(edge);
                graphViewer.Remove(edge);
            }
        }
    }
}