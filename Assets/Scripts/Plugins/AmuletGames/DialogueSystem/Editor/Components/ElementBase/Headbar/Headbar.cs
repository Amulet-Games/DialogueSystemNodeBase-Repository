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
        /// Text model for the graph title.
        /// </summary>
        public GraphTitleTextFieldModel GraphTitleTextFieldModel;


        /// <summary>
        /// Button that save the editor window when clicked.
        /// </summary>
        public Button SaveButton;


        /// <summary>
        /// Button that load the editor window when clicked.
        /// </summary>
        public Button LoadButton;


        /// <summary>
        /// Is the headbar in focus at the moment?
        /// </summary>
        public bool IsFocus;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the headbar element class.
        /// </summary>
        public Headbar()
        {
            GraphTitleTextFieldModel = new();
        }


        // ----------------------------- Update Title and Language -----------------------------
        /// <summary>
        /// Update all the language fields within the editor to suit the current selected language,
        /// and update the custom graph editor's title.
        /// </summary>
        /// <param name="dsData">The dialogue system data which has connected to the custom graph editor.</param>
        public void RefreshTitleAndLanguage(DialogueSystemData dsData)
        {
            ChangeGraphLanguage(value: LanguageManager.Instance.SelectedLanguage);

            GraphTitleTextFieldModel.TextField.SetValueWithoutNotify(newValue: dsData.name);
        }


        /// <summary>
        /// Update the custom graph editor's current language to the given ones.
        /// </summary>
        /// <param name="value">The language to change to.</param>
        public void ChangeGraphLanguage(G_LanguageType value)
        {
            var languageManager = LanguageManager.Instance;

            languageManager.SelectedLanguage = value;
            LanguageToolbarMenu.text = languageManager.GetShort(type: languageManager.SelectedLanguage);

            LanguageChangedEvent.Invoke();
        }
    }
}