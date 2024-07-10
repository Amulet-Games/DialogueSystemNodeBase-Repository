namespace AG.DS
{
    public static class SearchWindowSelectorExtensions
    {
        /// <summary>
        /// Add the search window selector to the null value style class if its selected entry's user data value is null,
        /// <br>otherwise remove the selector from the null value style class.</br>
        /// </summary>
        /// <param name="selector">Extension search window selector.</param>
        public static void ToggleNullValueStyle(this SearchWindowSelector selector)
        {
            if (selector.SelectedEntry.userData == null)
            {
                selector.ShowNullValueStyle();
            }
            else
            {
                selector.HideNullValueStyle();
            }
        }


        /// <summary>
        /// Remove the search window selector from the null value style class.
        /// </summary>
        /// <param name="selector">Extension search window selector.</param>
        public static void HideNullValueStyle(this SearchWindowSelector selector)
        {
            selector.SelectorButtonTextLabel.text = selector.SelectedEntry.name; 
            selector.RemoveFromClassList(StyleConfig.SearchWindowSelector_Empty);
        }


        /// <summary>
        /// Add the search window selector to the null value style class.
        /// </summary>
        /// <param name="selector">Extension search window selector.</param>
        public static void ShowNullValueStyle(this SearchWindowSelector selector)
        {
            selector.SelectorButtonTextLabel.text = selector.NullValueSelectorButtonLabelText;
            selector.AddToClassList(StyleConfig.SearchWindowSelector_Empty);
        }
    }
}