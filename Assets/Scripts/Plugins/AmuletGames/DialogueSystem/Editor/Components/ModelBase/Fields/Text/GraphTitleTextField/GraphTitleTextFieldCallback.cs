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
        /// The asset instance id of the connecting dialogue system data.
        /// </summary>
        int dsDataInstanceId;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the graph title field callback class.
        /// </summary>
        /// <param name="model">The targeting graph title text field model to set for.</param>
        /// <param name="dsDataInstanceId">The connecting dialogue system data's asset instance id to set for.</param>
        public GraphTitleTextFieldCallback
        (
            GraphTitleTextFieldModel model,
            int dsDataInstanceId
        )
        {
            field = model.TextField;
            this.dsDataInstanceId = dsDataInstanceId;
        }


        // ----------------------------- Register Events Service -----------------------------
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

            // Save the changes.
            ApplyChangesToDiskEvent.Invoke();
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