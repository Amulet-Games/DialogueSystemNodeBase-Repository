using UnityEngine;
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


        /// <summary>
        /// The last pointer position found within the node. 
        /// </summary>
        Vector2 pointerMovePosition;


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the node.
        /// </summary>
        public abstract void RegisterEvents();


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


        /// <summary>
        /// Register PointerMoveEvent to the node.
        /// </summary>
        protected void RegisterPointerMoveEvent()
            => Node.RegisterCallback<PointerMoveEvent>(PointerMoveEvent);


        /// <summary>
        /// Register GeometryChangedEvent to the node.
        /// </summary>
        protected void RegisterGeometryChangedEvent()
            => Node.RegisterCallback<GeometryChangedEvent>(GeometryChangedEvent);


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
            Node.NodeBorder.AddToClassList(StyleConfig.Instance.Node_Border_Hover);
        }


        /// <summary>
        /// The event to invoke when the pointer has left the node.
        /// </summary>
        /// <param name="evt">The registering event</param>
        void PointerLeaveEvent(PointerLeaveEvent evt)
        {
            Node.NodeBorder.RemoveFromClassList(StyleConfig.Instance.Node_Border_Hover);
        }


        /// <summary>
        /// The event to invoke when the pointer's state has changed. Like position or pressure change, or a different button is pressed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void PointerMoveEvent(PointerMoveEvent evt)
        {
            pointerMovePosition = evt.position;
        }


        /// <summary>
        /// The event to invoke when the node's geometry has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void GeometryChangedEvent(GeometryChangedEvent evt)
        {
            if (!Node.worldBound.Contains(pointerMovePosition))
            {
                // Remove from hover class.
                Node.NodeBorder.RemoveFromClassList(StyleConfig.Instance.Node_Border_Hover);
            }
        }
    }
}