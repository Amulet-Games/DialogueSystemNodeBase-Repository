using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEngine;

namespace AG
{
    public class DSPortsMaker
    {
        /// <summary>
        /// Returns a new input port.
        /// </summary>
        /// <param name="node">Node of which this port is created for.</param>
        /// <param name="portName">The name of the port, it'll appear next to the port if the value is not empty.</param>
        /// <param name="capacity">The type determines how many edges a port can have for connection.</param>
        /// <returns>An input port that can connect to another node or nodes if capacity is set to multiple.</returns>
        public static Port GetNewInputPort(DSNodeBase node, string portName, Port.Capacity capacity)
        {
            Port newInputPort;

            CreatePortInstance();

            SetupPortDetail();

            SetupEdgeConnector();

            AddPortToContainer();

            AddStyleSheet();

            OverridePortDefaultStyle();

            return newInputPort;

            void CreatePortInstance()
            {
                newInputPort = node.InstantiatePort(Orientation.Horizontal, Direction.Input, capacity, typeof(float));
            }

            void SetupPortDetail()
            {
                newInputPort.name = Guid.NewGuid().ToString();
                newInputPort.portName = portName;
                newInputPort.portColor = new Color(1, 1, 1);
            }

            void SetupEdgeConnector()
            {
                // Add default edge connector listener to the port.
                newInputPort.AddManipulator
                (
                    new EdgeConnector<Edge>
                    (
                        new DSDefaultEdgeConnectorListener(node.GraphView.NodeCreationConnectorWindow)
                    )
                );
            }

            void AddPortToContainer()
            {
                node.inputContainer.Add(newInputPort);
            }

            void AddStyleSheet()
            {
                newInputPort.styleSheets.Add(DSStylesConfig.DSNodesShareStyle);
            }

            void OverridePortDefaultStyle()
            {
                // Get the port connector from port's children.
                VisualElement connector = newInputPort.ElementAt(0);
                // Get the port label element from port's children.
                VisualElement label = newInputPort.ElementAt(1);
                // Get the port connector cap from connector's children.
                VisualElement cap = connector.ElementAt(0);

                // Override defualt picking mode.
                cap.pickingMode = PickingMode.Position;

                // Remove the default USS names
                connector.name = "";
                label.name = "";
                cap.name = "";

                // Add to custom USS class.
                newInputPort.AddToClassList(DSStylesConfig.Node_Input_Port);
                connector.AddToClassList(DSStylesConfig.Node_Input_Connector);
                label.AddToClassList(DSStylesConfig.Node_Input_Label);
                cap.AddToClassList(DSStylesConfig.Node_Input_Cap);
            }
        }


        /// <summary>
        /// Returns a new output port.
        /// </summary>
        /// <param name="node">Node of which this port is created for.</param>
        /// <param name="isSiblings">Is the port a sibing to the first ouput port within the same hierarchy.</param>
        /// <param name="portName">The name of the port, it'll appear next to the port if the value is not empty.</param>
        /// <param name="capacity">The type determines how many edges a port can have for connection.</param>
        /// <returns>A output port that can connect to another node or nodes if capacity is set to multiple.</returns>
        public static Port GetNewOutputPort(DSNodeBase node, bool isSiblings, string portName, Port.Capacity capacity)
        {
            Port newOutputPort;

            CreatePortInstance();

            SetupPortDetail();

            SetupEdgeConnector();

            AddPortToContainer();

            AddStyleSheet();

            OverridePortDefaultStyle();

            return newOutputPort;

            void CreatePortInstance()
            {
                newOutputPort = node.InstantiatePort(Orientation.Horizontal, Direction.Output, capacity, typeof(float));
            }

            void SetupPortDetail()
            {
                newOutputPort.name = Guid.NewGuid().ToString();
                newOutputPort.portName = portName;
                newOutputPort.portColor = new Color(1, 1, 1);
            }

            void SetupEdgeConnector()
            {
                // Add default edge connector listener to the port.
                newOutputPort.AddManipulator
                (
                    new EdgeConnector<Edge>
                    (
                        new DSDefaultEdgeConnectorListener(node.GraphView.NodeCreationConnectorWindow)
                    )
                );
            }

            void AddPortToContainer()
            {
                node.outputContainer.Add(newOutputPort);
            }

            void AddStyleSheet()
            {
                newOutputPort.styleSheets.Add(DSStylesConfig.DSNodesShareStyle);
            }

            void OverridePortDefaultStyle()
            {
                // Get the port connector from port's children.
                VisualElement connector = newOutputPort.ElementAt(0);
                // Get the port label element from port's children.
                VisualElement label = newOutputPort.ElementAt(1);
                // Get the port connector cap from connector's children.
                VisualElement cap = connector.ElementAt(0);

                // Override defualt picking mode.
                cap.pickingMode = PickingMode.Position;

                // Remove the default USS names
                connector.name = "";
                label.name = "";
                cap.name = "";

                // Add to custom USS class.
                newOutputPort.AddToClassList(DSStylesConfig.Node_Output_Port);
                connector.AddToClassList(DSStylesConfig.Node_Output_Connector);
                label.AddToClassList(DSStylesConfig.Node_Output_Label);
                cap.AddToClassList(DSStylesConfig.Node_Output_Cap);

                // If the port is a sibling to another port within the same output container
                if (isSiblings)
                {
                    // Add an extra sibling style.
                    newOutputPort.AddToClassList(DSStylesConfig.Node_Port_Sibling);
                }
            }
        }
    }
}