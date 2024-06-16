using System;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <summary>
    /// The graph view port element.
    /// </summary>
    public class Port : UnityEditor.Experimental.GraphView.Port
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
            private set
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
        public Action<Edge> PostConnectEvent;


        /// <summary>
        /// The event to invoke when the port is about to be disconnected from another port.
        /// </summary>
        public Action<Edge> PreDisconnectEvent;


        /// <summary>
        /// The event to invoke after the previous connecting edge has been dropped in a empty space.
        /// </summary>
        public Action PostConnectingEdgeDropOutsideEvent;


        /// <summary>
        /// The property of the port's connector box visual element.
        /// </summary>
        public VisualElement ConnectorBox => m_ConnectorBox;


        /// <summary>
        /// The property of the port's connector text visual element.
        /// </summary>
        public VisualElement ConnectorText => m_ConnectorText;


        /// <summary>
        /// The property of the port's connector box cap visual element.
        /// </summary>
        public VisualElement ConnectorBoxCap => m_ConnectorBoxCap;


        /// <summary>
        /// The Guid of the port.
        /// </summary>
        public Guid Guid;


        /// <summary>
        /// Reference of the port callback.
        /// </summary>
        public IPortCallback Callback;


        /// <summary>
        /// Constructor of the port base class.
        /// </summary>
        /// <param name="model">The port model to set for.</param>
        public Port(PortModel model) : base(Orientation.Horizontal, model.Direction, model.Capacity, null)
        {
            portName = model.Name;
            portColor = model.Color;
            Guid = model.Guid;
        }


        /// <summary>
        /// Setup for the port base class.
        /// </summary>
        /// <param name="callback">The port callback to set for.</param>
        public Port Setup(EdgeConnector edgeConnector, IPortCallback callback)
        {
            EdgeConnector = edgeConnector;

            Callback = callback;

            SetupConnectorBox();

            SetupConnectorText();

            SetupConnectorBoxCap();

            return this;
        }


        /// <summary>
        /// Setup the connector box element.
        /// </summary>
        void SetupConnectorBox()
        {
            // Setup details
            {
                ConnectorBox.pickingMode = PickingMode.Position;
            }

            // Setup style class
            {
                ConnectorBox.name = "";
                ConnectorBox.ClearClassList();
                ConnectorBox.AddToClassList(this.IsInput() ? StyleConfig.Input_Connector : StyleConfig.Output_Connector);
            }
        }


        /// <summary>
        /// Setup the connector text element.
        /// </summary>
        void SetupConnectorText()
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
        void SetupConnectorBoxCap()
        {
            // Setup details
            {
                ConnectorBoxCap.pickingMode = PickingMode.Position;
            }

            // Setup style class
            {
                ConnectorBoxCap.name = "";
                ConnectorBoxCap.AddToClassList(this.IsInput() ? StyleConfig.Input_Cap : StyleConfig.Output_Cap);
            }
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Connect the port to the given edge.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void Connect(Edge edge)
        {
            base.Connect(edge);
            Callback.OnPostConnect(edge);
        }


        /// <summary>
        /// Disconnect the port from the given edge.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        public void Disconnect(Edge edge)
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

            foreach (Edge edge in connections.ToList())
            {
                // Disconnect the opponent port.
                (this.IsInput() ? edge.Output : edge.Input).Disconnect(edge);

                Disconnect(edge);
                graphViewer.Remove(edge);
            }
        }
    }
}