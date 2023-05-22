using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public partial class DefaultPort
    {
        /// <summary>
        /// Method for creating a new default port element.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="direction">The direction type to set for.</param>
        /// <param name="capacity">The capacity type to set for.</param>
        /// <param name="label">The port's label to set for.</param>
        /// <param name="isSiblings">Is the container that the port is created in contains other ports?</param>
        /// <returns>A new default port element.</returns>
        public static DefaultPort CreateElement<TEdge>
        (
            NodeCreateConnectorWindow connectorWindow,
            Direction direction,
            Capacity capacity,
            string label,
            bool isSiblings = false
        )
            where TEdge : Edge, new()
        {
            DefaultPort port;

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
                    capacity: capacity,
                    type: typeof(float)
                );

                isInput = direction == Direction.Input;
            }

            void SetupDetail()
            {
                port.name = Guid.NewGuid().ToString();
                port.portName = label;
                port.portColor = PortConfig.DefaultPortColor;
            }

            void SetupEdgeConnector()
            {
                port.m_EdgeConnector = new EdgeConnector<TEdge>
                (
                    new DefaultEdgeConnectorListener(connectorWindow)
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

                // Remove default USS names
                port.m_ConnectorBox.name = "";
                port.m_ConnectorText.name = "";
                port.m_ConnectorBoxCap.name = "";

                // Add custom USS class.
                if (isInput)
                {
                    port.AddToClassList(StyleConfig.Instance.Default_Input_Port);
                    port.m_ConnectorBox.AddToClassList(StyleConfig.Instance.Default_Input_Connector);
                    port.m_ConnectorText.AddToClassList(StyleConfig.Instance.Default_Input_Label);
                    port.m_ConnectorBoxCap.AddToClassList(StyleConfig.Instance.Default_Input_Cap);
                }
                else
                {
                    port.AddToClassList(StyleConfig.Instance.Default_Output_Port);
                    port.m_ConnectorBox.AddToClassList(StyleConfig.Instance.Default_Output_Connector);
                    port.m_ConnectorText.AddToClassList(StyleConfig.Instance.Default_Output_Label);
                    port.m_ConnectorBoxCap.AddToClassList(StyleConfig.Instance.Default_Output_Cap);
                }

                if (isSiblings)
                {
                    port.AddToClassList(StyleConfig.Instance.Port_Sibling);
                }
            }
        }
    }
}