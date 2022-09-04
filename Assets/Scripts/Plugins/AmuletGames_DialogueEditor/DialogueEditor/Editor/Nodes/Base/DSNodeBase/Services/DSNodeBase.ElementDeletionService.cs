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
    }
}