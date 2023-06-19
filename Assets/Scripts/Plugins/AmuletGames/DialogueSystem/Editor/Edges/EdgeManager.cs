using System;

namespace AG.DS
{
    public class EdgeManager
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static EdgeManager Instance { get; private set; } = null;


        /// <summary>
        /// Initialize for the class.
        /// </summary>
        public static void Initialize()
        {
            Instance ??= new();
        }


        // ----------------------------- Connect -----------------------------
        /// <summary>
        /// Method for connecting the two given ports.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        public EdgeBase Connect<T>(T output, T input) where T : PortBase
        {
            return output switch
            {
                DefaultPort _ => Connect(output as DefaultPort, input as DefaultPort),
                OptionPort _ => Connect(output as OptionPort, input as OptionPort),
                _ => throw new ArgumentException("Invalid port type: " + output.GetType().Name)
            };
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
                _ => throw new ArgumentException("Invalid port type: " + portType)
            };
        }
        
        
        /// <summary>
        /// Method for connecting the two given ports.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <returns>A new default edge element.</returns>
        public DefaultEdge Connect(DefaultPort output, DefaultPort input)
        {
            return Connect
            <
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
            return Connect
            <
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
        /// <typeparam name="TEdge">Type edge</typeparam>
        /// <typeparam name="TEdgeModel">Type edge model</typeparam>
        /// <typeparam name="TEdgePresenter">Type edge presenter</typeparam>
        /// <typeparam name="TEdgeCallback">Type edge callback</typeparam>
        /// <typeparam name="TPort">Type port</typeparam>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <returns>A new type edge element.</returns>
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

            // Register events
            new TEdgeCallback().Setup(edge).RegisterEvents();

            return edge;
        }
    }
}