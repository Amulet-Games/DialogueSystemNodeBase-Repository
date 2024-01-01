using UnityEditor.Experimental.GraphView;

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
        public OptionPort(OptionPortModel model) : base(model)
        {
            IsGroup = model.IsGroup;
        }


        /// <inheritdoc />
        public override OptionPort Setup(EdgeConnector edgeConnector)
        {
            base.Setup(edgeConnector);

            SetupConnectorBox();

            SetupConnectorText();

            SetupConnectorBoxCap();

            AddStyleClass();

            AddStyleSheet();

            return this;
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