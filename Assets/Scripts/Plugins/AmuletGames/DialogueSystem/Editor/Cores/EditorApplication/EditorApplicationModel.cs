using UnityEditor;
using Random = System.Random;

namespace AG.DS
{
    [InitializeOnLoad]
    public class EditorApplicationModel
    {
        /// <summary>
        /// The key to use when saving the application's open id into editor prefs.
        /// </summary>
        const string APPLICATION_OPEN_ID_KEY = "APPLICATION_OPEN_ID_KEY";


        /// <summary>
        /// The key to use when saving the editor application's close id into editor prefs.
        /// </summary>
        const string APPLICATION_CLOSE_ID_KEY = "APPLICATION_CLOSE_ID_KEY";


        /// <summary>
        /// The key to use when saving the editor's open session state into session state.
        /// </summary>
        const string EDITOR_OPEN_SESSION_STATE_KEY = "EDITOR_OPEN_SESSION_KEY";


        /// <summary>
        /// Return true if the class has already been initialized.
        /// </summary>
        static bool isInitialized
        {
            get
            {
                return SessionState.GetBool(key: EDITOR_OPEN_SESSION_STATE_KEY, defaultValue: false);
            }
            set
            {
                SessionState.SetBool(key: EDITOR_OPEN_SESSION_STATE_KEY, value);
            }
        }


        /// <summary>
        /// Is the editor application closed previously without crashing?
        /// </summary>
        public static bool isQuitPeacefully { get; private set; }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the editor application model class.
        /// </summary>
        static EditorApplicationModel()
        {
            if (!isInitialized && EditorApplication.isPlayingOrWillChangePlaymode == false)
            {   
                isInitialized = true;

                // Check if the application close id has been saved previously.
                isQuitPeacefully = EditorPrefs.GetInt(key: APPLICATION_OPEN_ID_KEY)
                                == EditorPrefs.GetInt(key: APPLICATION_CLOSE_ID_KEY);

                // Save a new application open id to the editor prefs.
                EditorPrefs.SetInt(key: APPLICATION_OPEN_ID_KEY, value: new Random().Next());

                // Register events.
                new EditorApplicationCallback(
                    applicationOpenId: EditorPrefs.GetInt(key: APPLICATION_OPEN_ID_KEY),
                    applicationCloseIdKey: APPLICATION_CLOSE_ID_KEY
                )
                .RegisterEvents();
            }
        }
    }
}