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
        static string QUIT_CONFIRM_FILE_PATH => Path.Combine(Application.persistentDataPath, QUIT_CONFIRM_FILE_NAME);


        /// <summary>
        /// The key to use when saving the isInitialized value into the session state.
        /// </summary>
        const string IS_INITIALIZED_SESSION_STATE_KEY = "IS_INITIALIZED_SESSION_STATE_KEY";


        /// <summary>
        /// Return true if the class has already been initialized.
        /// </summary>
        static bool isInitialized
        {
            get
            {
                return SessionState.GetBool(key: IS_INITIALIZED_SESSION_STATE_KEY, defaultValue: false);
            }
            set
            {
                SessionState.SetBool(key: IS_INITIALIZED_SESSION_STATE_KEY, value);
            }
        }


        /// <summary>
        /// The key to use when saving the isClosePeacefully value into the session state.
        /// </summary>
        const string IS_CLOSE_PEACEFULLY_SESSION_STATE_KEY = "IS_CLOSE_PEACEFULLY_SESSION_STATE_KEY";


        /// <summary>
        /// Return true if the editor application previously is closed by user input and not by crashed.
        /// </summary>
        public static bool IsClosePeacefully
        {
            get
            {
                return SessionState.GetBool(key: IS_CLOSE_PEACEFULLY_SESSION_STATE_KEY, defaultValue: false);
            }
            set
            {
                SessionState.SetBool(key: IS_CLOSE_PEACEFULLY_SESSION_STATE_KEY, value);
            }
        }


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the editor application initializer class.
        /// </summary>
        static EditorApplicationInitializer()
        {
            if (!isInitialized)
            {
                isInitialized = true;

                // Check the application previous quit status and reset quit file.
                {
                    var isQuitFileExist = File.Exists(QUIT_CONFIRM_FILE_PATH);

                    IsClosePeacefully = !isQuitFileExist
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
            }

            if (EditorApplication.isPlayingOrWillChangePlaymode == false)
            {
                // Register events.
                new EditorApplicationCallback(QUIT_CONFIRM_FILE_PATH).RegisterEvents();
            }
        }
    }
}