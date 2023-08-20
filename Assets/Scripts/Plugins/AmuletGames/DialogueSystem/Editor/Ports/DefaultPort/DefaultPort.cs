using System.Collections.Generic;
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
        public override IEnumerable<Edge> connections
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Constructor of the default port element class.
        /// </summary>
        /// <param name="orientation">Vertical or horizontal.</param>
        /// <param name="direction">Input or output.</param>
        /// <param name="capacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        public DefaultPort
        (
            DefaultEdgeConnectorCallback edgeConnectorCallback,
            Orientation orientation,
            Direction direction,
            Capacity capacity
        )
            : base(edgeConnectorCallback, orientation, direction, capacity)
        {
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
        /// Setup the default style class.
        /// </summary>
        void SetupDefaultStyleClass(bool isSiblings)
        {
            name = "";
            ClearClassList();

            if (this.IsInput())
                AddToClassList(StyleConfig.Default_Input_Port);
            else
                AddToClassList(StyleConfig.Default_Output_Port);

            if (isSiblings)
            {
                AddToClassList(StyleConfig.Port_Sibling);
            }
        }


        /// <summary>
        /// Setup the default style sheets.
        /// </summary>
        protected void SetupDefaultStyleSheets()
        {
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSGlobalStyle);
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSNodeCommonStyle);
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