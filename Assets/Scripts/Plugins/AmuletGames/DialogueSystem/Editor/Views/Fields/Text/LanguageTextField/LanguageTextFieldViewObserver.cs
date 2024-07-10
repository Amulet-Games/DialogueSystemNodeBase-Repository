using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageTextFieldObserver
    {
        /// <summary>
        /// The targeting language text field view.
        /// </summary>
        LanguageTextFieldView view;


        /// <summary>
        /// The targeting language text field.
        /// </summary>
        TextField field;


        /// <summary>
        /// The old value that was set when the user has given focus on the field.
        /// </summary>
        string previousValue;


        /// <summary>
        /// Constructor of the language text field observer class.
        /// </summary>
        /// <param name="view">The language text field view to set for.</param>
        public LanguageTextFieldObserver(LanguageTextFieldView view)
        {
            this.view = view;
            field = view.Field;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the language text field.
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
        void RegisterFocusInEvent() => field.RegisterCallback<FocusInEvent>(FocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() => field.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        /// <summary>
        /// Register MouseDownEvent to the field.
        /// </summary>
        void RegisterMouseDownEvent() => field.RegisterCallback<MouseDownEvent>(MouseDownEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusInEvent(FocusInEvent evt)
        {
            previousValue = field.value;

            view.HideEmptyStyle();

            InputHint.ShowHint(hintText: StringConfig.InputHint_HintTextLabel_LabelText, targetWorldBoundRect: field.worldBound);
        }


        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            view.CurrentLanguageValue = field.value;

            if (view.CurrentLanguageValue != previousValue)
            {
                // Push the current view's value to the undo stack.
                ///TestingWindow.Instance.PushUndo(textContainer);

                WindowChangedEvent.Invoke();
            }

            InputHint.HideHint();
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