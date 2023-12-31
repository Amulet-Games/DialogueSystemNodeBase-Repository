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
        public CommonButton SaveButton;


        /// <summary>
        /// Button that load the editor window when clicked.
        /// </summary>
        public CommonButton LoadButton;


        /// <summary>
        /// Is the headBar in focus at the moment?
        /// </summary>
        public bool IsFocus;


        /// <summary>
        /// Constructor of the headbar element class.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        public Headbar(DialogueSystemModel dsModel)
        {
            GraphTitleTextFieldView = new(
                value: dsModel.name,
                bindingSO: new SerializedObject(obj: dsModel)
            );
        }
    }
}