using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadBarView
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
        /// Constructor of the headBar view class.
        /// </summary>
        public HeadBarView(DialogueSystemModel dsModel)
        {
            GraphTitleTextFieldView = new(
                value: dsModel.name,
                bindingSO: new SerializedObject(obj: dsModel)
            );
        }
    }
}