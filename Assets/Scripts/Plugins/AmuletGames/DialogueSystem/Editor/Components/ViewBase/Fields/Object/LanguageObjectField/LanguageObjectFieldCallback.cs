using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageObjectFieldCallback<TObject>
        where TObject : UnityEngine.Object
    {
        /// <summary>
        /// The targeting language object field view.
        /// </summary>
        LanguageObjectFieldView<TObject> view;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the language object field callback class.
        /// </summary>
        /// <param name="view">The language object field view to set for.</param>
        public LanguageObjectFieldCallback(LanguageObjectFieldView<TObject> view)
        {
            this.view = view;
        }


        // ----------------------------- Constructor -----------------------------
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
            view.ObjectField.RegisterValueChangedCallback(ChangeEvent);


        /// <summary>
        /// Register FocusInEvent to the field.
        /// </summary>
        void RegisterFocusInEvent() =>
            view.ObjectField.RegisterCallback<FocusInEvent>(FocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() =>
            view.ObjectField.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ChangeEvent(ChangeEvent<Object> evt)
        {
            var field = view.ObjectField;

            // Unbind the previous value.
            field.Unbind();

            // Push the current container's value to the undo stack.
            ///TestingWindow.Instance.PushUndo(languageAudioClipContainer);

            if (evt.newValue)
            {
                view.LanguageGeneric
                    .ValueByLanguageType[LanguageManager.Instance.CurrentLanguage] = evt.newValue as TObject;

                // Bind the new value.
                field.Bind(obj: new SerializedObject(evt.newValue));
            }
            else
            {
                view.LanguageGeneric
                    .ValueByLanguageType[LanguageManager.Instance.CurrentLanguage] = null;
            }

            field.ToggleEmptyStyle(view.PlaceholderText);

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
                targetWorldBoundRect: view.ObjectField.worldBound
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