namespace AG.DS
{
    public class RadioGroupPresenter
    {
        /// <summary>
        /// Create a new radio group element.
        /// </summary>
        /// <param name="radios">The radio elements array to set for.</param>
        /// <returns>A new radio group element.</returns>
        public static RadioGroup CreateElement(Radio[] radios)
        {
            RadioGroup group;

            CreateGroup();

            AddElementsToGroup();

            AddClassList();

            void CreateGroup()
            {
                group = new(radios);
            }

            void AddElementsToGroup()
            {
                for (int i = radios.Length - 1; 0 <= i; i--)
                {
                    group.Add(radios[i]);
                }
            }

            void AddClassList()
            {
                group.AddToClassList(StyleConfig.RadioGroup);
            }
            
            return group;
        }
    }
}