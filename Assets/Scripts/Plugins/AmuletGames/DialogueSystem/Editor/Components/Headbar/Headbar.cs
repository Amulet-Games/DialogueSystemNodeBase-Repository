using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class Headbar : VisualElement
    {
        /// <summary>
        /// Toolbar menu for the editor window language.
        /// </summary>
        public ToolbarMenu LanguageToolbarMenu;


        /// <summary>
        /// Text view for the graph title.
        /// </summary>
        public GraphTitleTextFieldView GraphTitleTextFieldView;


        /// <summary>
        /// Button that save the editor window when clicked.
        /// </summary>
        public Button SaveButton;


        /// <summary>
        /// Button that load the editor window when clicked.
        /// </summary>
        public Button LoadButton;


        /// <summary>
        /// Is the headBar in focus at the moment?
        /// </summary>
        public bool IsFocus;


        /// <summary>
        /// Constructor of the headbar element class.
        /// </summary>
        /// <param name="dialogueSystemWindowAsset">The dialogue system window asset to set for.</param>
        public Headbar(DialogueSystemWindowAsset dialogueSystemWindowAsset)
        {
            GraphTitleTextFieldView = new(
            value: dialogueSystemWindowAsset.Name,
                bindingSO: new SerializedObject(obj: dialogueSystemWindowAsset)
            );
        }
    }
}