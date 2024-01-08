using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
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
        public PortBase CreateDefault
        (
            NodeCreateDefaultConnectorWindow connectorWindow,
            Direction direction,
            Capacity capacity,
            string name
        )
        {
            var detail = new PortModel
            (
                port: PortModel.Port.Default,
                direction,
                capacity,
                name,
                PortConfig.DefaultPortColor
            );

            return Create<DefaultEdgeConnectorCallback, NodeCreateDefaultConnectorWindow>
            (
                ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle,
                connectorWindow,
                detail
            );
        }


        /// <summary>
        /// Method for creating a new option port element.
        /// </summary>
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <returns>A new option port element.</returns>
        public PortBase CreateOption
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

            return Create<OptionEdgeConnectorCallback, NodeCreateOptionConnectorWindow>
            (
                ConfigResourcesManager.StyleSheetConfig.OptionEdgeStyle,
                connectorWindow,
                model
            );
        }


        /// <summary>
        /// Method for creating a new port element.
        /// </summary>
        /// 
        /// <typeparam name="TEdgeConnectorCallback">Type connector callback</typeparam>
        /// <typeparam name="TNodeCreateConnectorWindow">Type node create connector window</typeparam>
        /// 
        /// <param name="connectorEdgeStyleSheet">The connector edge style sheet to set for.</param>
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="model">The port model to set for.</param>
        /// 
        /// <returns>A port element.</returns>
        PortBase Create
        <
            TEdgeConnectorCallback,
            TNodeCreateConnectorWindow
        >
        (
            StyleSheet connectorEdgeStyleSheet,
            TNodeCreateConnectorWindow connectorWindow,
            PortModel model
        )
            where TEdgeConnectorCallback : EdgeConnectorCallbackFrameBase<TEdgeConnectorCallback, TNodeCreateConnectorWindow>, new()
            where TNodeCreateConnectorWindow: NodeCreateConnectorWindowFrameBase<TNodeCreateConnectorWindow>
        {
            var port = new PortPresenter().Create(model);
            var callback = new PortCallback().Setup(port);

            var edgeConnector = new EdgeConnector<EdgeBase>
            (
                listener: new TEdgeConnectorCallback().Setup
                (
                    connectorPort: port,
                    connectorEdgeStyleSheet: connectorEdgeStyleSheet,
                    connectorWindow
                )
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
        public PortData Save(PortBase port) => Save<DefaultPortSerializer, PortData>(port);


        /// <summary>
        /// Save the option port values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <returns>A new port data.</returns>
        public OptionPortData SaveOption(PortBase port) => Save<OptionPortSerializer, OptionPortData>(port);


        /// <summary>
        /// Save the port element values.
        /// </summary>
        /// 
        /// <typeparam name="TPortSerializer">Type port serializer</typeparam>
        /// <typeparam name="TPortData">Type port data</typeparam>
        /// 
        /// <param name="port">THe port element to set for.</param>
        /// 
        /// <returns>A new port data.</returns>
        TPortData Save<TPortSerializer, TPortData>
        (
            PortBase port
        )
            where TPortSerializer : PortSerializerFrameBase<TPortData>, new()
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
        public void Load(PortBase port, PortData data) => Load<DefaultPortSerializer, PortData>(port, data);


        /// <summary>
        /// Load the option port values.
        /// </summary>
        /// <param name="port">The port element to set for.</param>
        /// <param name="data">The port data to set for.</param>
        public void Load(PortBase port, OptionPortData data) => Load<OptionPortSerializer, OptionPortData>(port, data);


        /// <summary>
        /// Load the port element values.
        /// </summary>
        /// 
        /// <typeparam name="TPortSerializer">Type port serializer</typeparam>
        /// <typeparam name="TPortData">Type port data</typeparam>
        /// 
        /// <param name="port">The port element to set for.</param>
        /// <param name="data">The port data to set for.</param>
        void Load<TPortSerializer, TPortData>
        (
            PortBase port,
            TPortData data
        )
            where TPortSerializer : PortSerializerFrameBase<TPortData>, new()
            where TPortData : PortData
        {
            new TPortSerializer().Load(port, data);
        }
    }
}