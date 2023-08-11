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
        /// Reference of the dialogue system model.
        /// </summary>
        DialogueSystemModel dsModel;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// Constructor of the graph title field observer class.
        /// </summary>
        /// <param name="view">The graph title text field view to set for.</param>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        public GraphTitleTextFieldObserver
        (
            GraphTitleTextFieldView view,
            DialogueSystemModel dsModel,
            DialogueEditorWindow dsWindow
        )
        {
            this.view = view;
            this.dsModel = dsModel;
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
            if (evt.newValue != "")
            {
                // Change dsModel asset name
                {
                    dsModel.RenameAsset(newName: evt.newValue);
                    dsWindow.ApplyChangesToDisk();
                }
            }

            view.Value = evt.newValue;
        }


        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            view.Field.RefreshValueNonAlert();
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