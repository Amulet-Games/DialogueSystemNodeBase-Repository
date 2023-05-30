using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeCallback : NodeCallbackFrameBase
    <
        OptionRootNode,
        OptionRootNodeModel
    >
    {
        /// <summary>
        /// The last pointer position found within the node. 
        /// </summary>
        Vector2 pointerMovePosition;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node callback class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public OptionRootNodeCallback
        (
            OptionRootNode node,
            OptionRootNodeModel model
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

            RegisterPointerMoveEvent();

            RegisterGeometryChangedEvent();

            RegisterLanguageChangedEvent();

            RegisterNodeTitleTextFieldEvents();

            RegisterNodeTitleEditButtonClickEvent();

            RegisterContentButtonClickEvent();

            RegisterRootTitleTextFieldEvents();
        }


        /// <summary>
        /// Register PointerMoveEvent to the node.
        /// </summary>
        void RegisterPointerMoveEvent()
            => Node.RegisterCallback<PointerMoveEvent>(PointerMoveEvent);


        /// <summary>
        /// Register GeometryChangedEvent to the node.
        /// </summary>
        void RegisterGeometryChangedEvent()
            => Node.RegisterCallback<GeometryChangedEvent>(GeometryChangedEvent);


        /// <summary>
        /// Register LanguageChangedEvent to the node.
        /// </summary>
        void RegisterLanguageChangedEvent()
            => LanguageChangedEvent.Register(m_LanguageChangedEvent);


        /// <summary>
        /// Register events to the node title text field.
        /// </summary>
        void RegisterNodeTitleTextFieldEvents()
            => new NodeTitleTextFieldCallback(
                model: Model.NodeTitleTextFieldModel,
                widthBuffer: NodeConfig.OptionRootNodeWidthBuffer).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node title edit button.
        /// </summary>
        void RegisterNodeTitleEditButtonClickEvent()
            => new CommonButtonCallback(
                isAlert: false,
                button: Model.EditTitleButton,
                clickEvent: NodeTitleEditButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node content button.
        /// </summary>
        void RegisterContentButtonClickEvent()
            => new ContentButtonCallback(
                isAlert: true,
                contentButton: Model.ContentButton,
                clickEvent: ContentButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register events to the root title text field.
        /// </summary>
        void RegisterRootTitleTextFieldEvents()
            => new LanguageTextFieldCallback(
                model: Model.RootTitleTextFieldModel).RegisterEvents();


        // ----------------------------- UnRegister Events -----------------------------
        /// <inheritdoc />
        public override void UnregisterEvents()
        {
            UnregisterLanguageChangedEvent();
        }


        /// <summary>
        /// Unregister LanguageChangedEvent from the node.
        /// </summary>
        void UnregisterLanguageChangedEvent()
            => LanguageChangedEvent.UnRegister(m_LanguageChangedEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the pointer's state has changed.
        /// <br>Like position or pressure change, or a different button is pressed.</br>
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
                Node.NodeBorder.RemoveFromClassList(StyleConfig.Node_Border_Hover);
            }
        }


        /// <summary>
        /// The event to invoke when the editor window's selected language has changed.
        /// </summary>
        void m_LanguageChangedEvent()
        {
            Model.RootTitleTextFieldModel.UpdateLanguageField();
        }


        /// <summary>
        /// The event to invoke when the node title edit button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void NodeTitleEditButtonClickEvent(ClickEvent evt)
        {
            var fieldInput = Model.NodeTitleTextFieldModel.TextField.GetElementInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }


        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ContentButtonClickEvent(ClickEvent evt)
        {
            // Release the focus of the node's border.
            Node.NodeBorder.Blur();

            // Create a new output option port cell.
            Model.OutputOptionPortGroupModel.AddCell(Node);

            // Update ports layout.
            Node.RefreshPorts();
        }
    }
}