namespace AG.DS
{
    public static class CommonTextFieldViewExtensions
    {
        /// <summary>
        /// Add the common text field to the empty class if its current value is empty,
        /// <br>otherwise remove the field from the empty style class.</br>
        /// </summary>
        /// <param name="view">Extension common text field view.</param>
        public static void ToggleEmptyStyle(this CommonTextFieldView view)
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
        /// Add the common text field to the empty style class.
        /// </summary>
        /// <param name="field">Extension common text field.</param>
        public static void ShowEmptyStyle(this CommonTextFieldView view)
        {
            view.Field.AddToClassList(StyleConfig.Text_Field_Empty);
            view.Field.GetFieldInput().UnDisplayElement();
            view.PlaceholderTextLabel.DisplayElement();
        }


        /// <summary>
        /// Remove the common text field from the empty style class.
        /// </summary>
        /// <param name="field">Extension common text field.</param>
        public static void HideEmptyStyle(this CommonTextFieldView view)
        {
            view.Field.RemoveFromClassList(StyleConfig.Text_Field_Empty);
            view.Field.GetFieldInput().DisplayElement();
            view.PlaceholderTextLabel.UnDisplayElement();
        }
    }
}