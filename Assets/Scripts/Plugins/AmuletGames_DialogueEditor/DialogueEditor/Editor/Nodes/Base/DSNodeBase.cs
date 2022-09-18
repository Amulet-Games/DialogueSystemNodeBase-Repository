using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    /// <summary>
    /// Main class of dialogue system node base class.
    /// <para>
    /// Service methods are separated into different scripts as partial class,
    /// and are located inside the same extension folders.
    /// </para>
    /// </summary>
    public abstract class DSNodeBase: Node
    {
        /// <summary>
        /// Reference of the graph view module in the dialogue system.
        /// </summary>
        public DSGraphView GraphView;


        /// <summary>
        /// The special GUID id of this node.
        /// </summary>
        public string NodeGuid;


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The callback action to invoke when the nodes is deleted by users from the graph manually.
        /// <br>This action happens before the node is being removed from the graph.</br>
        /// </summary>
        public abstract void PreManualRemovedAction();


        /// <summary>
        /// The callback action to invoke when the nodes is deleted by users from the graph manually.
        /// <br>This action happens before the node is removed from the graph.</br>
        /// </summary>
        public abstract void PostManualRemovedAction();


        /// <summary>
        /// The callback action to invoke when the node is added on the graph by users manually.
        /// <br>(by contextual menu or search window).</br>
        /// <para></para>
        /// This action happens after InitalizedAction is called.
        /// </summary>
        /// <param name="creationDetails">Reference of the dialogue system's node creation details.</param>
        public abstract void ManualCreatedAction(DSNodeCreationDetails creationDetails);


        // ----------------------------- Element Deletion Services -----------------------------
        /// <summary>
        /// Delete the desired visual element that are created within the node.
        /// </summary>
        /// <param name="visualElement">The visual element to be deleted.</param>
        /// <param name="nodeContainerType">The container that the visual element was added in.</param>
        public void DeleteVisualElement(VisualElement visualElement, N_NodeContainerType nodeContainerType)
        {
            switch (nodeContainerType)
            {
                case N_NodeContainerType.Extension:
                    extensionContainer.Remove(visualElement);
                    RefreshExpandedState();
                    break;
                case N_NodeContainerType.Top:
                    topContainer.Remove(visualElement);
                    break;
                case N_NodeContainerType.TitleButton:
                    titleButtonContainer.Remove(visualElement);
                    break;
                case N_NodeContainerType.Title:
                    titleContainer.Remove(visualElement);
                    break;
                case N_NodeContainerType.Main:
                    mainContainer.Remove(visualElement);
                    break;
            }
        }


        /// <summary>
        /// Delete the desired visual element that are created within the node.
        /// </summary>
        /// <param name="visualElement">The visual element to be deleted.</param>
        /// <param name="customContainer">The custom container that the visual element was added in.</param>
        public void DeleteVisualElementCustom(VisualElement visualElement, VisualElement customContainer)
        {
            customContainer.Remove(visualElement);
        }


        /// <summary>
        /// Delete the desired port that are located within the node.
        /// </summary>
        /// <param name="port">The port to be deleted.</param>
        /// <param name="portContainerType">The direction type of the port within the node.</param>
        public void DeletePortElement(Port port, N_PortContainerType portContainerType)
        {
            switch (portContainerType)
            {
                case N_PortContainerType.Output:
                    outputContainer.Remove(port);
                    break;
                case N_PortContainerType.Input:
                    inputContainer.Remove(port);
                    break;
            }

            // Update ports layout to see the changes.
            RefreshPortsLayout();
        }


        // ----------------------------- Node Refresh Services -----------------------------
        /// <summary>
        /// Same function as Node.RefreshExpandedState.
        /// <para>After adding custom elements to the extension container, call this method in order for them to become visible.</para>
        /// </summary>
        public void RefreshExtensionContainer() => RefreshExpandedState();


        /// <summary>
        /// Same function as Node.RefreshPorts.
        /// <para>Refresh the layout of the ports.</para>
        /// </summary>
        public void RefreshPortsLayout() => RefreshPorts();


        /// <summary>
        /// Refresh node's extension container and ports layout at the sametime.
        /// </summary>
        public void NodeRefreshAll()
        {
            RefreshPorts();
            RefreshExpandedState();
        }


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