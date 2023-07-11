using System.IO;
using UnityEditor;
using Unity.EditorCoroutines.Editor;
using System.Collections;
using UnityEngine;

namespace AG.DS
{
    public class EditorApplicationCallback
    {
        string quitConfirmTextFilePath;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue editor window callback class.
        /// </summary>
        /// <param name="quitConfirmTextFilePath"></param>
        public EditorApplicationCallback(string quitConfirmTextFilePath)
        {
            this.quitConfirmTextFilePath = quitConfirmTextFilePath;
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
            EditorApplication.wantsToQuit += EditorApplicationWantsToQuitEvent;

        
        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the editor application is quitting.
        /// <para></para>
        /// <br>Note that this will not fire if the Editor is forced to quit or if there is a crash.</br>
        /// <br>This event is raised when the quitting process cannot be canceled.</br>
        /// </summary>
        bool EditorApplicationWantsToQuitEvent()
        {
            if (!File.Exists(quitConfirmTextFilePath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(quitConfirmTextFilePath))
                {
                    sw.WriteLine("UNITY_QUIT_CONFIRMED");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(quitConfirmTextFilePath))
                {
                    sw.WriteLine("UNITY_QUIT_CONFIRMED");
                }
            }

            return File.Exists(quitConfirmTextFilePath) && !quitConfirmTextFilePath.IsFileEmpty();
        }

        IEnumerator Test()
        {
            yield return new WaitUntil(() => File.Exists(quitConfirmTextFilePath) && !quitConfirmTextFilePath.IsFileEmpty());
        }
    }
}