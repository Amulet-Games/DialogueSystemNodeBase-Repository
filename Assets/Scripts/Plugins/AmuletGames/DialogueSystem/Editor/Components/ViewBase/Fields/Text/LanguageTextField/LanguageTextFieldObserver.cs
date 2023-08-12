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
        /// Constructor of the language text field observer class.
        /// </summary>
        /// <param name="view">The language text field view to set for.</param>
        public LanguageTextFieldObserver(LanguageTextFieldView view)
        {
            this.view = view;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the language text field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFocusInEvent();

            RegisterFocusOutEvent();
        }


        /// <summary>
        /// Register FocusInEvent to the field.
        /// </summary>
        void RegisterFocusInEvent() => view.Field.RegisterCallback<FocusInEvent>(FocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() => view.Field.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusInEvent(FocusInEvent evt)
        {
            var field = view.Field;

            InputHint.ShowHint
            (
                hintText: StringConfig.InputHint_HintTextLabel_LabelText,
                targetWorldBoundRect: field.worldBound
            );

            field.HideEmptyStyle();
        }


        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            view.CurrentLanguageValue = view.Field.value;

            WindowChangedEvent.Invoke();

            InputHint.HideHint();
        }
    }
}