using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageObjectFieldObserver<TObject>
        where TObject : Object
    {
        /// <summary>
        /// The targeting language object field view.
        /// </summary>
        LanguageObjectFieldView<TObject> view;


        /// <summary>
        /// Constructor of the language object field observer class.
        /// </summary>
        /// <param name="view">The language object field view to set for.</param>
        public LanguageObjectFieldObserver(LanguageObjectFieldView<TObject> view)
        {
            this.view = view;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the language object field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterChangeEvent();

            RegisterFocusInEvent();

            RegisterFocusOutEvent();
        }


        /// <summary>
        /// Register ChangeEvent to the field.
        /// </summary>
        void RegisterChangeEvent() =>
            view.Field.RegisterValueChangedCallback(ChangeEvent);


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
        /// The event to invoke when the field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ChangeEvent(ChangeEvent<Object> evt)
        {
            var field = view.Field;

            // Unbind the previous value.
            field.Unbind();

            // Push the current container's value to the undo stack.
            ///TestingWindow.Instance.PushUndo(languageAudioClipContainer);
            
            view.Value = evt.newValue
                ? evt.newValue as TObject
                : null;

            WindowChangedEvent.Invoke();
        }


        /// <summary>
        /// The event to invoke when the field value has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusInEvent(FocusInEvent evt)
        {
            InputHint.ShowHint
            (
                hintText: StringConfig.InputHint_HintTextLabel_LabelText,
                targetWorldBoundRect: view.Field.worldBound
            );
        }


        /// <summary>
        /// The event to invoke when the field value has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            InputHint.HideHint();
        }
    }
}