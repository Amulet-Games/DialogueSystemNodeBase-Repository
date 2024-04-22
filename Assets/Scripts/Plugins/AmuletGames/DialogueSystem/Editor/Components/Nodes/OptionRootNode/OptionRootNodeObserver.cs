using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionRootNodeObserver : NodeObserverFrameBase
    <
        OptionRootNode,
        OptionRootNodeView
    >
    {
        /// <summary>
        /// The last pointer position found within the node. 
        /// </summary>
        Vector2 pointerMovePosition;


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(OptionRootNode node)
        {
            base.RegisterEvents(node);

            RegisterPointerEnterEvent();

            RegisterPointerLeaveEvent();

            RegisterPointerMoveEvent();

            RegisterGeometryChangedEvent();

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
        /// Register ClickEvent to the content button.
        /// </summary>
        void RegisterContentButtonClickEvent()
            => new ContentButtonObserver(
                view: View.ContentButtonView,
                clickEvent: ContentButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register events to the root title text field.
        /// </summary>
        void RegisterRootTitleTextFieldEvents()
            => new LanguageTextFieldObserver(
                view: View.RootTitleFieldView).RegisterEvents();


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
        /// <param name="evt">The registering event.</param>
        void NodeTitleEditButtonClickEvent()
        {
            var fieldInput = View.NodeTitleFieldView.Field.GetFieldInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }


        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        void ContentButtonClickEvent()
        {
            // Release the focus of the node's border.
            Node.NodeBorder.Blur();

            // Create a new output option port group item.
            {
                var group = View.OutputOptionPortGroup;

                var itemModel = new OptionPortGroupItemModel(group);
                var item = OptionPortGroupItemFactory.Generate(itemModel);

                group.Add(item);
            }
        }
    }
}