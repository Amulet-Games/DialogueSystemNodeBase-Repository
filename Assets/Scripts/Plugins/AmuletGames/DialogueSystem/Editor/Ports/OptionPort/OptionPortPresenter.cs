using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class OptionPort
    {
        /// <summary>
        /// Method for creating a new option port element.
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
                port.name = Guid.NewGuid().ToString();

                port.portName = isInput
                    ? StringConfig.OptionPort_Input_LabelText_Disconnect
                    : StringConfig.OptionPort_Output_LabelText_Disconnect;

                port.portColor = PortConfig.OptionPortColor;
            }

            void SetupEdgeConnector()
            {
                port.m_EdgeConnector = new EdgeConnector<TEdge>
                (
                    new OptionEdgeConnectorListener
                    (
                        linkOptionPort: port,
                        connectorWindow: connectorWindow
                    )
                );

                port.AddManipulator(manipulator: port.m_EdgeConnector);
            }

            void SetupStyleSheet()
            {
                port.styleSheets.Clear();
                port.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSOptionPortStyle);
            }

            void SetupStyleClass()
            {
                port.m_ConnectorBoxCap.pickingMode = PickingMode.Position;

                port.m_ConnectorBox.name = "";
                port.m_ConnectorText.name = "";
                port.m_ConnectorBoxCap.name = "";

                port.ClearClassList();
                port.m_ConnectorText.ClearClassList();

                if (isInput)
                {
                    port.AddToClassList(StyleConfig.Option_Input_Port);
                    port.m_ConnectorBox.AddToClassList(StyleConfig.Option_Input_Connector);
                    port.m_ConnectorText.AddToClassList(StyleConfig.Option_Input_Label);
                    port.m_ConnectorBoxCap.AddToClassList(StyleConfig.Option_Input_Cap);
                }
                else
                {
                    port.AddToClassList(StyleConfig.Option_Output_Port);
                    port.m_ConnectorBox.AddToClassList(StyleConfig.Option_Output_Connector);
                    port.m_ConnectorText.AddToClassList(StyleConfig.Option_Output_Label);
                    port.m_ConnectorBoxCap.AddToClassList(StyleConfig.Option_Output_Cap);
                }
            }
        }
    }
}