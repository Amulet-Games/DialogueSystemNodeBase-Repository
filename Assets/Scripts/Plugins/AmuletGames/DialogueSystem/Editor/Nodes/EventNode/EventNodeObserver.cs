using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeObserver : NodeObserverFrameBase
    <
        EventNode,
        EventNodeView
    >
    {
        /// <summary>
        /// The last pointer position found within the node. 
        /// </summary>
        Vector2 pointerMovePosition;


        // ----------------------------- Register Events -----------------------------
        /// <inheritdoc />
        public override void RegisterEvents(EventNode node, EventNodeView view)
        {
            base.RegisterEvents(node, view);

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
                view: View.NodeTitleTextFieldView).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node title edit button.
        /// </summary>
        void RegisterNodeTitleEditButtonClickEvent()
            => new CommonButtonObserver(
                isAlert: false,
                button: View.EditTitleButton,
                clickEvent: NodeTitleEditButtonClickEvent).RegisterEvents();


        /// <summary>
        /// Register ClickEvent to the node content button.
        /// </summary>
        void RegisterContentButtonClickEvent()
            => new ContentButtonObserver(
                isAlert: true,
                contentButton: View.ContentButton,
                clickEvent: ContentButtonClickEvent).RegisterEvents();


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
        /// The event to invoke when the node title edit button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void NodeTitleEditButtonClickEvent(ClickEvent evt)
        {
            var fieldInput = View.NodeTitleTextFieldView.Field.GetFieldInput();
            fieldInput.focusable = true;
            fieldInput.Focus();
        }


        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        void ContentButtonClickEvent()
        {
            var groupView = View.EventModifierGroupView;
            var modifier = new EventModifierSeeder().Generate(groupView);

            // Add to group
            {
                groupView.Add(modifier);
                groupView.UpdateReferences();
            }
            
            // Edit folder name
            {
                var folder = modifier.Folder;
                folder.SetExpanded(value: true);
                folder.StartEditingFolderTitle();
            }
        }
    }
}