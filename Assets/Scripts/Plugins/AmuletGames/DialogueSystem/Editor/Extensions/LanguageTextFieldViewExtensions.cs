namespace AG.DS
{
    public static class LanguageTextFieldViewExtensions
    {
        /// <summary>
        /// Add the language text field to the empty class if its current language value is empty,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="view">Extension language text field view.</param>
        public static void ToggleEmptyStyle(this LanguageTextFieldView view)
        {
            if (!view.CurrentLanguageValue.IsNullOrEmpty())
            {
                view.Field.HideEmptyStyle();
            }
            else
            {
                view.Field.ShowEmptyStyle();
            }
        }
    }
}