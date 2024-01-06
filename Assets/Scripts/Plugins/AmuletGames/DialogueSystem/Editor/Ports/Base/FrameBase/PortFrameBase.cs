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
        TEdgeView
    >
        : PortBase
        where TPort : PortFrameBase<TPort, TPortModel, TEdgeView>
        where TPortModel : PortModel
        where TEdgeView : EdgeViewFrameBase<TPort, TPortModel, TEdgeView>
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
        /// The event to invoke after the port is connected to another port.
        /// </summary>
        public Action<EdgeBase> PostConnectEvent;


        /// <summary>
        /// The event to invoke when the port is about to be disconnected from another port.
        /// </summary>
        public Action<EdgeBase> PreDisconnectEvent;


        /// <summary>
        /// The event to invoke after the previous connecting edge has been dropped in a empty space.
        /// </summary>
        public Action PostConnectingEdgeDropOutsideEvent;


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
        /// <param name="callback">The port callback to set for.</param>
        public virtual TPort Setup
        (
            EdgeConnector edgeConnector,
            IPortCallback callback
        )
        {
            EdgeConnector = edgeConnector;
            Callback = callback;
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
        /// Connect the port to the given edge.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void Connect(Edge<TPort, TPortModel, TEdgeView> edge)
        {
            base.Connect(edge);
            Callback.OnPostConnect(edge);
        }


        /// <summary>
        /// Disconnect the port from the given edge.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void Disconnect(Edge<TPort, TPortModel, TEdgeView> edge)
        {
            Callback.OnPreDisconnect(edge);
            base.Disconnect(edge);
        }


        /// <summary>
        /// Disconnect any edges that are connecting with the port.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public void Disconnect(GraphViewer graphViewer)
        {
            if (!connected)
                return;

            foreach (Edge<TPort, TPortModel, TEdgeView> edge in connections.ToList())
            {
                // Disconnect the opponent port.
                (this.IsInput() ? edge.View.Output : edge.View.Input).Disconnect(edge);

                Disconnect(edge);
                graphViewer.Remove(edge);
            }
        }
    }
}