using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeCallback : NodeCallbackFrameBase
    <
        EventNode,
        EventNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node callback module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public EventNodeCallback
        (
            EventNode node,
            EventNodeModel model
        )
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents()
        {
            RegisterPointerEnterEvent();

            RegisterPointerLeaveEvent();

            RegisterPointerMoveEvent();

            RegisterGeometryChangedEvent();
        }


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        /// <param name="evt">The registering event</param>
        public void ContentButtonClickEvent(ClickEvent evt)
        {
            Model.EventModifierModelGroupModel.CreateModifier();
        }
    }
}