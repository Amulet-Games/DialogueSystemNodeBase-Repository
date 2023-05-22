using System;

namespace AG.DS
{
    public class EdgeManager
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static EdgeManager Instance { get; private set; } = null;


        // ----------------------------- Setup -----------------------------
        /// <summary>
        /// Setup for the class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
        }


        // ----------------------------- Dispose -----------------------------
        /// <summary>
        /// Dispose for the class.
        /// </summary>
        public void Dispose()
        {
            Instance = null;
        }


        // ----------------------------- Connect -----------------------------
        /// <summary>
        /// Method for connecting the two given ports.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <returns>A new default edge element.</returns>
        public DefaultEdge Connect(DefaultPort output, DefaultPort input)
        {
            return Connect<
                DefaultEdge,
                DefaultEdgeModel,
                DefaultEdgePresenter,
                DefaultEdgeCallback,
                DefaultPort
            >
            (
                output,
                input
            );
        }


        /// <summary>
        /// Method for connecting the two given ports.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <returns>A new option edge element.</returns>
        public OptionEdge Connect(OptionPort output, OptionPort input)
        {
            return Connect<
                OptionEdge,
                OptionEdgeModel,
                OptionEdgePresenter,
                OptionEdgeCallback,
                OptionPort
            >
            (
                output,
                input
            );
        }


        /// <summary>
        /// Method for connecting the two given ports.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <param name="portType">The port type to set for.</param>
        /// <returns>A new edge base element.</returns>
        public EdgeBase Connect(PortBase output, PortBase input, PortType portType)
        {
            return portType switch
            {
                PortType.DEFAULT => Connect((DefaultPort)output, (DefaultPort)input),
                PortType.OPTION => Connect((OptionPort)output, (OptionPort)input),
                _ => throw new Exception("Port type not match.")
            };
        }


        /// <summary>
        /// Method for connecting the two given ports.
        /// </summary>
        /// <typeparam name="TEdge">Type edge</typeparam>
        /// <typeparam name="TEdgeModel">Type edge model</typeparam>
        /// <typeparam name="TEdgePresenter">Type edge presenter</typeparam>
        /// <typeparam name="TEdgeCallback">Type edge callback</typeparam>
        /// <typeparam name="TPort">Type port</typeparam>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        TEdge Connect<TEdge, TEdgeModel, TEdgePresenter, TEdgeCallback, TPort>
        (
            TPort output,
            TPort input
        )
            where TEdge : EdgeBase
            where TEdgeModel : EdgeModelFrameBase<TPort>, new()
            where TEdgePresenter : EdgePresenterFrameBase<TEdge, TEdgeModel, TPort>, new()
            where TEdgeCallback : EdgeCallbackFrameBase<TEdge>, new()
            where TPort : PortBase
        {
            // Create model
            var edgeModel = new TEdgeModel();
            edgeModel.Setup(output, input);

            // Create edge
            var edge = new TEdgePresenter().CreateElement(edgeModel);

            // Register callbacks
            var edgeCallback = new TEdgeCallback();
            edgeCallback.Setup(edge);
            edgeCallback.RegisterEvents();

            return edge;
        }
    }
}