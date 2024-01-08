using System;
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
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <param name="port">The port type to set for.</param>
        /// <returns>A new edge element.</returns>
        public EdgeBase Connect(PortBase output, PortBase input, PortModel.Port port)
        {
            return port switch
            {
                PortModel.Port.Default => Connect
                (
                    output,
                    input,
                    ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                ),

                PortModel.Port.Option => Connect
                (
                    output,
                    input,
                    ConfigResourcesManager.StyleSheetConfig.OptionEdgeStyle
                ),

                _ => throw new ArgumentException("Invalid port type: " + port)
            };
        }


        /// <summary>
        /// Method for connecting the two ports.
        /// </summary>
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <param name="styleSheet">The edge style sheet to set for.</param>
        /// <returns>A new edge element.</returns>
        public EdgeBase Connect
        (
            PortBase output,
            PortBase input,
            StyleSheet styleSheet
        )
        {
            var observer = new EdgeObserver();
            var callback = new EdgeCallback();
            var edge = new EdgeBase().Setup(output, input, callback, styleSheet);

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