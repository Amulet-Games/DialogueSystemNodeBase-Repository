using UnityEngine.UIElements;

namespace AG.DS
{
    public class EdgeManager
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static EdgeManager Instance { get; private set; } = null;


        /// <summary>
        /// Setup for the edge manager class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
        }


        // ----------------------------- Connect -----------------------------
        /// <summary>
        /// Method for connecting the two ports.
        /// </summary>
        /// <param name="model">The edge model to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <param name="output">The output port to set for.</param>
        /// <returns>A new edge element.</returns>
        public EdgeBase Connect
        (
            //EdgeModel model,
            StyleSheet styleSheet,
            PortBase input,
            PortBase output
        )
        {
            var model = new EdgeModel(true, styleSheet);

            var observer = new EdgeObserver();
            var callback = new EdgeCallback();
            var edge = EdgePresenter.CreateElement(model);
            
            edge.Setup(callback, model.StyleSheet).Connect(input, output);

            callback.Setup(edge);
            observer.RegisterEvents(edge);

            return edge;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Method for saving the edge element's values.
        /// </summary>
        /// <param name="edge">The edge element to set for.</param>
        /// <returns>A new edge data.</returns>
        public EdgeData Save(EdgeBase edge)
        {
            var data = new EdgeData();
            new EdgeSerializer().Save(edge, data);
            
            return data;
        }
    }
}