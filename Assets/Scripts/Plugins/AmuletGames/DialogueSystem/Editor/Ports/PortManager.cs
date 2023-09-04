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
            NodeCreateConnectorWindow connectorWindow,
            Direction direction,
            Capacity capacity,
            string name
        )
        {
            var detail = new PortCreateDetail
            (
                portType: PortType.DEFAULT,
                direction,
                capacity,
                name
            );

            return Create<DefaultPort, DefaultPortPresenter, DefaultEdge,
                DefaultEdgeView, DefaultEdgeConnectorCallback>(connectorWindow, detail);
        }


        /// <summary>
        /// Method for creating a new option port element.
        /// </summary>
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <returns>A new option port element.</returns>
        public OptionPort CreateOption
        (
            NodeCreateConnectorWindow connectorWindow,
            Direction direction
        )
        {
            var detail = new PortCreateDetail
            (
                portType: PortType.OPTION,
                direction,
                capacity: Capacity.Single,
                name: direction == Direction.Input
                    ? StringConfig.OptionPort_Input_LabelText_Disconnect
                    : StringConfig.OptionPort_Output_LabelText_Disconnect
            );

            return Create<OptionPort, OptionPortPresenter, OptionEdge,
                OptionEdgeView, OptionEdgeConnectorCallback>(connectorWindow, detail);
        }


        /// <summary>
        /// Method for creating a new port element.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TPortPresenter">Type port presenter</typeparam>
        /// <typeparam name="TEdge">Type edge</typeparam>
        /// <typeparam name="TEdgeView">Type edge view</typeparam>
        /// <typeparam name="TEdgeConnectorCallback">Type connector callback</typeparam>
        /// 
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="detail">The port create detail to set for.</param>
        /// 
        /// <returns>A port element.</returns>
        TPort Create<TPort, TPortPresenter, TEdge, TEdgeView, TEdgeConnectorCallback>
        (
            NodeCreateConnectorWindow connectorWindow,
            PortCreateDetail detail
        )
            where TPort : PortFrameBase<TPort, TEdge, TEdgeView>
            where TPortPresenter: PortPresenterFrameBase<TPort, TEdge, TEdgeView, TPortPresenter>, new()
            where TEdge : EdgeFrameBase<TPort, TEdge, TEdgeView>, new()
            where TEdgeView: EdgeViewFrameBase<TPort, TEdgeView>
            where TEdgeConnectorCallback : EdgeConnectorCallbackFrameBase<TPort, TEdge, TEdgeConnectorCallback>, new()
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
        /// <returns>A new port model.</returns>
        public PortModelBase Save(DefaultPort port)
            => Save<DefaultPort, DefaultPortSerializer, PortModelBase>(port);


        /// <summary>
        /// Save the option port values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <returns>A new port model.</returns>
        public OptionPortModel Save(OptionPort port)
            => Save<OptionPort, OptionPortSerializer, OptionPortModel>(port);


        /// <summary>
        /// Save the port element values.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TPortSerializer">Type port serializer</typeparam>
        /// <typeparam name="TPortModel">Type port model</typeparam>
        /// 
        /// <param name="port">THe port element to set for.</param>
        /// 
        /// <returns>A new port model.</returns>
        TPortModel Save<TPort, TPortSerializer, TPortModel>
        (
            TPort port
        )
            where TPort: PortBase
            where TPortSerializer : PortSerializerFrameBase<TPort, TPortModel>, new()
            where TPortModel : PortModelBase, new()
        {
            TPortModel model = new();
            new TPortSerializer().Save(port, model);

            return model;
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load the default port values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="model">The port model to set for.</param>
        public void Load(DefaultPort port, PortModelBase model)
            => Load<DefaultPort , DefaultPortSerializer, PortModelBase>(port, model);


        /// <summary>
        /// Load the option port values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="model">The port model to set for.</param>
        public void Load(OptionPort port, OptionPortModel model)
            => Load<OptionPort, OptionPortSerializer, OptionPortModel>(port, model);


        /// <summary>
        /// Load the port element values.
        /// </summary>
        /// 
        /// <typeparam name="TPort">Type port</typeparam>
        /// <typeparam name="TPortSerializer">Type port serializer</typeparam>
        /// <typeparam name="TPortModel">Type port model</typeparam>
        /// 
        /// <param name="port">THe port element to set for.</param>
        /// <param name="model">THe port model to set for.</param>
        void Load<TPort, TPortSerializer, TPortModel>
        (
            TPort port,
            TPortModel model
        )
            where TPort : PortBase
            where TPortSerializer : PortSerializerFrameBase<TPort, TPortModel>, new()
            where TPortModel : PortModelBase
        {
            new TPortSerializer().Load(port, model);
        }
    }
}