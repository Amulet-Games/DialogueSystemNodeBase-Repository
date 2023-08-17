using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeObserverFrameBase
    <
        TNode,
        TNodeView
    >
        : NodeObserverBase
        where TNode : NodeFrameBase<TNode, TNodeView>
        where TNodeView : NodeViewFrameBase<TNodeView>
    {
        /// <summary>
        /// Reference of the node element.
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Reference of the node view.
        /// </summary>
        protected TNodeView View;


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the node.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        public virtual void RegisterEvents(TNode node)
        {
            Node = node;
            View = node.View;
        }


        /// <summary>
        /// Register PointerEnterEvent to the node.
        /// </summary>
        protected void RegisterPointerEnterEvent()
            => Node.RegisterCallback<PointerEnterEvent>(PointerEnterEvent);


        /// <summary>
        /// Register PointerLeaveEvent to the node.
        /// </summary>
        protected void RegisterPointerLeaveEvent()
            => Node.RegisterCallback<PointerLeaveEvent>(PointerLeaveEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the pointer has entered the node.
        /// </summary>
        /// <param name="evt">The registering event</param>
        void PointerEnterEvent(PointerEnterEvent evt)
        {
            Node.NodeBorder.AddToClassList(StyleConfig.Node_Border_Hover);
        }


        /// <summary>
        /// The event to invoke when the pointer has left the node.
        /// </summary>
        /// <param name="evt">The registering event</param>
        void PointerLeaveEvent(PointerLeaveEvent evt)
        {
            Node.NodeBorder.RemoveFromClassList(StyleConfig.Node_Border_Hover);
        }
    }
}