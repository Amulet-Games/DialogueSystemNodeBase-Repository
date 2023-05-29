using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodeCallback : NodeCallbackFrameBase
    <
        StartNode,
        StartNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node callback class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public StartNodeCallback
        (
            StartNode node,
            StartNodeModel model
        )
        {
            Node = node;
            Model = model;
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
            => new NodeTitleTextFieldCallback(
                model: Model.NodeTitleTextFieldModel,
                widthBuffer: NodeConfig.StartNodeWidthBuffer).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node title edit button.
        /// </summary>
        void RegisterNodeTitleEditButtonClickEvent()
            => new CommonButtonCallback(
                isAlert: false,
                button: Model.EditTitleButton,
                clickEvent: NodeTitleEditButtonClickEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the node title edit button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void NodeTitleEditButtonClickEvent(ClickEvent evt)
        {
            var titleTextField = Model.NodeTitleTextFieldModel.TextField;
            titleTextField.focusable = true;
            titleTextField.Focus();
        }
    }
}