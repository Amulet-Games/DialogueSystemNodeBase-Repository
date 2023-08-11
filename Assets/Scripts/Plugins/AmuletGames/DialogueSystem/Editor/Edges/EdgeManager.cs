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
        /// Method for connecting the two ports.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <param name="portType">The port type to set for.</param>
        /// <returns>A new edge element.</returns>
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
        /// Method for connecting the two ports.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <returns>A new default edge element.</returns>
        public DefaultEdge Connect(DefaultPort output, DefaultPort input)
        {
            return Connect
            <
                DefaultEdge,
                DefaultEdgePresenter,
                DefaultEdgeObserver,
                DefaultPort
            >
            (
                output,
                input
            );
        }


        /// <summary>
        /// Method for connecting the two ports.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <returns>A new option edge element.</returns>
        public OptionEdge Connect(OptionPort output, OptionPort input)
        {
            return Connect
            <
                OptionEdge,
                OptionEdgePresenter,
                OptionEdgeObserver,
                OptionPort
            >
            (
                output,
                input
            );
        }


        /// <summary>
        /// Method for connecting the two ports.
        /// </summary>
        /// <typeparam name="TEdge">Type edge</typeparam>
        /// <typeparam name="TEdgePresenter">Type edge presenter</typeparam>
        /// <typeparam name="TEdgeObserver">Type edge observer</typeparam>
        /// <typeparam name="TPort">Type port</typeparam>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <returns>A new edge element.</returns>
        TEdge Connect<TEdge, TEdgePresenter, TEdgeObserver, TPort>
        (
            TPort output,
            TPort input
        )
            where TEdge : EdgeBase
            where TEdgePresenter : EdgePresenterFrameBase<TEdge, TPort>, new()
            where TEdgeObserver : EdgeObserverFrameBase<TEdge>, new()
            where TPort : PortBase
        {
            var edge = new TEdgePresenter().CreateElement(output, input);

            new TEdgeObserver().Setup(edge).RegisterEvents();

            return edge;
        }
    }
}