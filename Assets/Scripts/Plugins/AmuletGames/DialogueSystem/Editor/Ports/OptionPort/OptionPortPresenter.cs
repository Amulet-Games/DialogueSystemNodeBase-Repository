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
        public static OptionPort CreateElements<TEdge>
        (
            NodeCreationConnectorWindow connectorWindow,
            Direction direction
        )
            where TEdge : Edge, new()
        {
            OptionPort port;

            bool isInput;

            CreatePort();

            SetupDetail();

            SetupEdgeConnector();

            ClearPresetStyleSheets();

            OverridePortDefaultStyle();

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

            void SetupDetail()
            {
                port.name = Guid.NewGuid().ToString();

                port.portName = isInput
                    ? StringConfig.Instance.OptionPort_Disconnect_Input_LabelText
                    : StringConfig.Instance.OptionPort_Disconnect_Output_LabelText;

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

            void ClearPresetStyleSheets()
            {
                port.styleSheets.Clear();
            }

            void OverridePortDefaultStyle()
            {
                port.m_ConnectorBoxCap.pickingMode = PickingMode.Position;

                // Remove the default USS names
                port.m_ConnectorBox.name = "";
                port.m_ConnectorText.name = "";
                port.m_ConnectorBoxCap.name = "";

                // Add to custom USS class.
                if (isInput)
                {
                    port.AddToClassList(StyleConfig.Instance.Option_Input_Port);
                    port.m_ConnectorBox.AddToClassList(StyleConfig.Instance.Option_Input_Connector);
                    port.m_ConnectorText.AddToClassList(StyleConfig.Instance.Option_Input_Label);
                    port.m_ConnectorBoxCap.AddToClassList(StyleConfig.Instance.Option_Input_Cap);
                }
                else
                {
                    port.AddToClassList(StyleConfig.Instance.Option_Output_Port);
                    port.m_ConnectorBox.AddToClassList(StyleConfig.Instance.Option_Output_Connector);
                    port.m_ConnectorText.AddToClassList(StyleConfig.Instance.Option_Output_Label);
                    port.m_ConnectorBoxCap.AddToClassList(StyleConfig.Instance.Option_Output_Cap);
                }
            }
        }
    }
}