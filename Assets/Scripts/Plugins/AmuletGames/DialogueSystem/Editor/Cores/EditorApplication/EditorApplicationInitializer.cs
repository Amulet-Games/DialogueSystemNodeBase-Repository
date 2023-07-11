using UnityEditor;
using UnityEngine;
using System.IO;
using System;

namespace AG.DS
{
    [InitializeOnLoad]
    public class EditorApplicationInitializer
    {
        const string QUIT_CONFIRM_TEXT_FILE_NAME = "QuitConfirmText.txt";


        static string QUIT_CONFIRM_TEXT_FILE_PATH => Path.Combine(Application.persistentDataPath, QUIT_CONFIRM_TEXT_FILE_NAME);


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
        /// Constructor of the editor application initializer class.
        /// </summary>
        static EditorApplicationInitializer()
        {
            if (!isInitialized && EditorApplication.isPlayingOrWillChangePlaymode == false)
            {   
                isInitialized = true;

                // Check if the application close id has been saved previously.
                isQuitPeacefully = !QUIT_CONFIRM_TEXT_FILE_PATH.IsFileExist()
                                || !QUIT_CONFIRM_TEXT_FILE_PATH.IsFileEmpty();

                // Remove all the text in the quit confirm text file.
                if (QUIT_CONFIRM_TEXT_FILE_PATH.IsFileExist())
                {
                    File.WriteAllText(QUIT_CONFIRM_TEXT_FILE_PATH, String.Empty);
                }

                // Register events.
                new EditorApplicationCallback(QUIT_CONFIRM_TEXT_FILE_PATH).RegisterEvents();
            }
        }
    }
}