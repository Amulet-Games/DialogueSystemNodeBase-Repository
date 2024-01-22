using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ReflectableObjectFieldObserver<TObject>
        where TObject : Object
    {
        /// <summary>
        /// The targeting reflectable object field view;
        /// </summary>
        ReflectableObjectFieldView<TObject> view;


        /// <summary>
        /// Constructor of the reflectable object field observer class.
        /// </summary>
        /// <param name="view">The reflectable object field view to set for.</param>
        public ReflectableObjectFieldObserver
        (
            ReflectableObjectFieldView<TObject> view
        )
        {
            this.view = view;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the common object field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterChangeEvent();

            RegisterMouseDownEvent();
        }


        /// <summary>
        /// Register ChangeEvent to the field.
        /// </summary>
        void RegisterChangeEvent() => view.Field.RegisterValueChangedCallback(ChangeEvent);


        /// <summary>
        /// Register MouseDownEvent to the field.
        /// </summary>
        void RegisterMouseDownEvent() =>
            view.Field.RegisterCallback<MouseDownEvent>(MouseDownEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ChangeEvent(ChangeEvent<Object> evt)
        {
            var field = view.Field;

            // Unbind the previous value.
            field.Unbind();

            // Push the current container's value to the undo stack.
            //TestingWindow.Instance.PushUndo(
            //    reversible: objectContainer,
            //    dataReversedAction: containerValueChangedAction
            //);

            view.Value = evt.newValue
                ? evt.newValue as TObject
                : null;

            WindowChangedEvent.Invoke();
        }


        /// <summary>
        /// The event to invoke when the mouse button is pressed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseDownEvent(MouseDownEvent evt)
        {
            // Prevent moving the parent node when using the field.
            evt.StopImmediatePropagation();
        }
    }
}