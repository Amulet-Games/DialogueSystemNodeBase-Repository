using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeSerializerFrameBase
    <
        TNode,
        TNodeView,
        TNodeCallback,
        TNodeModel
    > 
        : NodeSerializerBase
        where TNode : NodeFrameBase<TNode, TNodeView, TNodeCallback>
        where TNodeView : NodeViewBase
        where TNodeCallback : NodeCallbackFrameBase<TNode, TNodeView>
        where TNodeModel : NodeModelBase
    {
        /// <summary>
        /// Save the node values to the type node model.
        /// </summary>
        /// <param name="node">The type node element to set for.</param>
        /// <param name="model">The type node model to set for.</param>
        public virtual void Save(TNode node, TNodeModel model)
        {
            // node basic info
            {
                model.GUID = node.NodeGUID;
                model.Position = (SerializableVector2)node.GetPosition().position;
            }

            // node title
            {
                model.TitleText = node.View.NodeTitleTextFieldView.Field.value;
            }
        }


        /// <summary>
        /// Load the node values from the type node model.
        /// </summary>
        /// <param name="node">The type node element to set for.</param>
        /// <param name="model">The type node model to set for.</param>
        public virtual void Load(TNode node, TNodeModel model)
        {
            // node basic info
            {
                node.NodeGUID = model.GUID;
                node.SetPosition(
                    newPos: new Rect(position: (Vector2)model.Position, size: Vector2Utility.Zero)
                );
            }

            // node title
            {
                node.View.NodeTitleTextFieldView.Load(model.TitleText);
            }
        }
    }
}