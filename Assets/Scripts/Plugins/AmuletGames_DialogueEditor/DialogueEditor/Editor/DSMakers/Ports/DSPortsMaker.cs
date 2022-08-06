using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace AG
{
    public class DSPortsMaker : MonoBehaviour
    {
        /// <summary>
        /// Create a new node's input port.
        /// </summary>
        /// <param name="node">Node of which this port is created for.</param>
        /// <param name="name">The name of this port, it comes in handy when save and load the entry later.</param>
        /// <param name="capacity">The type determines how many edges a port can have for connection.</param>
        /// <param name="nodeType">The type of the node that this port is created for.</param>
        /// <returns>A input port for other node or nodes if capacity is set to multiple, to connected to the node within.</returns>
        public static Port AddInputPort(DSNodeBase node, string name, Port.Capacity capacity, N_NodeType nodeType)
        {
            Port newInputPort;

            CreatePortInstance();

            SetupPortDetail();

            AddPortToContainer();

            return newInputPort;

            void CreatePortInstance()
            {
                newInputPort = node.InstantiatePort(Orientation.Horizontal, Direction.Input, capacity, typeof(float));
            }

            void SetupPortDetail()
            {
                newInputPort.name = Guid.NewGuid().ToString();
                newInputPort.portName = name;
                newInputPort.portColor = DSPortsUtility.GetPortColorByNodeType(nodeType);
            }

            void AddPortToContainer()
            {
                node.inputContainer.Add(newInputPort);
            }
        }


        /// <summary>
        /// Create a new node's output port.
        /// </summary>
        /// <param name="node">Node of which this port is created for.</param>
        /// <param name="portName">The name of this port, it comes in handy when save and load the entry later.</param>
        /// <param name="capacity">The type determines how many edges a port can have for connection.</param>
        /// <param name="nodeType">The type of the node that this port is created for.</param>
        /// <returns>A output port for connecting the node within to the other node or nodes if capacity is set to multiple.</returns>
        public static Port AddOutputPort(DSNodeBase node, string portName, Port.Capacity capacity, N_NodeType nodeType)
        {
            Port newOutputPort;

            CreatePortInstance();

            SetupPortDetail();

            AddPortToContainer();

            return newOutputPort;

            void CreatePortInstance()
            {
                newOutputPort = node.InstantiatePort(Orientation.Horizontal, Direction.Output, capacity, typeof(float));
            }

            void SetupPortDetail()
            {
                newOutputPort.name = Guid.NewGuid().ToString();
                newOutputPort.portName = portName;
                newOutputPort.portColor = DSPortsUtility.GetPortColorByNodeType(nodeType);
            }

            void AddPortToContainer()
            {
                node.outputContainer.Add(newOutputPort);
            }
        }
    }
}