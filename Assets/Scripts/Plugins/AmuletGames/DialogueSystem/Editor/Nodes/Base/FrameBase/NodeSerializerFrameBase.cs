using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeSerializerFrameBase
    <
        TNode,
        TNodeView,
        TNodeData
    > 
        : NodeSerializerBase
        where TNode : NodeFrameBase<TNode, TNodeView>
        where TNodeView : NodeViewFrameBase<TNodeView>
        where TNodeData : NodeDataBase
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
        /// Reference of the node data.
        /// </summary>
        protected TNodeData Data;


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Save the node element values.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="data">The node data to set for.</param>
        public virtual void Save(TNode node, TNodeData data)
        {
            Node = node;
            View = node.View;
            Data = data;
        }


        /// <summary>
        /// Save the node base values.
        /// </summary>
        protected void SaveNodeBaseValues()
        {
            Data.Guid = Node.Guid;
            Data.Position = (SerializableVector2)Node.GetPosition().position;
        }


        /// <summary>
        /// Save the node title.
        /// </summary>
        protected void SaveNodeTitle()
        {
            Data.TitleText = View.NodeTitleFieldView.Field.value;
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Load the node element values.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="data">The node data to set for.</param>
        public virtual void Load(TNode node, TNodeData data)
        {
            Node = node;
            View = node.View;
            Data = data;
        }


        /// <summary>
        /// Load the node base values.
        /// </summary>
        protected void LoadNodeBaseValues()
        {
            Node.Guid = Data.Guid;
            Node.SetPosition(
                newPos: new Rect(position: (Vector2)Data.Position, size: Vector2Utility.Zero)
            );
        }


        /// <summary>
        /// Load the node title.
        /// </summary>
        protected void LoadNodeTitle()
        {
            View.NodeTitleFieldView.Load(Data.TitleText);
        }
    }
}