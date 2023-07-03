using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphTitleTextFieldCallback
    {
        /// <summary>
        /// The targeting graph title text field.
        /// </summary>
        TextField field;


        /// <summary>
        /// Reference the dialogue system model.
        /// </summary>
        DialogueSystemModel dsModel;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        /// <summary>
        /// The asset instance id of the dialogue system model.
        /// </summary>
        int dsModelInstanceId;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the graph title field callback class.
        /// </summary>
        /// <param name="view">The graph title text field view to set for.</param>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        public GraphTitleTextFieldCallback
        (
            GraphTitleTextFieldView view,
            DialogueSystemModel dsModel,
            DialogueEditorWindow dsWindow
        )
        {
            field = view.TextField;
            this.dsModel = dsModel;
            this.dsWindow = dsWindow;

            dsModelInstanceId = dsModel.GetInstanceID();
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
        void RegisterChangeEvent() =>
            field.RegisterCallback<ChangeEvent<string>>(ChangeEvent);


        /// <summary>
        /// Register FocusOutEvent to the field.
        /// </summary>
        void RegisterFocusOutEvent() =>
            field.RegisterCallback<FocusOutEvent>(FocusOutEvent);


        /// <summary>
        /// Register SerializedObjectValueChangeEvent to the field.
        /// </summary>
        void RegisterSerializedObjectValueChangeEvent()
        {
            // Create new serialized object.
            SerializedObject so = new(obj: dsModel);

            // Bind serialized object.
            field.Bind(so);

            // Setup bind event.
            field.TrackSerializedObjectValue(obj: so, SerializedObjectValueChangeEvent);
        }


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the field value has changed.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void ChangeEvent(ChangeEvent<string> evt)
        {
            AssetDatabase.RenameAsset
            (
                pathName: AssetDatabase.GetAssetPath(instanceID: dsModelInstanceId),
                newName: evt.newValue
            );

            dsWindow.ApplyChangesToDisk();
        }


        /// <summary>
        /// The event to invoke when the field has lost focus.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void FocusOutEvent(FocusOutEvent evt)
        {
            field.RefreshValueNonAlert();
        }


        /// <summary>
        /// The event to invoke when the bound serialized object's value has changed.
        /// </summary>
        /// <param name="so">The bound serialized object to set for.</param>
        void SerializedObjectValueChangeEvent(SerializedObject so)
        {
            field.SetValueWithoutNotify(so.targetObject.name);
        }
    }
}