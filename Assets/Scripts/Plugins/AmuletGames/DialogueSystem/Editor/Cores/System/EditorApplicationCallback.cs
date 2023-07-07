using System;
using UnityEditor;

namespace AG.DS
{
    public class EditorApplicationCallback
    {
        /// <summary>
        /// Reference of the dialogue system model.
        /// </summary>
        DialogueSystemModel dsModel;


        /// <summary>
        /// Return true if the event of saving the editor application quitted confirm status has already been registered.  
        /// </summary>
        static bool isRegisteredQuittedConfirmationString;


        /// <summary>
        /// The key to use when saving the editor application quitted confirm status into editor prefs. 
        /// </summary>
        public const string EDITOR_APPLICATION_QUITTING_CONFIRM_KEY = "QUITTING";


        /// <summary>
        /// The value to use when saving the editor application quitted confirm status into editor prefs.
        /// </summary>
        public const string EDITOR_APPLICATION_QUITTING_CONFIRM_VALUE = "QUITTED";


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue editor window callback class.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        public EditorApplicationCallback(DialogueSystemModel dsModel)
        {
            this.dsModel = dsModel;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the editor application.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterEditorApplicationQuittingEvent();

            if (!isRegisteredQuittedConfirmationString)
            {
                RegisterSaveQuittedConfirmationStringEvent();
            }
        }


        /// <summary>
        /// Register EditorApplicationQuittingEvent to the editor application.
        /// </summary>
        void RegisterEditorApplicationQuittingEvent() =>
            EditorApplication.quitting += EditorApplicationQuittingEvent;


        /// <summary>
        /// Register SaveQuittedConfirmationStringEvent to the editor application.
        /// </summary>
        void RegisterSaveQuittedConfirmationStringEvent() =>
            EditorApplication.quitting += SaveQuittedConfirmationStringEvent;

        
        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the editor application is quitting.
        /// <para></para>
        /// <br>Note that this will not fire if the Editor is forced to quit or if there is a crash.</br>
        /// <br>This event is raised when the quitting process cannot be cancelled.</br>
        /// </summary>
        void EditorApplicationQuittingEvent()
        {
            isRegisteredQuittedConfirmationString = false;
        }


        /// <summary>
        /// Save the editor application quitted confirmation string as meta data by using EditorPrefs.
        /// </summary>
        void SaveQuittedConfirmationStringEvent()
        {
            EditorPrefs.SetString(
                key: EDITOR_APPLICATION_QUITTING_CONFIRM_KEY,
                value: EDITOR_APPLICATION_QUITTING_CONFIRM_VALUE
            );
        }
    }
}