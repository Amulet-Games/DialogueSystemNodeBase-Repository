using UnityEngine.UIElements;

namespace AG.DS
{
    public class FolderTitleTextFieldObserver
    {
        /// <summary>
        /// The targeting folder title text field view.
        /// </summary>
        FolderTitleTextFieldView view;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the folder title text field observer class.
        /// </summary>
        /// <param name="view">The folder title text field view to set for.</param>
        public FolderTitleTextFieldObserver(FolderTitleTextFieldView view)
        {
            this.view = view;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the folder title text field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterChangeEvent();

            RegisterFieldInputFocusInEvent();

            RegisterFieldInputFocusOutEvent();
        }


        /// <summary>
        /// Register ChangeEvent to the field.
        /// </summary>
        void RegisterChangeEvent() => view.Field.RegisterValueChangedCallback(ChangeEvent);


        /// <summary>
        /// Register FocusInEvent to the field input element.
        /// </summary>
        void RegisterFieldInputFocusInEvent() =>
            view.Field.GetFieldInput().RegisterCallback<FocusInEvent>(FieldInputFocusInEvent);


        /// <summary>
        /// Register FocusOutEvent to the field input element.
        /// </summary>
        void RegisterFieldInputFocusOutEvent() =>
            view.Field.GetFieldInput().RegisterCallback<FocusOutEvent>(FieldInputFocusOutEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ChangeEvent(ChangeEvent<string> evt)
        {
            // Since the folder title text field's isDelay value is set to true,
            // this event will only be invoked when the user pressed Enter or Return key.

            // If the field has a new value, the value needs to be different than the previous one,
            // empty string will also be count as new value.

            if (evt.newValue != "")
            {
                WindowChangedEvent.Invoke();
            }

            view.Value = evt.newValue;
        }


        /// <summary>
        /// The event to invoke when the field input element has given focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FieldInputFocusInEvent(FocusInEvent evt)
        {
            // Allow inputs
            {
                var fieldInput = view.Field.GetFieldInput();
                var textElement = view.Field.GetTextElement();

                fieldInput.AddToClassList(StyleConfig.Pseudo_Focus);

                fieldInput.pickingMode = PickingMode.Position;
                textElement.pickingMode = PickingMode.Position;
            }
        }


        /// <summary>
        /// The event to invoke when the field input element has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FieldInputFocusOutEvent(FocusOutEvent evt)
        {
            // Forbidden inputs
            {
                var fieldInput = view.Field.GetFieldInput();
                var textElement = view.Field.GetTextElement();

                fieldInput.RemoveFromClassList(StyleConfig.Pseudo_Focus);

                fieldInput.focusable = false;
                fieldInput.pickingMode = PickingMode.Ignore;
                textElement.pickingMode = PickingMode.Ignore;
            }
        }
    }
}