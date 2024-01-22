namespace AG.DS
{
    public class RadioGroupObserver
    {
        /// <summary>
        /// The targeting radio group element.
        /// </summary>
        RadioGroup radioGroup;


        /// <summary>
        /// Constructor of the radio group observer class.
        /// </summary>
        /// <param name="radioGroup">The radio group element to set for.</param>
        public RadioGroupObserver(RadioGroup radioGroup)
        {
            this.radioGroup = radioGroup;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the radio group elements.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterRadioEvents();
        }


        /// <summary>
        /// Register events to the radio elements.
        /// </summary>
        void RegisterRadioEvents()
        {
            var radios = radioGroup.Radios;
            for (int i = 0; i < radios.Length; i++)
            {
                new RadioObserver(radios[i], radioGroup).RegisterEvents();
            }
        }
    }
}