using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionEdgeObserver : EdgeObserverFrameBase<Edge<OptionPort, OptionPortModel, OptionEdgeView>>
    {
        /// <summary>
        /// Reference of the option edge view.
        /// </summary>
        OptionEdgeView view;


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(Edge<OptionPort, OptionPortModel, OptionEdgeView> edge)
        {
            Edge = edge;
            view = edge.View;

            RegisterMouseMoveEvent();
        }


        /// <summary>
        /// Register MouseMoveEvent to the edge.
        /// </summary>
        void RegisterMouseMoveEvent() => Edge.RegisterCallback<MouseMoveEvent>(MouseMoveEvent);


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
    }
}