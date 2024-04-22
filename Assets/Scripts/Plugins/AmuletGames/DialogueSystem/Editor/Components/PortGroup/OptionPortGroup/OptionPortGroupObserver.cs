namespace AG.DS
{
    public class OptionPortGroupObserver
    {
        /// <summary>
        /// The targeting option port group element.
        /// </summary>
        OptionPortGroup group;


        /// <summary>
        /// Constructor of the option port group observer class.
        /// </summary>
        /// <param name="group"></param>
        public OptionPortGroupObserver(OptionPortGroup group)
        {
            this.group = group;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the option port group element.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterFirstGroupItemEvents();
        }


        /// <summary>
        /// Register events to the first group item.
        /// </summary>
        void RegisterFirstGroupItemEvents()
            => new OptionPortCellObserver(portCell: group.BaseOptionPortCell).RegisterEvents();
    }
}