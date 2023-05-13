using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageObjectFieldCallback<TObject> where TObject : UnityEngine.Object
    {
        /// <summary>
        /// The targeting language object field model.
        /// </summary>
        LanguageObjectFieldModel<TObject> model;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the language object field callback class.
        /// </summary>
        /// <param name="model">The targeting language object field model to set for.</param>
        public LanguageObjectFieldCallback(LanguageObjectFieldModel<TObject> model)
        {
            this.model = model;
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
            model.ObjectField.RegisterCallback<ChangeEvent<TObject>>(ChangeEvent);


        /// <summary>
        /// Register FocusInEvent to the field.
        /// </summary>
        void RegisterFocusInEvent() => model.ObjectField.RegisterCallback<FocusInEvent>(FocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() => model.ObjectField.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ChangeEvent(ChangeEvent<TObject> evt)
        {
            var field = model.ObjectField;

            // Unbind the previous value.
            field.Unbind();

            // Push the current container's value to the undo stack.
            ///TestingWindow.Instance.PushUndo(languageAudioClipContainer);

            if (evt.newValue)
            {
                model.LanguageGeneric
                    .ValueByLanguageType[LanguageManager.Instance.SelectedLanguage] = evt.newValue;

                // Bind the new value.
                field.Bind(obj: new SerializedObject(evt.newValue));
            }
            else
            {
                model.LanguageGeneric
                    .ValueByLanguageType[LanguageManager.Instance.SelectedLanguage] = null;
            }

            field.ToggleEmptyStyle();

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
                hintText: StringConfig.Instance.InputHint_LanguageFieldHint_LabelText,
                targetWorldBoundRect: model.ObjectField.worldBound
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