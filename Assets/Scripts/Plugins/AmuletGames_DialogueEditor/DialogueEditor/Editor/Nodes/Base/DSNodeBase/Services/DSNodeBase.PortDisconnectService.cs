using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    /// <summary>
    /// Extension class of dialogue system node base class,
    /// which provides low level methods for other classes, for a specific use case.
    /// </summary>
    public abstract partial class DSNodeBase
    {
        // ----------------------------- Port Disconnect Services -----------------------------
        /// <summary>
        /// Use the method below to delete the ports inside both the input and output container of the node.
        /// </summary>
        public void DisconnectAllPorts()
        {
            DisconnectInputPorts();
            DisconnectOutputPorts();
        }


        /// <summary>
        /// Use the method below to delete the ports inside the input container of the node.
        /// </summary>
        protected void DisconnectInputPorts()
        {
            DisconnectPorts(inputContainer);
        }


        /// <summary>
        /// Use the method below to delete the ports inside the output container of the node.
        /// </summary>
        protected void DisconnectOutputPorts()
        {
            DisconnectPorts(outputContainer);
        }


        /// <summary>
        /// Disconnect ports within the provoided container and delete the connections
        /// <br>between the port and the other node which it were connected to.</br>
        /// </summary>
        /// <param name="container"></param>
        void DisconnectPorts(VisualElement container)
        {
            // Try to find any visual elements that are type ports.
            foreach (Port port in container.Children())
            {
                // Skip the port that isn't connecting to any nodes.
                if (!port.connected)
                {
                    continue;
                }

                // Delete the ports and it's connections.
                GraphView.DeleteElements(port.connections);
            }
        }
    }
}