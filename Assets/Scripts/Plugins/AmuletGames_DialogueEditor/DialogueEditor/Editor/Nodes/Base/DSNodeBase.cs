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
        /// The callback action to invoke when the node is fully initialized but hasn't been
        /// <br>created on the graph yet.</br>
        /// </summary>
        protected abstract void InitializedAction();


        /// <summary>
        /// The callback action to invoke when the node is added on the graph by users manually.
        /// <br>(by contextual menu or search window).</br>
        /// <para></para>
        /// This action happens after InitalizedAction is called.
        /// </summary>
        protected abstract void ManualCreatedAction();


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


        // ----------------------------- Element Deletion Services -----------------------------
        /// <summary>
        /// Delete the desired visual element that are created within the node.
        /// </summary>
        /// <param name="visualElement">The visual element to be deleted.</param>
        /// <param name="containerType">The container that the visual element was added in.</param>
        public void DeleteVisualElement(VisualElement visualElement, N_ContainerType containerType)
        {
            switch (containerType)
            {
                case N_ContainerType.Extension:
                    extensionContainer.Remove(visualElement);
                    RefreshExpandedState();
                    break;
                case N_ContainerType.Top:
                    topContainer.Remove(visualElement);
                    break;
                case N_ContainerType.TitleButton:
                    titleButtonContainer.Remove(visualElement);
                    break;
                case N_ContainerType.Title:
                    titleContainer.Remove(visualElement);
                    break;
                case N_ContainerType.Main:
                    mainContainer.Remove(visualElement);
                    break;
            }
        }


        /// <summary>
        /// Delete the desired port that are located within the node.
        /// </summary>
        /// <param name="port">The port to be deleted.</param>
        /// <param name="directionType">The direction type of the port within the node.</param>
        public void DeletePortElement(Port port, Direction directionType)
        {
            switch (directionType)
            {
                case Direction.Output:
                    outputContainer.Remove(port);
                    break;

                case Direction.Input:
                    inputContainer.Remove(port);
                    break;
            }

            // Update ports layout to see the changes.
            RefreshPorts();
        }
    }
}