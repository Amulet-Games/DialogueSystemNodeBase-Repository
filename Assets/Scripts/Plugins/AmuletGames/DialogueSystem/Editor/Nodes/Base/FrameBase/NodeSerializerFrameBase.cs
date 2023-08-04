using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeSerializerFrameBase
    <
        TNode,
        TNodeView,
        TNodeModel
    > 
        : NodeSerializerBase
        where TNode : NodeBase
        where TNodeView : NodeViewBase
        where TNodeModel : NodeModelBase
    {
        /// <summary>
        /// Reference of the node element.
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Reference of the node view.
        /// </summary>
        protected TNodeView View;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the node values to the dialogue system model.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        public abstract void Save(DialogueSystemModel dsModel);


        /// <summary>
        /// Load the node values from the node model.
        /// </summary>
        /// <param name="model">The type node model to set for.</param>
        public abstract void Load(TNodeModel model);


        // ----------------------------- Save / Load Base Values -----------------------------
        /// <summary>
        /// Save the node base values.
        /// </summary>
        /// <param name="model">The type node model to set for.</param>
        protected void SaveBaseValues(TNodeModel model)
        {
            SaveNodeDetails();

            SaveNodeTitleField();

            void SaveNodeDetails()
            {
                model.GUID = Node.NodeGUID;
                model.Position = (SerializableVector2)Node.GetPosition().position;
            }

            void SaveNodeTitleField()
            {
                model.TitleText = View.NodeTitleTextFieldView.Field.value;
            }
        }


        /// <summary>
        /// Load the node base values.
        /// </summary>
        /// <param name="model">The type node model to set for.</param>
        protected void LoadBaseValues(TNodeModel model)
        {
            LoadNodeDetails();

            LoadNodeTitleField();

            void LoadNodeDetails()
            {
                Node.NodeGUID = model.GUID;
                Node.SetPosition
                (
                    newPos: new Rect(
                        position: (Vector2)model.Position,
                        size: Vector2Utility.Zero
                    )
                );
            }

            void LoadNodeTitleField()
            {
                View.NodeTitleTextFieldView.Load(model.TitleText);
            }
        }
    }
}