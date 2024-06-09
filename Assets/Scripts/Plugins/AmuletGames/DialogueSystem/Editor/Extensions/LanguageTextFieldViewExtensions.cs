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
            if (view.IsEmpty)
            {
                ShowEmptyStyle(view);
            }
            else
            {
                HideEmptyStyle(view);
            }
        }


        /// <summary>
        /// Add the language text field to the empty style class.
        /// </summary>
        /// <param name="field">Extension language text field.</param>
        public static void ShowEmptyStyle(this LanguageTextFieldView view)
        {
            view.Field.AddToClassList(StyleConfig.Text_Field_Empty);
            view.Field.GetFieldInput().UnDisplayElement();
            view.PlaceholderTextLabel.DisplayElement();
        }


        /// <summary>
        /// Remove the language text field from the empty style class.
        /// </summary>
        /// <param name="field">Extension language text field.</param>
        public static void HideEmptyStyle(this LanguageTextFieldView view)
        {
            view.Field.RemoveFromClassList(StyleConfig.Text_Field_Empty);
            view.Field.GetFieldInput().DisplayElement();
            view.PlaceholderTextLabel.UnDisplayElement();
        }
    }
}