using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonIntegerFieldCallback
    {
        /// <summary>
        /// The targeting common integer field view.
        /// </summary>
        CommonIntegerFieldView view;


        /// <summary>
        /// Constructor of the common integer field callback class.
        /// </summary>
        /// <param name="view">The common integer field view to set for.</param>
        public CommonIntegerFieldCallback(CommonIntegerFieldView view)
        {
            this.view = view;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the common integer field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFocusOutEvent();
        }


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() =>
            view.IntegerField.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            // Push the current container's value to the undo stack.
            //TestingWindow.Instance.PushUndo(floatContainer);

            view.Value = view.IntegerField.value;

            WindowChangedEvent.Invoke();
        }
    }
}