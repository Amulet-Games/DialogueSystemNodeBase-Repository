using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class NodeBase : Node
    {
        /// <summary>
        /// Reference of the graph viewer module in the dialogue system.
        /// </summary>
        public GraphViewer GraphViewer;


        /// <summary>
        /// The special GUID of this node.
        /// </summary>
        public string NodeGUID;


        /// <summary>
        /// Reference of the node's border visual element.
        /// </summary>
        public VisualElement NodeBorder;


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// The callback action to invoke when the user start adding the node to the graph manually
        /// <br>(by contextual menu or search window).</br>
        /// <para></para>
        /// This action happens after InitalizedAction is called.
        /// </summary>
        protected abstract void ManualCreatedAction();


        /// <summary>
        /// The callback action to invoke when the previous saved data is loaded and adding the node
        /// <br>to the graph (by serialize handler).</br>
        /// </summary>
        protected abstract void LoadCreatedAction();


        /// <summary>
        /// The callback action to invoke when the node has finished its creation process and added on the graph fully.
        /// </summary>
        protected abstract void PostCreatedAction();


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


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the node values to its connecting data module class.
        /// </summary>
        /// <param name="dsData">The given dialogue system data to save to.</param>
        public abstract void SaveNode(DialogueSystemData dsData);


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