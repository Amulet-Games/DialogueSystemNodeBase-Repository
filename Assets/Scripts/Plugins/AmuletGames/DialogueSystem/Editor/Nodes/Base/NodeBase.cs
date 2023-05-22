using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public abstract class NodeBase : Node
    {
        /// <summary>
        /// Reference of the graph viewer element.
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


        /// <summary>
        /// The element that contains other visual elements within the node content section.
        /// </summary>
        public VisualElement ContentContainer;


        // ----------------------------- Action -----------------------------
        /// <summary>
        /// Action to invoke when the node is created and added to the graph.
        /// </summary>
        public abstract void CreatedAction();


        /// <summary>
        /// Action to invoke just before the node is going to be removed from the graph manually.
        /// </summary>
        public abstract void PreManualRemoveAction();


        /// <summary>
        /// Action to invoke right after the node has been removed from the graph manually.
        /// </summary>
        public virtual void PostManualRemoveAction() { }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the node values to the dialogue system data.
        /// </summary>
        /// <param name="dsData">The dialogue system data to save to.</param>
        public abstract void Save(DialogueSystemData dsData);


        // ----------------------------- Add -----------------------------
        /// <summary>
        /// Add the given port to the node.
        /// </summary>
        /// <param name="port">The targeting port.</param>
        /// <param name="isRefresh">Is refreshing the node's port container afterward.</param>
        public void Add(PortBase port, bool isRefresh = false)
        {
            if (port.direction == Direction.Input)
            {
                inputContainer.Add(port);
            }
            else
            {
                outputContainer.Add(port);
            }

            if (isRefresh)
                RefreshPorts();

            GraphViewer.Add(port);
        }


        // ----------------------------- Remove -----------------------------
        /// <summary>
        /// Remove the given port from the node.
        /// </summary>
        /// <param name="port">The targeting port.</param>
        public void Remove(PortBase port)
        {
            if (port.direction == Direction.Input)
            {
                inputContainer.Remove(port);
            }
            else
            {
                outputContainer.Remove(port);
            }

            RefreshPorts();
            GraphViewer.Remove(port);
        }
    }
}