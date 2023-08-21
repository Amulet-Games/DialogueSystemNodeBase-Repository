using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class DefaultPort : PortFrameBase
    <
        DefaultEdge,
        DefaultEdgeView,
        DefaultEdgeConnectorCallback,
        DefaultPort
    >
    {
        /// <summary>
        /// Constructor of the default port element class.
        /// </summary>
        /// <param name="edgeConnectorCallback">The edge connector callback to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="capacity">The capacity to set for.</param>
        /// <param name="portName">The port name to set for.</param>
        /// <param name="isSibling">The isSibling value to set for.</param>
        public DefaultPort
        (
            DefaultEdgeConnectorCallback edgeConnectorCallback,
            Direction direction,
            Capacity capacity,
            string portName,
            bool isSibling = false
        )
            : base(direction, capacity)
        {
            SetupEdgeConnector(edgeConnectorCallback);

            SetupConnectorBox();

            SetupConnectorText();

            SetupConnectorBoxCap();

            SetupDetails(portName);

            SetupStyleClass(isSibling);

            SetupStyleSheets();
        }


        /// <summary>
        /// Setup the connector box element.
        /// </summary>
        void SetupConnectorBox()
        {
            // Setup style class
            {
                ConnectorBox.name = "";

                if (this.IsInput())
                    ConnectorBox.AddToClassList(StyleConfig.Default_Input_Connector);
                else
                    ConnectorBox.AddToClassList(StyleConfig.Default_Output_Connector);
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

                if (this.IsInput())
                    ConnectorText.AddToClassList(StyleConfig.Default_Input_Label);
                else
                    ConnectorText.AddToClassList(StyleConfig.Default_Output_Label);
            }
        }


        /// <summary>
        /// Setup the connector box cap element.
        /// </summary>
        void SetupConnectorBoxCap()
        {
            SetupDetail();

            SetupStyleClass();

            void SetupDetail()
            {
                ConnectorBoxCap.pickingMode = PickingMode.Position;
            }

            void SetupStyleClass()
            {
                ConnectorBoxCap.name = "";

                if (this.IsInput())
                    ConnectorBoxCap.AddToClassList(StyleConfig.Default_Input_Cap);
                else
                    ConnectorBoxCap.AddToClassList(StyleConfig.Default_Output_Cap);
            }
        }


        /// <summary>
        /// Setup the details.
        /// </summary>
        /// <param name="portName">The port name to set for.</param>
        void SetupDetails(string portName)
        {
            this.portName = portName;
            portColor = PortConfig.DefaultPortColor;
        }


        /// <summary>
        /// Setup the style class.
        /// </summary>
        /// <param name="isSibling">The isSibling value to set for.</param>
        void SetupStyleClass(bool isSibling)
        {
            name = "";
            ClearClassList();

            if (this.IsInput())
                AddToClassList(StyleConfig.Default_Input_Port);
            else
                AddToClassList(StyleConfig.Default_Output_Port);

            if (isSibling)
            {
                AddToClassList(StyleConfig.Port_Sibling);
            }
        }


        /// <summary>
        /// Setup the style sheets.
        /// </summary>
        void SetupStyleSheets()
        {
            styleSheets.Clear();
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSDefaultPortStyle);
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc />
        public override void Disconnect(Edge edge)
        {
            base.Disconnect(edge);

            //Debug.Log("edge type = " + connections.First().GetType());
        }


        /// <inheritdoc />
        public override void Disconnect(GraphViewer graphViewer)
        {
            if (connected)
            {
                if (this.IsSingle())
                {
                    // get connecting edge
                    var edge = (DefaultEdge)connections.First();

                    // Disconnect ports.
                    {
                        if (direction == Direction.Output)
                        {
                            edge.View.Input.Disconnect(edge);
                        }
                        else
                        {
                            edge.View.Output.Disconnect(edge);
                        }

                        base.Disconnect(edge);
                    }

                    // Remove edge from graph viewer.
                    graphViewer.Remove(edge);
                }
                else
                {
                    // get connecting edge
                    var edges = (DefaultEdge[])connections.ToArray();

                    for (int i = 0; i < edges.Length; i++)
                    {
                        // Disconnect ports.
                        {
                            if (direction == Direction.Output)
                            {
                                edges[i].View.Input.Disconnect(edges[i]);
                            }
                            else
                            {
                                edges[i].View.Output.Disconnect(edges[i]);
                            }

                            base.Disconnect(edges[i]);
                        }

                        // Remove edge from graph viewer.
                        graphViewer.Remove(edges[i]);
                    }
                }
            }
        }
    }
}