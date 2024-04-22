using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class PortFactory
    {
        /// <summary>
        /// Generate a new port element.
        /// </summary>
        /// <param name="model">The port model to set for.</param>
        /// <returns>A port element.</returns>
        public static Port Generate(PortModel model)
        {
            var port = PortPresenter.CreateElement(model);
            var callback = new PortCallback();
            var listener = new EdgeConnectorListener
            (
                connectorPort: port,
                edgeConnectorSearchWindowView: model.EdgeConnectorSearchWindowView,
                edgeModel: model.EdgeModel
            );

            port.Setup(edgeConnector: new EdgeConnector<Edge>(listener), callback);
            callback.Setup(port);

            return port;
        }
    }
}