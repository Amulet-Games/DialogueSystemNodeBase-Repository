using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class OptionPort : PortFrameBase
    <
        OptionPort,
        OptionEdge,
        OptionEdgeView
    >
    {
        /// <summary>
        /// The property of the current connecting opponent option port.
        /// </summary>
        public OptionPort OpponentPort
        {
            get
            {
                return m_opponentPort;
            }
            set
            {
                m_opponentPort = value;

                this.ToggleConnectStyle();
            }
        }


        /// <summary>
        /// The current connecting opponent option port.
        /// </summary>
        OptionPort m_opponentPort;


        /// <inheritdoc />
        public OptionPort(PortCreateDetail detail) : base(detail) { }


        /// <inheritdoc />
        public override OptionPort Setup
        (
            EdgeConnector edgeConnector,
            PortCreateDetail detail
        )
        {
            base.Setup(edgeConnector, detail);

            SetupConnectorBox();

            SetupConnectorText();

            SetupConnectorBoxCap();

            SetupDetails();

            SetupStyleClass();

            SetupStyleSheets();

            return this;
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
            portColor = PortConfig.OptionPortColor;
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


        // ----------------------------- Service -----------------------------
        /// <inheritdoc />
        public override void Disconnect(OptionEdge edge)
        {
            base.Disconnect(edge);
            
            OpponentPort = null;
        }


        /// <summary>
        /// Hide the opponent port's connect style if it's not connecting to other option port. 
        /// </summary>
        public void HideOpponentConnectStyle()
        {
            if (OpponentPort?.connected == false)
            {
                // Set the opponent port's opponent port property to null.
                OpponentPort.OpponentPort = null;
            }
        }
    }
}