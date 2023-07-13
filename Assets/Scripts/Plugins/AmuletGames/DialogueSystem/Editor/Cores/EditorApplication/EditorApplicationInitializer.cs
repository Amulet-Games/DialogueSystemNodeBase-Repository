using System.IO;
using UnityEditor;
using UnityEngine;

namespace AG.DS
{
    [InitializeOnLoad]
    public class EditorApplicationInitializer
    {
        /// <summary>
        /// The file name of the quit confirm file.
        /// </summary>
        const string QUIT_CONFIRM_FILE_NAME = "QuitConfirmFile.txt";


        /// <summary>
        /// The file path of the quit confirm file.
        /// </summary>
        static string QUIT_CONFIRM_FILE_PATH;


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
        /// Did the editor application previously closed successfully without crashing?
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

                // Set quit file path.
                {
                    QUIT_CONFIRM_FILE_PATH = Path.Combine(Application.persistentDataPath, QUIT_CONFIRM_FILE_NAME);
                }

                // Check the application previous quit status and reset quit file.
                {
                    var isQuitFileExist = File.Exists(QUIT_CONFIRM_FILE_PATH);

                    isQuitPeacefully = !isQuitFileExist
                                    || !QUIT_CONFIRM_FILE_PATH.IsFileEmpty();

                    if (isQuitFileExist)
                    {
                        // Empty quit file.
                        File.WriteAllText(QUIT_CONFIRM_FILE_PATH, string.Empty);
                    }
                    else
                    {
                        // Create quit file
                        using (File.Create(QUIT_CONFIRM_FILE_PATH)) { }
                    }
                }

                // Register events.
                {
                    new EditorApplicationCallback(QUIT_CONFIRM_FILE_PATH).RegisterEvents();
                }
            }
        }
    }
}