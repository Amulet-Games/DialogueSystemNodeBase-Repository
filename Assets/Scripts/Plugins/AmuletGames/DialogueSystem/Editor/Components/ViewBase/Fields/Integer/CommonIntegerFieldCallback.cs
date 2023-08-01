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
        /// The old value that was set when the use has given focus on the field.
        /// </summary>
        int previousValue;


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
                //TestingWindow.Instance.PushUndo(integerView);

                view.Value = view.Field.value;

                WindowChangedEvent.Invoke();
            }
        }
    }
}