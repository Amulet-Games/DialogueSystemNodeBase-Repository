using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class DefaultPort : PortFrameBase
    <
        DefaultPort,
        PortModel,
        DefaultEdgeView
    >
    {
        /// <inheritdoc />
        public DefaultPort(PortModel model) : base(model) { }


        /// <inheritdoc />
        public override DefaultPort Setup(EdgeConnector edgeConnector)
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
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DefaultPortStyle);
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc />
        public override void Disconnect(Edge<DefaultPort, PortModel, DefaultEdgeView> edge)
        {
            base.Disconnect(edge);
        }
    }
}