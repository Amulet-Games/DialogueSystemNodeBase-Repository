using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using Orientation = UnityEditor.Experimental.GraphView.Orientation;

namespace AG.DS
{
    public partial class OptionPort : PortFrameBase
    <
        OptionEdge,
        OptionEdgeView,
        OptionEdgeConnectorCallback,
        OptionPort
    >
    {
        /// <summary>
        /// The current connecting opponent option port.
        /// </summary>
        public OptionPort OpponentPort;


        /// <summary>
        /// Constructor of the option port element class.
        /// </summary>
        /// <param name="edgeConnectorCallback">The edge connector callback to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        public OptionPort
        (
            OptionEdgeConnectorCallback edgeConnectorCallback,
            Direction direction
        )
            : base(direction, Capacity.Single)
        {
            SetupEdgeConnector(edgeConnectorCallback);

            SetupConnectorBox();

            SetupConnectorText();

            SetupConnectorBoxCap();

            SetupDetails();

            SetupStyleClass();

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
                    ConnectorBox.AddToClassList(StyleConfig.Option_Input_Connector);
                else
                    ConnectorBox.AddToClassList(StyleConfig.Option_Output_Connector);
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
                    ConnectorText.AddToClassList(StyleConfig.Option_Input_Label);
                else
                    ConnectorText.AddToClassList(StyleConfig.Option_Output_Label);
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
                    ConnectorBoxCap.AddToClassList(StyleConfig.Option_Input_Cap);
                else
                    ConnectorBoxCap.AddToClassList(StyleConfig.Option_Output_Cap);
            }
        }


        /// <summary>
        /// Setup the details.
        /// </summary>
        void SetupDetails()
        {
            portName = this.IsInput()
                ? StringConfig.OptionPort_Input_LabelText_Disconnect
                : StringConfig.OptionPort_Output_LabelText_Disconnect;

            portColor = PortConfig.OptionPortColor;

            OpponentPort = null;
        }


        /// <summary>
        /// Setup the style class.
        /// </summary>
        void SetupStyleClass()
        {
            name = "";
            ClearClassList();

            if (this.IsInput())
                AddToClassList(StyleConfig.Option_Input_Port);
            else
                AddToClassList(StyleConfig.Option_Output_Port);
        }


        /// <summary>
        /// Setup the style sheets.
        /// </summary>
        void SetupStyleSheets()
        {
            styleSheets.Clear();
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSOptionPortStyle);
        }


        // ----------------------------- Serialization -----------------------------
        ///// <inheritdoc />
        //public override void Save(OptionPortModel model)
        //{
        //    model.Guid = name;
        //    model.LabelText = portName;
        //}


        ///// <inheritdoc />
        //public override void Load(OptionPortModel model)
        //{
        //    name = model.Guid;
        //    portName = model.LabelText;
        //}


        // ----------------------------- Service -----------------------------
        /// <inheritdoc />
        public override void Disconnect(Edge edge)
        {
            base.Disconnect(edge);

            this.HideConnectStyle();
            
            OpponentPort = null;
        }


        /// <inheritdoc />
        public override void Disconnect(GraphViewer graphViewer)
        {
            if (connected)
            {
                // get connecting edge
                var edge = (OptionEdge)connections.First();

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
        }


        /// <summary>
        /// Hide the opponent port's connect style if it's not connecting to other option port. 
        /// </summary>
        public void HideOpponentConnectStyle()
        {
            if (OpponentPort?.connected == false)
            {
                // If the opponent port is no longer connecting remove it from connect style class.
                OpponentPort.HideConnectStyle();
            }
        }
    }
}