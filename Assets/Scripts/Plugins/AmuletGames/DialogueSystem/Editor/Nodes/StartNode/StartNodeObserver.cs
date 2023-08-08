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
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node observer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public StartNodeObserver
        (
            StartNode node,
            StartNodeView view
        )
        {
            Node = node;
            View = view;
        }


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents()
        {
            base.RegisterEvents();

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