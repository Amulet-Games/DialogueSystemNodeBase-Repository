using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public abstract class NodeCallbackFrameBase
    <
        TNode,
        TNodeModel
    >
        : NodeCallbackBase
        where TNode : NodeBase
        where TNodeModel : NodeModelBase
    {
        /// <summary>
        /// Reference of the node element.
        /// </summary>
        protected TNode Node;


        /// <summary>
        /// Reference of the node model.
        /// </summary>
        protected TNodeModel Model;


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the node.
        /// </summary>
        public virtual void RegisterEvents()
        {
            RegisterPointerEnterEvent();

            RegisterPointerLeaveEvent();
        }


        /// <summary>
        /// Register PointerEnterEvent to the node.
        /// </summary>
        void RegisterPointerEnterEvent()
            => Node.RegisterCallback<PointerEnterEvent>(PointerEnterEvent);


        /// <summary>
        /// Register PointerLeaveEvent to the node.
        /// </summary>
        void RegisterPointerLeaveEvent()
            => Node.RegisterCallback<PointerLeaveEvent>(PointerLeaveEvent);


        // ----------------------------- UnRegister Events -----------------------------
        /// <summary>
        /// Unregister events from the node.
        /// </summary>
        public virtual void UnregisterEvents() { }


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