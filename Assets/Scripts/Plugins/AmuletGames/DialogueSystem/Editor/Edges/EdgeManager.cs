using System;
using UnityEditor.Experimental.GraphView;

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
                DefaultPort _ => Connect<DefaultPort, PortCreateDetailBase, DefaultEdge, DefaultEdgeView,
                            DefaultEdgeObserver, DefaultEdgeCallback>(output as DefaultPort, input as DefaultPort),

                OptionPort _ => Connect<OptionPort, OptionPortCreateDetail, OptionEdge, OptionEdgeView,
                            OptionEdgeObserver, OptionEdgeCallback>(output as OptionPort, input as OptionPort),

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
                PortType.DEFAULT => Connect<DefaultPort, PortCreateDetailBase, DefaultEdge, DefaultEdgeView,
                                DefaultEdgeObserver, DefaultEdgeCallback>((DefaultPort)output, (DefaultPort)input),

                PortType.OPTION => Connect<OptionPort, OptionPortCreateDetail, OptionEdge, OptionEdgeView,
                                OptionEdgeObserver, OptionEdgeCallback>((OptionPort)output, (OptionPort)input),

                _ => throw new ArgumentException("Invalid port type: " + portType)
            };
        }


        /// <summary>
        /// Method for connecting the two ports.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TPortCreateDetail">Type port create detail</typeparam>
        /// <typeparam name="TEdge">Type edge</typeparam>
        /// <typeparam name="TEdgeView">Type edge view</typeparam>
        /// <typeparam name="TEdgeObserver">Type edge observer</typeparam>
        /// <typeparam name="TEdgeCallback">Type edge callback</typeparam>
        /// 
        /// <param name="output">The output port to set for.</param>
        /// <param name="input">The input port to set for.</param>
        /// 
        /// <returns>A new edge element.</returns>
        TEdge Connect<TPort, TPortCreateDetail, TEdge, TEdgeView, TEdgeObserver, TEdgeCallback>
        (
            TPort output,
            TPort input
        )
            where TPort : PortFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
            where TPortCreateDetail : PortCreateDetailBase
            where TEdge : EdgeFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>, new()
            where TEdgeView: EdgeViewFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>, new()
            where TEdgeObserver : EdgeObserverFrameBase<TEdge>, new()
            where TEdgeCallback : EdgeCallbackFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>, new()
        {
            var view = new TEdgeView().Setup(output, input);
            var observer = new TEdgeObserver();
            var callback = new TEdgeCallback();
            var edge = new TEdge().Setup(view, callback);

            callback.Setup(edge, view);
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
                DefaultEdge m_edge => Save<DefaultPort, PortCreateDetailBase, DefaultEdge,
                             DefaultEdgeView, DefaultEdgeSerializer, EdgeDataBase>(m_edge),

                OptionEdge m_edge => Save<OptionPort, OptionPortCreateDetail, OptionEdge,
                            OptionEdgeView, OptionEdgeSerializer, EdgeDataBase>(m_edge),

                _ => throw new ArgumentException("Invalid edge type: " + edge)
            };
        }


        /// <summary>
        /// Method for saving the edge element's values.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TPortCreateDetail">Type port create detail</typeparam>
        /// <typeparam name="TEdge">Type edge</typeparam>
        /// <typeparam name="TEdgeView">Type edge view</typeparam>
        /// <typeparam name="TEdgeSerializer">Type edge serializer</typeparam>
        /// <typeparam name="TEdgeData">Type edge data</typeparam>
        /// 
        /// <param name="edge">The edge element to set for.</param>
        /// 
        /// <returns>A new edge data.</returns>
        TEdgeData Save<TPort, TPortCreateDetail, TEdge, TEdgeView, TEdgeSerializer, TEdgeData>
        (
            TEdge edge
        )
            where TPort : PortFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
            where TPortCreateDetail : PortCreateDetailBase
            where TEdge : EdgeFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
            where TEdgeView : EdgeViewFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
            where TEdgeSerializer : EdgeSerializerFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView, TEdgeData>, new()
            where TEdgeData : EdgeDataBase, new()
        {
            var data = new TEdgeData();
            new TEdgeSerializer().Save(edge.View, data);
            
            return data;
        }
    }
}