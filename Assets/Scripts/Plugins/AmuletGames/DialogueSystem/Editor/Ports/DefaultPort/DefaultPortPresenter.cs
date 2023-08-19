using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    public class DefaultPortPresenter
    {
        /// <summary>
        /// Create a new default port element.
        /// </summary>
        /// <typeparam name="TEdge">Edge type</typeparam>
        /// <param name="connectorWindow">The connector window to set for.</param>
        /// <param name="direction">The direction type to set for.</param>
        /// <param name="capacity">The capacity type to set for.</param>
        /// <param name="label">The port's label to set for.</param>
        /// <param name="isSiblings">Is this port a sibling to another already existed port?</param>
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
                    capacity: capacity,
                    type: typeof(float)
                );

                isInput = direction == Direction.Input;
            }

            void SetupDetails()
            {
                port.name = Guid.NewGuid().ToString();
                port.portName = label;
                port.portColor = PortConfig.DefaultPortColor;
            }

            void SetupEdgeConnector()
            {
                port.EdgeConnector = new EdgeConnector<TEdge>
                (
                    new DefaultEdgeConnectorListener(connectorWindow)
                );

                port.AddManipulator(manipulator: port.EdgeConnector);
            }

            void SetupStyleSheet()
            {
                port.styleSheets.Clear();
                port.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.DSDefaultPortStyle);
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
                    port.AddToClassList(StyleConfig.Default_Input_Port);
                    port.ConnectorBox.AddToClassList(StyleConfig.Default_Input_Connector);
                    port.ConnectorText.AddToClassList(StyleConfig.Default_Input_Label);
                    port.ConnectorBoxCap.AddToClassList(StyleConfig.Default_Input_Cap);
                }
                else
                {
                    port.AddToClassList(StyleConfig.Default_Output_Port);
                    port.ConnectorBox.AddToClassList(StyleConfig.Default_Output_Connector);
                    port.ConnectorText.AddToClassList(StyleConfig.Default_Output_Label);
                    port.ConnectorBoxCap.AddToClassList(StyleConfig.Default_Output_Cap);
                }

                if (isSiblings)
                {
                    port.AddToClassList(StyleConfig.Port_Sibling);
                }
            }
        }
    }
}