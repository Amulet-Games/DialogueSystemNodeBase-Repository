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
        where TNode : NodeFrameBase<TNode, TNodeView>
        where TNodeView : NodeViewFrameBase<TNodeView>
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


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save the node element values.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public virtual void Save(TNode node, TNodeModel model)
        {
            Node = node;
            View = node.View;
            Model = model;
        }


        /// <summary>
        /// Save the node base values.
        /// </summary>
        protected void SaveNodeBaseValues()
        {
            Model.Guid = Node.Guid;
            Model.Position = (SerializableVector2)Node.GetPosition().position;
        }


        /// <summary>
        /// Save the node title.
        /// </summary>
        protected void SaveNodeTitle()
        {
            Model.TitleText = View.NodeTitleFieldView.Field.value;
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load the node element values.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public virtual void Load(TNode node, TNodeModel model)
        {
            Node = node;
            View = node.View;
            Model = model;
        }


        /// <summary>
        /// Load the node base values.
        /// </summary>
        protected void LoadNodeBaseValues()
        {
            Node.Guid = Model.Guid;
            Node.SetPosition(
                newPos: new Rect(position: (Vector2)Model.Position, size: Vector2Utility.Zero)
            );
        }


        /// <summary>
        /// Load the node title.
        /// </summary>
        protected void LoadNodeTitle()
        {
            View.NodeTitleFieldView.Load(Model.TitleText);
        }
    }
}