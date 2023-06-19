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
        /// The asset instance id of the dialogue system data.
        /// </summary>
        int dsDataInstanceId;


        /// <summary>
        /// Reference of the dialogue editor window.
        /// </summary>
        DialogueEditorWindow dsWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the graph title field callback class.
        /// </summary>
        /// <param name="model">The graph title text field model to set for.</param>
        /// <param name="dsDataInstanceId">The dialogue system data's asset instance id to set for.</param>
        /// <param name="dsWindow">The dialogue editor window to set for.</param>
        public GraphTitleTextFieldCallback
        (
            GraphTitleTextFieldModel model,
            int dsDataInstanceId,
            DialogueEditorWindow dsWindow
        )
        {
            field = model.TextField;
            this.dsDataInstanceId = dsDataInstanceId;
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
                pathName: AssetDatabase.GetAssetPath(instanceID: dsDataInstanceId),
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