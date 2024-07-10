namespace AG.DS
{
    public class LanguageTextFieldCallback
    {
        /// <summary>
        /// The callback to invoke when the language text field view is created on the graph by the user.
        /// </summary>
        /// <param name="view">The language text field view to set for.</param>
        public static void OnCreateByUser(LanguageTextFieldView view)
        {
            view.CurrentLanguageValue = "";
        }
    }
}