using System.IO;
using UnityEditor;

namespace AG.DS
{
    public class EditorApplicationObserver
    {
        /// <summary>
        /// The file path of the quit confirm file.
        /// </summary>
        string quitConfirmFilePath;


        /// <summary>
        /// The text to write into the quit confirm file.
        /// </summary>
        const string QUIT_CONFIRM_TEXT = "UNITY QUIT SUCCESSFULY";


        /// <summary>
        /// Constructor of the editor application observer class.
        /// </summary>
        /// <param name="quitConfirmFilePath">The quit confirm file's file path to set for.</param>
        public EditorApplicationObserver(string quitConfirmFilePath)
        {
            this.quitConfirmFilePath = quitConfirmFilePath;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the editor application.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterEditorApplicationWantsToQuitEvent();
        }


        /// <summary>
        /// Register EditorApplicationWantsToQuitEvent to the editor application.
        /// </summary>
        void RegisterEditorApplicationWantsToQuitEvent() =>
            EditorApplication.wantsToQuit += EditorApplicationWantsToQuitEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the editor application wants to quit.
        /// <para></para>
        /// <br>When this event is raised the quit process has started but can be canceled.</br>
        /// <br>This means the editor is not guaranteed to quit.</br>
        /// <br>For a guaranteed quit event take a look at EditorApplication.quitting</br>
        /// </summary>
        /// <returns>Returns true and the quit process will continue. Return false and quit process will cancel.</returns>
        bool EditorApplicationWantsToQuitEvent()
        {
            // Write to the existing quit file.
            File.WriteAllText(quitConfirmFilePath, QUIT_CONFIRM_TEXT);

            return !quitConfirmFilePath.IsFileEmpty();
        }
    }
}