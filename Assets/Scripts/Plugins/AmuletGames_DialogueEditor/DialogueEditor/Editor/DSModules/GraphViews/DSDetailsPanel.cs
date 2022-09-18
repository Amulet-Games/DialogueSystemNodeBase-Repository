using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG
{
    public class DSDetailsPanel
    {
        /// <summary>
        /// Reference of the dialogue system editor window module.
        /// </summary>
        DialogueEditorWindow dsWindow;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue system's details panel.
        /// </summary>
        /// <param name="dsWindow">Dialogue system's editor window module.</param>
        public DSDetailsPanel(DialogueEditorWindow dsWindow)
        {
            this.dsWindow = dsWindow;
        }
    }
}