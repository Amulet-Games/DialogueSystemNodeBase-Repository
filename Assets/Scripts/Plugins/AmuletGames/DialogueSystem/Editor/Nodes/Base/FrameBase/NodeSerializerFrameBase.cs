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
        /// Reference of the node element.
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Reference of the node model.
        /// </summary>
        protected TNodeModel Model;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the node values to the given data.
        /// </summary>
        /// <param name="dsData">The data to save to.</param>
        public abstract void Save(DialogueSystemData dsData);


        /// <summary>
        /// Load the node values from the given data.
        /// </summary>
        /// <param name="data">The data to load from.</param>
        public abstract void Load(TNodeData data);


        // ----------------------------- Save / Load Base Values -----------------------------
        /// <summary>
        /// Method for saving the node's base values.
        /// </summary>
        /// <param name="data">The type node data to save to.</param>
        protected void SaveBaseValues(TNodeData data)
        {
            SaveNodeDetails();

            SaveNodeTitleField();

            void SaveNodeDetails()
            {
                data.GUID = Node.NodeGUID;
                data.Position = (SerializableVector2)Node.GetPosition().position;
            }

            void SaveNodeTitleField()
            {
                data.TitleText = Model.NodeTitleTextFieldModel.TextField.value;
            }
        }


        /// <summary>
        /// Method for loading the node's base values.
        /// </summary>
        /// <param name="data">The type node data to load from.</param>
        protected void LoadBaseValues(TNodeData data)
        {
            LoadNodeDetails();

            LoadNodeTitleField();

            void LoadNodeDetails()
            {
                Node.NodeGUID = data.GUID;
                Node.SetPosition
                (
                    newPos: new Rect(
                                    position: (Vector2)data.Position,
                                    size: Vector2Utility.Zero
                                    )
                );
            }

            void LoadNodeTitleField()
            {
                Model.NodeTitleTextFieldModel.Load(data.TitleText);
            }
        }
    }
}