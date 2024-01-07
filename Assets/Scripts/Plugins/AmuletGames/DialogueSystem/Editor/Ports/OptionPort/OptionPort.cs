using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPort : Port<OptionPort>
    {
        /// <inheritdoc />
        public OptionPort(PortModel model) : base(model)
        {
        }


        /// <inheritdoc />
        public override OptionPort Setup
        (
            EdgeConnector edgeConnector,
            IPortCallback callback
        )
        {
            base.Setup(edgeConnector, callback);

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
            styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.PortStyle);
        }
    }
}