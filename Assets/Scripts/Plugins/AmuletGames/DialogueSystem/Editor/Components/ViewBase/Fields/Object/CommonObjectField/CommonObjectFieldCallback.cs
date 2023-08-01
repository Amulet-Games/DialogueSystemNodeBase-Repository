using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonObjectFieldCallback<TObject>
        where TObject : Object
    {
        /// <summary>
        /// The targeting common object field view.
        /// </summary>
        CommonObjectFieldView<TObject> view;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the common object field callback class.
        /// </summary>
        /// <param name="view">The common object field view to set for.</param>
        public CommonObjectFieldCallback
        (
            CommonObjectFieldView<TObject> view
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
        }


        /// <summary>
        /// Register ChangeEvent to the field.
        /// </summary>
        void RegisterChangeEvent() => view.Field.RegisterValueChangedCallback(ChangeEvent);


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
    }
}