using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeObserver : NodeObserverFrameBase
    <
        BooleanNode,
        BooleanNodeView
    >
    {
        /// <summary>
        /// The last pointer position found within the node. 
        /// </summary>
        Vector2 pointerMovePosition;


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(BooleanNode node)
        {
            base.RegisterEvents(node);

            RegisterPointerEnterEvent();

            RegisterPointerLeaveEvent();

            RegisterPointerMoveEvent();

            RegisterGeometryChangedEvent();

            RegisterNodeTitleTextFieldEvents();

            RegisterNodeTitleEditButtonClickEvent();

            RegisterContentButtonClickEvent();
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
        /// Register events to the node title text field.
        /// </summary>
        void RegisterNodeTitleTextFieldEvents()
            => new NodeTitleTextFieldObserver(
                view: View.NodeTitleFieldView).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node title edit button.
        /// </summary>
        void RegisterNodeTitleEditButtonClickEvent()
            => new ButtonObserver(
                isAlert: false,
                button: View.EditTitleButton,
                clickEvent: NodeTitleEditButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node content button view's button.
        /// </summary>
        void RegisterContentButtonClickEvent()
            => new ContentButtonViewObserver(
                view: View.m_ContentButtonView,
                clickEvent: ContentButtonViewClickEvent).RegisterEvents();


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the pointer's state has changed.
        /// Like position or pressure change, or a different button is pressed.
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
                Node.NodeBorder.RemoveFromClassList(StyleConfig.Pseudo_Hover);
            }
        }


        /// <summary>
        /// The event to invoke when the node title edit button is clicked.
        /// </summary>
        void NodeTitleEditButtonClickEvent()
        {
            var fieldInput = View.NodeTitleFieldView.Field.GetFieldInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }


        /// <summary>
        /// The event to invoke when the content button view's button is clicked.
        /// </summary>
        void ContentButtonViewClickEvent()
        {
            var groupView = View.ConditionModifierViewGroupView;
            var modifier = ConditionModifierViewFactory.Generate(groupView, Node.GraphViewer);

            // Add to group
            {
                groupView.Add(modifier);
                groupView.UpdateModifiersReferences();
            }
        }
    }
}