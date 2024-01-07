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
            var model = new PortModel
            (
                port: PortModel.Port.Default,
                direction,
                capacity,
                name,
                PortConfig.DefaultPortColor
            );

            return Create<DefaultPort, DefaultPortPresenter, DefaultPortCallback,
                    DefaultEdgeConnectorCallback, NodeCreateDefaultConnectorWindow>(connectorWindow, model);
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
            Direction direction
        )
        {
            var model = new PortModel
            (
                port: PortModel.Port.Option,
                direction,
                capacity: Capacity.Single,
                name: direction == Direction.Input
                    ? StringConfig.OptionPortGroupCell_Input_Disconnect_LabelText
                    : StringConfig.OptionPortGroupCell_Output_Disconnect_LabelText,
                color: PortConfig.OptionPortColor
            );

            return Create<OptionPort, OptionPortPresenter, OptionPortCallback,
                    OptionEdgeConnectorCallback, NodeCreateOptionConnectorWindow>(connectorWindow, model);
        }


        /// <summary>
        /// Method for creating a new port element.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TPortPresenter">Type port presenter</typeparam>
        /// <typeparam name="TEdgeConnectorCallback">Type connector callback</typeparam>
        /// <typeparam name="TNodeCreateConnectorWindow">Type node create connector window</typeparam>
        /// 
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="model">The port model to set for.</param>
        /// 
        /// <returns>A port element.</returns>
        TPort Create
        <
            TPort,
            TPortPresenter,
            TPortCallback,
            TEdgeConnectorCallback,
            TNodeCreateConnectorWindow
        >
        (
            TNodeCreateConnectorWindow connectorWindow,
            PortModel model
        )
            where TPort : Port<TPort>
            where TPortPresenter: PortPresenterFrameBase<TPort, TPortPresenter>, new()
            where TPortCallback: PortCallbackFrameBase<TPort, TPortCallback>, new()
            where TEdgeConnectorCallback : EdgeConnectorCallbackFrameBase<TPort, TEdgeConnectorCallback, TNodeCreateConnectorWindow>, new()
            where TNodeCreateConnectorWindow: NodeCreateConnectorWindowFrameBase<TPort, TNodeCreateConnectorWindow>
        {
            TPort port = new TPortPresenter().Create(model);
            TPortCallback callback = new TPortCallback().Setup(port);

            var edgeConnector = new EdgeConnector<Edge<TPort>>
            (
                listener: new TEdgeConnectorCallback().Setup(port, connectorWindow)
            );

            port.Setup(edgeConnector, callback);
            return port;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save the default port values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <returns>A new port data.</returns>
        public PortData Save(DefaultPort port)
            => Save<DefaultPort, DefaultPortSerializer, PortData>(port);


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
            where TPortData : PortData, new()
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
        public void Load(DefaultPort port, PortData data)
            => Load<DefaultPort , DefaultPortSerializer, PortData>(port, data);


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
            where TPortData : PortData
        {
            new TPortSerializer().Load(port, data);
        }
    }
}