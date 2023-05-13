using UnityEngine.UIElements;

namespace AG.DS
{
    public class DefaultEdgeCallback : EdgeCallbackFrameBase<DefaultEdge>
    {
        // ----------------------------- Setup -----------------------------
        /// <inheritdoc />
        public override void Setup(DefaultEdge edge)
        {
            Edge = edge;
        }


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents()
        {
            RegisterFocusEvent();

            RegisterBlurEvent();
        }


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
        /// The event to invoke when the edge has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusEvent(FocusEvent evt)
        {
            Edge.AddToClassList(StyleConfig.Instance.Edge_Selected);
        }


        /// <summary>
        /// The event to invoke when the edge has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void BlurEvent(BlurEvent evt)
        {
            Edge.RemoveFromClassList(StyleConfig.Instance.Edge_Selected);
        }
    }
}