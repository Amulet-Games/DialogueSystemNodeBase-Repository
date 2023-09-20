using UnityEngine.UIElements;

namespace AG.DS
{
    public class RadioObserver
    {
        /// <summary>
        /// The targeting radio element.
        /// </summary>
        Radio radio;


        /// <summary>
        /// Reference of the radio group element.
        /// </summary>
        RadioGroup radioGroup;


        /// <summary>
        /// Constructor of the radio observer class.
        /// </summary>
        /// <param name="radio">The radio element to set for.</param>
        /// <param name="radioGroup">The radio group element to set for.</param>
        public RadioObserver
        (
            Radio radio,
            RadioGroup radioGroup
        )
        {
            this.radio = radio;
            this.radioGroup = radioGroup;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the radio element.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterMouseDownEvent();
        }


        /// <summary>
        /// Register MouseDownEvent to the radio element.
        /// </summary>
        void RegisterMouseDownEvent() => radio.RegisterCallback<MouseDownEvent>(MouseDownEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the mouse button is clicked inside the radio element.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void MouseDownEvent(MouseDownEvent evt)
        {
            radioGroup.ActiveRadio = radio;
        }
    }
}