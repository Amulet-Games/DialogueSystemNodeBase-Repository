using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPort : PortFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultEdge,
        DefaultEdgeView
    >
    {
        /// <inheritdoc />
        public DefaultPort(PortModel detail) : base(detail) { }


        /// <inheritdoc />
        public override DefaultPort Setup
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
                    ConnectorBoxCap.AddToClassList(StyleConfig.Default_Input_Cap);
                else
                    ConnectorBoxCap.AddToClassList(StyleConfig.Default_Output_Cap);
            }
        }


        /// <summary>
        /// Setup the details.
        /// </summary>
        void SetupDetails()
        {
            portColor = PortConfig.DefaultPortColor;
        }


        /// <summary>
        /// Add the style class.
        /// </summary>
        void AddStyleClass()
        {
            name = "";
            ClearClassList();

            if (this.IsInput())
                AddToClassList(StyleConfig.Default_Input_Port);
            else
                AddToClassList(StyleConfig.Default_Output_Port);
        }


        /// <summary>
        /// Add the style sheet.
        /// </summary>
        void AddStyleSheet()
        {
            styleSheets.Clear();
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DefaultPortStyle);
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc />
        public override void Disconnect(DefaultEdge edge)
        {
            base.Disconnect(edge);

            //Debug.Log("edge type = " + connections.First().GetType());
        }
    }
}