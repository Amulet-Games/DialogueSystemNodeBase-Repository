namespace AG.DS
{
    public class RadioGroupPresenter
    {
        /// <summary>
        /// Create a new radio group element.
        /// </summary>
        /// <param name="radios">The radio elements to set for.</param>
        /// <returns>A new radio group element.</returns>
        public static RadioGroup CreateElement(Radio[] radios)
        {
            RadioGroup group;

            // Create group
            group = new(radios);
            group.AddToClassList(StyleConfig.RadioGroup);

            // Add stylesheet
            group.styleSheets.Add(ConfigResourcesManager.StyleSheetConfig.RadioGroupStyle);
            
            return group;
        }
    }
}