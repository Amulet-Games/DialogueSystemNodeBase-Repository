using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonFloatFieldCallback
    {
        /// <summary>
        /// The targeting common float field view.
        /// </summary>
        CommonFloatFieldView view;


        /// <summary>
        /// Constructor of the common float field callback class.
        /// </summary>
        /// <param name="view">The common float field view to set for.</param>
        public CommonFloatFieldCallback(CommonFloatFieldView view)
        {
            this.view = view;
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
            view.FloatField.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            // Push the current container's value to the undo stack.
            //TestingWindow.Instance.PushUndo(floatContainer);

            view.Value = view.FloatField.value;

            WindowChangedEvent.Invoke();
        }
    }
}