using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonIntegerFieldObserver
    {
        /// <summary>
        /// The targeting common integer field view.
        /// </summary>
        CommonIntegerFieldView view;


        /// <summary>
        /// The previous value that was set when the use has given focus on the field.
        /// </summary>
        int previousValue;


        /// <summary>
        /// Constructor of the common integer field observer class.
        /// </summary>
        /// <param name="view">The common integer field view to set for.</param>
        public CommonIntegerFieldObserver(CommonIntegerFieldView view)
        {
            this.view = view;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the common integer field view.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFocusInEvent();

            RegisterFocusOutEvent();

            RegisterMouseDownEvent();
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


        /// <summary>
        /// Register MouseDownEvent to the field.
        /// </summary>
        void RegisterMouseDownEvent() =>
            view.Field.RegisterCallback<MouseDownEvent>(MouseDownEvent);


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