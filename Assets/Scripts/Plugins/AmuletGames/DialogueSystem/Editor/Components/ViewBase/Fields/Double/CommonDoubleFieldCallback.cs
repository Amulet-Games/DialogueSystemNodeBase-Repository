using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonDoubleFieldCallback
    {
        /// <summary>
        /// The targeting common double field view.
        /// </summary>
        CommonDoubleFieldView view;


        /// <summary>
        /// The old value that was set when the use has given focus on the field.
        /// </summary>
        double previousValue;


        /// <summary>
        /// Constructor of the common double field callback class.
        /// </summary>
        /// <param name="view">The common double field view to set for.</param>
        public CommonDoubleFieldCallback(CommonDoubleFieldView view)
        {
            this.view = view;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the common double field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFocusInEvent();

            RegisterFocusOutEvent();
        }


        /// <summary>
        /// Register FocusInEvent to the field.
        /// </summary>
        void RegisterFocusInEvent() =>
            view.Field.RegisterCallback<FocusInEvent>(FocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() =>
            view.Field.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusInEvent(FocusInEvent evt)
        {
            previousValue = view.Value;

            view.Field.HideEmptyStyle();
        }


        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            var field = view.Field;

            if (field.value != previousValue)
            {
                // Push the current container's value to the undo stack.
                //TestingWindow.Instance.PushUndo(doubleContainer);

                view.Value = view.Field.value;

                WindowChangedEvent.Invoke();
            }
        }
    }
}