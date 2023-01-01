using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeSerializerFrameBase
    <
        TNode,
        TNodeModel,
        TNodeData
    > 
        : NodeSerializerBase
        where TNode : NodeBase
        where TNodeModel : NodeModelBase
        where TNodeData : NodeDataBase
    {
        /// <summary>
        /// Responsible for communicating with the other module classes,
        /// <br>and creating the frame base when it's first initialized.</br>
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Holds all the components that'll be used on the connecting node,
        /// <br>and allows other framework classes to utilize them for different purposes.</br>.
        /// </summary>
        protected TNodeModel Model;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the node values to its connecting data module class.
        /// </summary>
        /// <param name="dsData">The given dialogue system data to save to.</param>
        public abstract void SaveNode(DialogueSystemData dsData);


        /// <summary>
        /// Load the node values from the given connecting data module class.
        /// </summary>
        /// <param name="data">The given connecting data module class to load from.</param>
        public abstract void LoadNode(TNodeData data);


        // ----------------------------- Serialize Base Values Services -----------------------------
        /// <summary>
        /// Method for saving the node's base values.
        /// </summary>
        /// <param name="data">The given connecting data module class to save to.</param>
        protected void SaveBaseValues(TNodeData data)
        {
            SaveNodeDetails();

            SaveNodeTitleField();

            void SaveNodeDetails()
            {
                data.NodeGUID = Node.NodeGUID;
                data.NodePosition = (SerializableVector2)Node.GetPosition().position;
            }

            void SaveNodeTitleField()
            {
                data.NodeTitleText = Model.NodeTitleTextContainer.Value;
            }
        }


        /// <summary>
        /// Method for loading the node's base values.
        /// </summary>
        /// <param name="data">The given connecting data module class to load from.</param>
        protected void LoadBaseValues(TNodeData data)
        {
            LoadNodeDetails();

            LoadNodeTitleField();

            void LoadNodeDetails()
            {
                Node.NodeGUID = data.NodeGUID;
                Node.SetPosition
                (
                    newPos: new Rect(
                                    position: (Vector2)data.NodePosition,
                                    size: Vector2Utility.Zero
                                    )
                );
            }

            void LoadNodeTitleField()
            {
                Model.NodeTitleTextContainer.LoadContainerValue(data.NodeTitleText);
            }
        }
    }
}