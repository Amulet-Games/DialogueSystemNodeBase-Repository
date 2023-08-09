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
        : NodeSerializerBase, INodeSerializer
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


        /// <summary>
        /// Reference of the node model.
        /// </summary>
        protected TNodeModel Model;


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the node values to the dialogue system model.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        public virtual void Save(DialogueSystemModel dsModel)
        {
            // node basic info
            {
                Model.GUID = Node.NodeGUID;
                Model.Position = (SerializableVector2)Node.GetPosition().position;
            }

            // node title
            {
                Model.TitleText = View.NodeTitleTextFieldView.Field.value;
            }
        }


        /// <summary>
        /// Load the node values from the node model.
        /// </summary>
        /// <param name="model">The type node model to set for.</param>
        public virtual void Load()
        {
            // node basic info
            {
                Node.NodeGUID = Model.GUID;
                Node.SetPosition(
                    newPos: new Rect(position: (Vector2)Model.Position, size: Vector2Utility.Zero)
                );
            }

            // node title
            {
                View.NodeTitleTextFieldView.Load(Model.TitleText);
            }
        }
    }
}