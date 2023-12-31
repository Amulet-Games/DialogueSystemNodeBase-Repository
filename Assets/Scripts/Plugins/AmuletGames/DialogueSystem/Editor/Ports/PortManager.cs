using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public class PortManager
    {
        /// <summary>
        /// The singleton reference of the class.
        /// </summary>
        public static PortManager Instance { get; private set; } = null;


        /// <summary>
        /// Setup for the port manager class.
        /// </summary>
        public static void Setup()
        {
            Instance ??= new();
        }


        // ----------------------------- Create -----------------------------
        /// <summary>
        /// Method for creating a new default port element. 
        /// </summary>
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="capacity">The capacity to set for.</param>
        /// <param name="name">The name to set for.</param>
        /// <returns>A new default port element.</returns>
        public DefaultPort CreateDefault
        (
            NodeCreateDefaultConnectorWindow connectorWindow,
            Direction direction,
            Capacity capacity,
            string name
        )
        {
            var detail = new PortCreateDetailBase
            (
                portType: PortType.DEFAULT,
                direction,
                capacity,
                name
            );

            return Create<DefaultPort, PortCreateDetailBase, DefaultPortPresenter, DefaultEdge, DefaultEdgeView,
                    DefaultEdgeConnectorCallback, NodeCreateDefaultConnectorWindow>(connectorWindow, detail);
        }


        /// <summary>
        /// Method for creating a new option port element.
        /// </summary>
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <returns>A new option port element.</returns>
        public OptionPort CreateOption
        (
            NodeCreateOptionConnectorWindow connectorWindow,
            Direction direction,
            bool isGroup
        )
        {
            var detail = new OptionPortCreateDetail
            (
                portType: PortType.OPTION,
                direction,
                capacity: Capacity.Single,
                name: direction == Direction.Input
                    ? StringConfig.OptionPort_Input_LabelText_Disconnect
                    : StringConfig.OptionPort_Output_LabelText_Disconnect,
                isGroup
            );

            return Create<OptionPort, OptionPortCreateDetail, OptionPortPresenter, OptionEdge, OptionEdgeView,
                    OptionEdgeConnectorCallback, NodeCreateOptionConnectorWindow>(connectorWindow, detail);
        }


        /// <summary>
        /// Method for creating a new port element.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TPortCreateDetail">Type port create detail</typeparam>
        /// <typeparam name="TPortPresenter">Type port presenter</typeparam>
        /// <typeparam name="TEdge">Type edge</typeparam>
        /// <typeparam name="TEdgeView">Type edge view</typeparam>
        /// <typeparam name="TEdgeConnectorCallback">Type connector callback</typeparam>
        /// <typeparam name="TNodeCreateConnectorWindow">Type node create connector window</typeparam>
        /// 
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="detail">The port create detail to set for.</param>
        /// 
        /// <returns>A port element.</returns>
        TPort Create
        <
            TPort,
            TPortCreateDetail,
            TPortPresenter,
            TEdge,
            TEdgeView,
            TEdgeConnectorCallback,
            TNodeCreateConnectorWindow
        >
        (
            TNodeCreateConnectorWindow connectorWindow,
            TPortCreateDetail detail
        )
            where TPort : PortFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
            where TPortCreateDetail : PortCreateDetailBase
            where TPortPresenter: PortPresenterFrameBase<TPort, TPortCreateDetail, TPortPresenter, TEdge, TEdgeView>, new()
            where TEdge : EdgeFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>, new()
            where TEdgeView: EdgeViewFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView>
            where TEdgeConnectorCallback : EdgeConnectorCallbackFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView, TEdgeConnectorCallback, TNodeCreateConnectorWindow>, new()
            where TNodeCreateConnectorWindow: NodeCreateConnectorWindowFrameBase<TPort, TPortCreateDetail, TEdge, TEdgeView, TNodeCreateConnectorWindow>
        {
            TPort port = new TPortPresenter().Setup(detail).Create();

            var edgeConnector = new EdgeConnector<TEdge>(
                listener: new TEdgeConnectorCallback().Setup(port, connectorWindow)
            );

            port.Setup(edgeConnector, detail);
            return port;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save the default port values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <returns>A new port data.</returns>
        public PortDataBase Save(DefaultPort port)
            => Save<DefaultPort, DefaultPortSerializer, PortDataBase>(port);


        /// <summary>
        /// Save the option port values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <returns>A new port data.</returns>
        public OptionPortData Save(OptionPort port)
            => Save<OptionPort, OptionPortSerializer, OptionPortData>(port);


        /// <summary>
        /// Save the port element values.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TPortSerializer">Type port serializer</typeparam>
        /// <typeparam name="TPortData">Type port data</typeparam>
        /// 
        /// <param name="port">THe port element to set for.</param>
        /// 
        /// <returns>A new port data.</returns>
        TPortData Save<TPort, TPortSerializer, TPortData>
        (
            TPort port
        )
            where TPort: PortBase
            where TPortSerializer : PortSerializerFrameBase<TPort, TPortData>, new()
            where TPortData : PortDataBase, new()
        {
            TPortData data = new();
            new TPortSerializer().Save(port, data);

            return data;
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load the default port values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="data">The port data to set for.</param>
        public void Load(DefaultPort port, PortDataBase data)
            => Load<DefaultPort , DefaultPortSerializer, PortDataBase>(port, data);


        /// <summary>
        /// Load the option port values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="data">The port data to set for.</param>
        public void Load(OptionPort port, OptionPortData data)
            => Load<OptionPort, OptionPortSerializer, OptionPortData>(port, data);


        /// <summary>
        /// Load the port element values.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TPortSerializer">Type port serializer</typeparam>
        /// <typeparam name="TPortData">Type port data</typeparam>
        /// 
        /// <param name="port">THe port element to set for.</param>
        /// <param name="data">THe port data to set for.</param>
        void Load<TPort, TPortSerializer, TPortData>
        (
            TPort port,
            TPortData data
        )
            where TPort : PortBase
            where TPortSerializer : PortSerializerFrameBase<TPort, TPortData>, new()
            where TPortData : PortDataBase
        {
            new TPortSerializer().Load(port, data);
        }
    }
}