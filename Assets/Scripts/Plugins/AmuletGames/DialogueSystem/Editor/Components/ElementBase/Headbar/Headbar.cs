using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class HeadBar : VisualElement
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
        /// The event to invoke when the user changed dialogue editor window's language.
        /// </summary>
        public Action LanguageChangedEvent;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the headBar element class.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        public HeadBar(DialogueSystemModel dsModel)
        {
            GraphTitleTextFieldView = new(
                value: dsModel.name,
                bindingSO: new SerializedObject(obj: dsModel)
            );
        }


        // ----------------------------- Service -----------------------------
        /// <summary>
        /// Update all the language fields within the editor to suit the current selected language,
        /// and update the custom graph editor's title.
        /// </summary>
        /// <param name="dsModel">The dialogue system model to set for.</param>
        public void RefreshTitleAndLanguage(DialogueSystemModel dsModel)
        {
            SetEditorLanguage(value: LanguageManager.Instance.CurrentLanguage);

            GraphTitleTextFieldView.Field.SetValueWithoutNotify(newValue: dsModel.name);
        }


        /// <summary>
        /// Set the dialogue editor window language.
        /// </summary>
        /// <param name="value">The language type to set for.</param>
        public void SetEditorLanguage(LanguageType value)
        {
            var languageManager = LanguageManager.Instance;

            languageManager.SetCurrentLanguage(value);
            LanguageToolbarMenu.text = languageManager.GetShort(type: value);

            LanguageChangedEvent?.Invoke();
        }
    }
}