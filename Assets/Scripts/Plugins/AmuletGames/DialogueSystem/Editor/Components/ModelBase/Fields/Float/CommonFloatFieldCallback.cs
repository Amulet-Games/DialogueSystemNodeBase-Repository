using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonFloatFieldCallback
    {
        /// <summary>
        /// The targeting common float field model.
        /// </summary>
        CommonFloatFieldModel model;


        /// <summary>
        /// Constructor of the common float field callback class.
        /// </summary>
        /// <param name="model">The common float field model to set for.</param>
        public CommonFloatFieldCallback(CommonFloatFieldModel model)
        {
            this.model = model;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the common float field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFocusOutEvent();
        }


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() =>
            model.FloatField.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            // Push the current container's value to the undo stack.
            //TestingWindow.Instance.PushUndo(floatContainer);

            model.Value = model.FloatField.value;

            WindowChangedEvent.Invoke();
        }
    }
}