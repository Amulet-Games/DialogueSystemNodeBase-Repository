using UnityEngine.UIElements;

namespace AG.DS
{
    public class OptionEdgeObserver : EdgeObserverFrameBase<OptionEdge>
    {
        /// <summary>
        /// Reference of the output port that the edge is connecting with.
        /// </summary>
        OptionPort output;


        /// <summary>
        /// Reference of the input port that the edge is connecting with.
        /// </summary>
        OptionPort input;


        // ----------------------------- Setup -----------------------------
        /// <inheritdoc />
        public override EdgeObserverFrameBase<OptionEdge> Setup(OptionEdge edge)
        {
            Edge = edge;
            output = edge.Output;
            input = edge.Input;
            return this;
        }


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents()
        {
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
            if (Edge.output == null && Edge.output.IsShowingConnectStyle())
            {
                output.HideConnectStyle();
            }
            else if (Edge.input == null && Edge.input.IsShowingConnectStyle())
            {
                input.HideConnectStyle();
            }
        }


        /// <summary>
        /// The event to invoke when the user release the mouse button on the edge.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseUpEvent(MouseUpEvent evt)
        {
            /// The edge is going to be destroyed.
            if (Edge.output == null && !Edge.output.IsShowingConnectStyle())
            {
                input.HideConnectStyle();
            }
            /// The edge is forming a new connection to a new output port.
            else if (Edge.output != null && !Edge.output.IsShowingConnectStyle())
            {
                output = Edge.Output;

                output.HideOpponentConnectStyle();

                Edge.ShowConnectStyle();
            }
            /// The edge is going to be destroyed.
            else if (Edge.input == null && !Edge.input.IsShowingConnectStyle())
            {
                output.HideConnectStyle();
            }
            /// The edge is forming a new connection to a new input port.
            else if (Edge.input != null && !Edge.input.IsShowingConnectStyle())
            {
                input = Edge.Input;

                input.HideOpponentConnectStyle();
                
                Edge.ShowConnectStyle();
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