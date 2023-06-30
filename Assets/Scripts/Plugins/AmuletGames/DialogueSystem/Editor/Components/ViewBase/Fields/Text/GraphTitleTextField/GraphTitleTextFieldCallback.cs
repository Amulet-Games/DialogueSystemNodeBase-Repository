using UnityEditor;
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
        /// The asset instance id of the dialogue system model.
        /// </summary>
        int dsModelInstanceId;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the graph title field callback class.
        /// </summary>
        /// <param name="view">The graph title text field view to set for.</param>
        /// <param name="dsModelInstanceId">The dialogue system model asset instance id to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        public GraphTitleTextFieldCallback
        (
            GraphTitleTextFieldView view,
            int dsModelInstanceId,
            DialogueEditorWindow dsWindow
        )
        {
            field = view.TextField;
            this.dsModelInstanceId = dsModelInstanceId;
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
    }
}