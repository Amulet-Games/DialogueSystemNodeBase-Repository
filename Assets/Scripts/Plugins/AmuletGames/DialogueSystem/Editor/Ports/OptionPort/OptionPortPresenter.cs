using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public class OptionPortPresenter
    {
        /// <summary>
        /// Create a new option port element.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="direction">The direction type to set for.</param>
        /// <returns>A new option port element.</returns>
        public static OptionPort CreateElement<TEdge>
        (
            NodeCreateConnectorWindow connectorWindow,
            Direction direction
        )
            where TEdge : Edge, new()
        {
            OptionPort port;

            bool isInput;

            CreatePort();

            SetupDetails();

            SetupEdgeConnector();

            SetupStyleSheet();

            SetupStyleClass();

            return port;

            void CreatePort()
            {
                port = new
                (
                    orientation: Orientation.Horizontal,
                    direction: direction,
                    capacity: Capacity.Single,
                    type: typeof(float)
                );

                isInput = direction == Direction.Input;
            }

            void SetupDetails()
            {
                port.Guid = Guid.NewGuid().ToString();

                port.portName = isInput
                    ? StringConfig.OptionPort_Input_LabelText_Disconnect
                    : StringConfig.OptionPort_Output_LabelText_Disconnect;

                port.portColor = PortConfig.OptionPortColor;
            }

            void SetupEdgeConnector()
            {
                port.EdgeConnector = new EdgeConnector<TEdge>
                (
                    new OptionEdgeConnectorCallback
                    (
                        linkOptionPort: port,
                        connectorWindow: connectorWindow
                    )
                );

                port.AddManipulator(manipulator: port.EdgeConnector);
            }

            void SetupStyleSheet()
            {
                port.styleSheets.Clear();
                port.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSOptionPortStyle);
            }

            void SetupStyleClass()
            {
                port.ConnectorBoxCap.pickingMode = PickingMode.Position;

                port.ConnectorBox.name = "";
                port.ConnectorText.name = "";
                port.ConnectorBoxCap.name = "";

                port.ClearClassList();
                port.ConnectorText.ClearClassList();

                if (isInput)
                {
                    port.AddToClassList(StyleConfig.Option_Input_Port);
                    port.ConnectorBox.AddToClassList(StyleConfig.Option_Input_Connector);
                    port.ConnectorText.AddToClassList(StyleConfig.Option_Input_Label);
                    port.ConnectorBoxCap.AddToClassList(StyleConfig.Option_Input_Cap);
                }
                else
                {
                    port.AddToClassList(StyleConfig.Option_Output_Port);
                    port.ConnectorBox.AddToClassList(StyleConfig.Option_Output_Connector);
                    port.ConnectorText.AddToClassList(StyleConfig.Option_Output_Label);
                    port.ConnectorBoxCap.AddToClassList(StyleConfig.Option_Output_Cap);
                }
            }
        }
    }
}