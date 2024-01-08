using UnityEditor.Experimental.GraphView;
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
            var model = new PortModel
            (
                port: PortModel.Port.Default,
                direction,
                capacity,
                name,
                PortConfig.DefaultPortColor
            );

            return Create<DefaultEdgeConnectorCallback, NodeCreateDefaultConnectorWindow>
            (
                model,
                ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle,
                connectorWindow
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
                    ? StringConfig.OptionPortCell_Input_Disconnect_LabelText
                    : StringConfig.OptionPortCell_Output_Disconnect_LabelText,
                color: PortConfig.OptionPortColor
            );

            return Create<OptionEdgeConnectorCallback, NodeCreateOptionConnectorWindow>
            (
                model,
                ConfigResourcesManager.StyleSheetConfig.OptionEdgeStyle,
                connectorWindow
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
            PortModel model,
            StyleSheet connectorEdgeStyleSheet,
            TNodeCreateConnectorWindow connectorWindow
        )
            where TEdgeConnectorCallback : EdgeConnectorCallbackFrameBase<TEdgeConnectorCallback, TNodeCreateConnectorWindow>, new()
            where TNodeCreateConnectorWindow: NodeCreateConnectorWindowFrameBase<TNodeCreateConnectorWindow>
        {
            var callback = new PortCallback();
            var port = PortPresenter.CreateElement(model);

            var edgeConnector = new EdgeConnector<EdgeBase>
            (
                listener: new TEdgeConnectorCallback().Setup
                (
                    nodeCreateConnectorWindow: connectorWindow,
                    connectorPort: port,
                    connectorEdgeStyleSheet: connectorEdgeStyleSheet
                )
            );

            port.Setup(edgeConnector, callback);
            callback.Setup(port);

            return port;
        }
    }
}