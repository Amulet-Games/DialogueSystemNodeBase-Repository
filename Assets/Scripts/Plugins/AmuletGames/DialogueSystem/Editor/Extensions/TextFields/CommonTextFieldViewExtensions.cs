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
                view.Field.ShowEmptyStyle();
                view.PlaceholderTextLabel.DisplayElement();
            }
            else
            {
                view.Field.HideEmptyStyle();
                view.PlaceholderTextLabel.UnDisplayElement();
            }
        }
    }
}