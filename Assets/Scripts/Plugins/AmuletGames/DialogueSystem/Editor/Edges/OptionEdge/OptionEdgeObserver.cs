using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeObserver : EdgeObserverFrameBase<OptionEdge>
    {
        /// <summary>
        /// Reference of the option edge view.
        /// </summary>
        OptionEdgeView view;


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(OptionEdge edge)
        {
            Edge = edge;
            view = edge.View;

            RegisterMouseMoveEvent();

            RegisterMouseUpEvent();

            RegisterFocusEvent();

            RegisterBlurEvent();
        }


        /// <summary>
        /// Register MouseMoveEvent to the edge.
        /// </summary>
        void RegisterMouseMoveEvent() => Edge.RegisterCallback<MouseMoveEvent>(MouseMoveEvent);


        /// <summary>
        /// Register MouseUpEvent to the edge.
        /// </summary>
        void RegisterMouseUpEvent() => Edge.RegisterCallback<MouseUpEvent>(MouseUpEvent);


        /// <summary>
        /// Register FocusEvent to the edge.
        /// </summary>
        void RegisterFocusEvent() => Edge.RegisterCallback<FocusEvent>(FocusEvent);


        /// <summary>
        /// Register BlurEvent to the edge.
        /// </summary>
        void RegisterBlurEvent() => Edge.RegisterCallback<BlurEvent>(BlurEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the user is dragging and moving the edge.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseMoveEvent(MouseMoveEvent evt)
        {
            if (Edge.output == null && view.Output != null)
            {
                view.Output.HideConnectStyle();
                view.Output = null;
            }
            else if (Edge.input == null && view.Input != null)
            {
                view.Input.HideConnectStyle();
                view.Input = null;
            }
        }


        /// <summary>
        /// The event to invoke when the user release the mouse button on the edge.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseUpEvent(MouseUpEvent evt)
        {
            if (view.Output == null)
            {
                view.Input.HideConnectStyle();
            }
            else if (view.Input == null)
            {
                view.Output.HideConnectStyle();
            }
        }


        /// <summary>
        /// The event to invoke when the edge has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusEvent(FocusEvent evt)
        {
            Edge.AddToClassList(StyleConfig.Edge_Selected);
        }


        /// <summary>
        /// The event to invoke when the edge has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void BlurEvent(BlurEvent evt)
        {
            Edge.RemoveFromClassList(StyleConfig.Edge_Selected);
        }
    }
}