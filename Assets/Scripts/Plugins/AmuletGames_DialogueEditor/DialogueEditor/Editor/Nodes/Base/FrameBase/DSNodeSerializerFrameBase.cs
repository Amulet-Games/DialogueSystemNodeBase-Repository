using UnityEngine;

namespace AG
{
    /// <summary>
    /// Dialogue system node serializer's frame base class.
    /// </summary>
    /// <typeparam name="TNode">Node type</typeparam>
    /// <typeparam name="TNodeModel">Node model type</typeparam>
    public abstract class DSNodeSerializerFrameBase<TNode, TNodeModel> 
        : DSNodeSerializerBase
        where TNode : DSNodeBase
        where TNodeModel : DSNodeModelBase
    {
        /// <summary>
        /// Responsible for communicating with the other module classes,
        /// <br>and creating the frame base when it's first initialized.</br>
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Holds all the components and data that'll be used on the connecting node,
        /// <br>and allows other framework classes to utilize them for different purposes.</br>.
        /// </summary>
        protected TNodeModel Model;


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Method for loading the previous saved node model's values to the current
        /// <br>connecting node model.</br>
        /// </summary>
        /// <param name="source">The source node's model to load the values from.</param>
        public abstract void LoadNode(TNodeModel source);


        // ----------------------------- Serialize Base Values Services -----------------------------
        /// <summary>
        /// Method for saving the node's base values.
        /// </summary>
        /// <param name="target">The target node's model to save the values to.</param>
        protected void SaveBaseValues(TNodeModel target)
        {
            SaveNodeDetails();

            SaveNodeTitleField();

            void SaveNodeDetails()
            {
                target.SavedNodeGuid = Node.NodeGuid;
                target.SavedNodePosition = Node.GetPosition().position;
            }

            void SaveNodeTitleField()
            {
                target.NodeTitle_TextContainer.SaveContainerValue(Model.NodeTitle_TextContainer);
            }
        }


        /// <summary>
        /// Method for loading the node's base values.
        /// </summary>
        /// <param name="source">The source node's model to load the values from.</param>
        protected void LoadBaseValues(TNodeModel source)
        {
            LoadNodeDetails();

            LoadNodeTitleField();

            void LoadNodeDetails()
            {
                Node.NodeGuid = source.SavedNodeGuid;
                Node.SetPosition(new Rect(source.SavedNodePosition, DSVector2Utility.Zero));
            }

            void LoadNodeTitleField()
            {
                Model.NodeTitle_TextContainer.LoadContainerValue(source.NodeTitle_TextContainer);
            }
        }
    }
}