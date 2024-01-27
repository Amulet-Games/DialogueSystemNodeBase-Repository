namespace AG.DS
{
    public class EdgeConnectorListenerModel
    {
        /// <summary>
        /// Reference of the edge connector search window view.
        /// </summary>
        public EdgeConnectorSearchWindowView EdgeConnectorSearchWindowView { get; private set; }


        /// <summary>
        /// Reference of the edge model.
        /// </summary>
        public EdgeModel EdgeModel { get; private set; }


        /// <summary>
        /// Constructor of the edge connector listener model class.
        /// </summary>
        /// <param name="edgeConnectorSearchWindowView">The edge connector search window view to set for.</param>
        /// <param name="edgeModel">The edge model to set for.</param>
        public EdgeConnectorListenerModel
        (
            EdgeConnectorSearchWindowView edgeConnectorSearchWindowView,
            EdgeModel edgeModel
        )
        {
            EdgeConnectorSearchWindowView = edgeConnectorSearchWindowView;
            EdgeModel = edgeModel;
        }
    }
}