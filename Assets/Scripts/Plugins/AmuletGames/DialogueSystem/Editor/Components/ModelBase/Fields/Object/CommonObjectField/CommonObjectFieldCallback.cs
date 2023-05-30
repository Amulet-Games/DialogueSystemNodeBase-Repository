using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonObjectFieldCallback<TObject> where TObject : UnityEngine.Object
    {
        /// <summary>
        /// The targeting common object field model.
        /// </summary>
        CommonObjectFieldModel<TObject> model;


        /// <summary>
        /// The additional ChangeEvent that can be set to invoke after the default ones.
        /// </summary>
        EventCallback<ChangeEvent<TObject>> additionalChangeEvent;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the common object field callback class.
        /// </summary>
        /// <param name="model">The common object field model to set for.</param>
        /// <param name="additionalChangeEvent">The additional ChangeEvent to set for.</param>
        public CommonObjectFieldCallback
        (
            CommonObjectFieldModel<TObject> model,
            EventCallback<ChangeEvent<TObject>> additionalChangeEvent = null
        )
        {
            this.model = model;
            this.additionalChangeEvent = additionalChangeEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the common object field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterChangeEvent();

            RegisterAdditionalChangeEvent();
        }


        /// <summary>
        /// Register ChangeEvent to the field.
        /// </summary>
        void RegisterChangeEvent() =>
            model.ObjectField.RegisterCallback<ChangeEvent<TObject>>(ChangeEvent);


        /// <summary>
        /// Register additional ChangeEvent to the field.
        /// </summary>
        void RegisterAdditionalChangeEvent()
        {
            if (additionalChangeEvent != null)
            {
                model.ObjectField.RegisterCallback(additionalChangeEvent);
            }
        }


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ChangeEvent(ChangeEvent<TObject> evt)
        {
            var field = model.ObjectField;

            // Unbind the previous value.
            field.Unbind();

            // Push the current container's value to the undo stack.
            //TestingWindow.Instance.PushUndo(
            //    reversible: objectContainer,
            //    dataReversedAction: containerValueChangedAction
            //);

            if (evt.newValue)
            {
                model.Value = evt.newValue;

                // Bind the new value.
                field.Bind(obj: new SerializedObject(model.Value));
            }
            else
            {
                model.Value = null;
            }

            field.ToggleEmptyStyle();

            WindowChangedEvent.Invoke();
        }
    }
}