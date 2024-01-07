using System;
using UnityEditor.Experimental.GraphView;
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
        public EdgeBase Connect<T>(T output, T input) where T : Port
        {
            return output switch
            {
                DefaultPort _ => Connect<DefaultPort, DefaultEdgeObserver, DefaultEdgeCallback>
                (
                    output as DefaultPort,
                    input as DefaultPort,
                    ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                ),

                OptionPort _ => Connect<OptionPort, OptionEdgeObserver, OptionEdgeCallback>
                (
                    output as OptionPort,
                    input as OptionPort,
                    ConfigResourcesManager.StyleSheetConfig.OptionEdgeStyle
                ),

                _ => throw new ArgumentException("Invalid port type: " + output.GetType().Name)
            };
        }


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
                PortModel.Port.Default => Connect<DefaultPort, DefaultEdgeObserver, DefaultEdgeCallback>
                (
                    (DefaultPort)output,
                    (DefaultPort)input,
                    ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                ),

                PortModel.Port.Option => Connect<OptionPort, OptionEdgeObserver, OptionEdgeCallback>
                (
                    (OptionPort)output,
                    (OptionPort)input,
                    ConfigResourcesManager.StyleSheetConfig.OptionEdgeStyle
                ),

                _ => throw new ArgumentException("Invalid port type: " + port)
            };
        }


        /// <summary>
        /// Method for connecting the two ports.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TEdgeObserver">Type edge observer</typeparam>
        /// <typeparam name="TEdgeCallback">Type edge callback</typeparam>
        /// 
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// <param name="styleSheet">The edge style sheet to set for.</param>
        /// 
        /// <returns>A new edge element.</returns>
        Edge<TPort> Connect<TPort, TEdgeObserver, TEdgeCallback>
        (
            TPort output,
            TPort input,
            StyleSheet styleSheet
        )
            where TPort : Port<TPort>
            where TEdgeObserver : EdgeObserverFrameBase<Edge<TPort>>, new()
            where TEdgeCallback : EdgeCallbackFrameBase<TPort>, new()
        {
            var observer = new TEdgeObserver();
            var callback = new TEdgeCallback();
            var edge = new Edge<TPort>().Setup(output, input, callback, styleSheet);

            callback.Setup(edge);
            observer.RegisterEvents(edge);

            return edge;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Method for saving the edge element's values.
        /// </summary>
        /// 
        /// <param name="edge">The edge element to set for.</param>
        /// 
        /// <returns>A new edge data.</returns>
        /// 
        /// <exception cref="ArgumentException">
        /// Thrown when the given edge element is invalid to any of the current existing edge's type.
        /// </exception>
        public EdgeDataBase Save(EdgeBase edge)
        {
            return edge switch
            {
                Edge<DefaultPort> m_edge
                    => Save<DefaultPort, DefaultEdgeSerializer, EdgeDataBase>(m_edge),

                Edge<OptionPort> m_edge
                    => Save<OptionPort, OptionEdgeSerializer, EdgeDataBase>(m_edge),

                _ => throw new ArgumentException("Invalid edge type: " + edge)
            };
        }


        /// <summary>
        /// Method for saving the edge element's values.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TEdgeSerializer">Type edge serializer</typeparam>
        /// <typeparam name="TEdgeData">Type edge data</typeparam>
        /// 
        /// <param name="edge">The edge element to set for.</param>
        /// 
        /// <returns>A new edge data.</returns>
        TEdgeData Save<TPort, TEdgeSerializer, TEdgeData>(Edge<TPort> edge)
            where TPort : Port<TPort>
            where TEdgeSerializer : EdgeSerializerFrameBase<TPort, TEdgeData>, new()
            where TEdgeData : EdgeDataBase, new()
        {
            var data = new TEdgeData();
            new TEdgeSerializer().Save(edge, data);
            
            return data;
        }
    }
}