using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeCallback : NodeCallbackFrameBase
    <
        DialogueNode,
        DialogueNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node callback class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public DialogueNodeCallback
        (
            DialogueNode node,
            DialogueNodeModel model
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
        }
    }
}