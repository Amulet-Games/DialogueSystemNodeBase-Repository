using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeObserver : NodeObserverFrameBase
    <
        StartNode,
        StartNodeView
    >
    {
        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(StartNode node, StartNodeView view)
        {
            base.RegisterEvents(node, view);

            RegisterNodeTitleTextFieldEvents();

            RegisterNodeTitleEditButtonClickEvent();
        }


        /// <summary>
        /// Register events to the node title text field.
        /// </summary>
        void RegisterNodeTitleTextFieldEvents()
            => new NodeTitleTextFieldObserver(
                view: View.NodeTitleTextFieldView).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node title edit button.
        /// </summary>
        void RegisterNodeTitleEditButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: false,
                button: View.EditTitleButton,
                clickEvent: NodeTitleEditButtonClickEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the node title edit button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void NodeTitleEditButtonClickEvent(ClickEvent evt)
        {
            var fieldInput = View.NodeTitleTextFieldView.Field.GetFieldInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }
    }
}