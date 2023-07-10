using UnityEditor;

namespace AG.DS
{
    public class EditorApplicationCallback
    {
        /// <summary>
        /// The application's open id that were saved in the editor prefs.
        /// </summary>
        int applicationOpenId;


        /// <summary>
        /// The key to use when saving the editor application's close id into editor prefs.
        /// </summary>
        string applicationCloseIdKey;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue editor window callback class.
        /// </summary>
        /// <param name="applicationOpenId">The application open id to set for.</param>
        /// <param name="applicationCloseIdKey">The application close id key to set for.</param>
        public EditorApplicationCallback
        (
            int applicationOpenId,
            string applicationCloseIdKey
        )
        {
            this.applicationOpenId = applicationOpenId;
            this.applicationCloseIdKey = applicationCloseIdKey;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the editor application.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterEditorApplicationQuittingEvent();
        }


        /// <summary>
        /// Register EditorApplicationQuittingEvent to the editor application.
        /// </summary>
        void RegisterEditorApplicationQuittingEvent() =>
            EditorApplication.quitting += EditorApplicationQuittingEvent;

        
        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the editor application is quitting.
        /// <para></para>
        /// <br>Note that this will not fire if the Editor is forced to quit or if there is a crash.</br>
        /// <br>This event is raised when the quitting process cannot be canceled.</br>
        /// </summary>
        void EditorApplicationQuittingEvent()
        {
            EditorPrefs.SetInt(
                key: applicationCloseIdKey,
                value: applicationOpenId
            );
        }
    }
}