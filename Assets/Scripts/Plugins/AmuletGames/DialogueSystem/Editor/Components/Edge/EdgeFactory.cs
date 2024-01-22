namespace AG.DS
{
    public class EdgeFactory
    {
        /// <summary>
        /// Create a new edge element.
        /// </summary>
        /// <param name="model">The edge model to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <param name="output">The output port to set for.</param>
        /// <returns>A new edge element.</returns>
        public static Edge Create
        (
            EdgeModel model,
            Port input,
            Port output
        )
        {
            var observer = new EdgeObserver();
            var callback = new EdgeCallback();
            var edge = EdgePresenter.CreateElement(model);
            
            edge.Setup(callback, model.StyleSheet).Connect(input, output);

            callback.Setup(edge);
            observer.RegisterEvents(edge);

            return edge;
        }
    }
}