using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPort : PortFrameBase
    <
        OptionPort,
        OptionPortModel,
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


        /// <summary>
        /// Is the option port comes from the option port group.
        /// </summary>
        public bool IsGroup;


        /// <inheritdoc />
        public OptionPort(OptionPortModel detail) : base(detail)
        {
            IsGroup = detail.IsGroup;
        }


        /// <inheritdoc />
        public override OptionPort Setup
        (
            EdgeConnector edgeConnector,
            PortModel detail
        )
        {
            base.Setup(edgeConnector, detail);

            SetupConnectorBox();

            SetupConnectorText();

            SetupConnectorBoxCap();

            SetupDetails();

            AddStyleClass();

            AddStyleSheet();

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
            SetupDetails();

            SetupStyleClass();

            void SetupDetails()
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
        /// Add the style class.
        /// </summary>
        void AddStyleClass()
        {
            name = "";
            ClearClassList();

            if (this.IsInput())
                AddToClassList(StyleConfig.Option_Input_Port);
            else
                AddToClassList(StyleConfig.Option_Output_Port);
        }


        /// <summary>
        /// Add the style sheet.
        /// </summary>
        void AddStyleSheet()
        {
            styleSheets.Clear();
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.OptionPortStyle);
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc />
        public override void Disconnect(OptionEdge edge)
        {
            base.Disconnect(edge);
            OpponentPort = null;
        }
    }
}