using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphTitleTextFieldObserver
    {
        /// <summary>
        /// The targeting graph title text field view.
        /// </summary>
        GraphTitleTextFieldView view;


        /// <summary>
        /// Reference of the dialogue system window.
        /// </summary>
        DialogueSystemWindow dsWindow;


        /// <summary>
        /// Constructor of the graph title field observer class.
        /// </summary>
        /// <param name="view">The graph title text field view to set for.</param>
        /// <param name="dsWindow">The dialogue system window to set for.</param>
        public GraphTitleTextFieldObserver
        (
            GraphTitleTextFieldView view,
            DialogueSystemWindow dsWindow
        )
        {
            this.view = view;
            this.dsWindow = dsWindow;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the graph title text field.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterChangeEvent();

            RegisterFocusOutEvent();

            RegisterSerializedObjectValueChangeEvent();
        }


        /// <summary>
        /// Register ChangeEvent to the field.
        /// </summary>
        void RegisterChangeEvent() => view.Field.RegisterValueChangedCallback(ChangeEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() => view.Field.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        /// <summary>
        /// Register SerializedObjectValueChangeEvent to the field.
        /// </summary>
        void RegisterSerializedObjectValueChangeEvent() =>
            view.Field.TrackSerializedObjectValue(obj: view.BindingSO, SerializedObjectValueChangeEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ChangeEvent(ChangeEvent<string> evt)
        {
            view.Value = evt.newValue;

            if (view.Value != "")
            {
                dsWindow.RenameWindow(value: evt.newValue);
            }
        }


        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            view.Field.SetValueWithoutNotify(view.Field.value);
        }


        /// <summary>
        /// The event to invoke when the binding serialized object's value has changed.
        /// </summary>
        /// <param name="so">The binding serialized object.</param>
        void SerializedObjectValueChangeEvent(SerializedObject so)
        {
            view.Value = so.targetObject.name;
        }
    }
}