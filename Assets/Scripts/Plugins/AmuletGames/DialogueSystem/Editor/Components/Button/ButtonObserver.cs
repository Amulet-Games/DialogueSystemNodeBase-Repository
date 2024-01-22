using System;

namespace AG.DS
{
    public class ButtonObserver
    {
        /// <summary>
        /// Will the WindowChangedEvent get invoked when pressing the button?
        /// </summary>
        bool isAlert;


        /// <summary>
        /// The targeting button element.
        /// </summary>
        Button button;


        /// <summary>
        /// The event to invoke when the button is clicked.
        /// </summary>
        Action clickEvent;


        /// <summary>
        /// Constructor of the button observer class.
        /// </summary>
        /// <param name="isAlert">The isAlert value to set for.</param>
        /// <param name="button">The button element to set for.</param>
        /// <param name="clickEvent">The clickEvent to set for.</param>
        public ButtonObserver
        (
            bool isAlert,
            Button button,
            Action clickEvent
        )
        {
            this.isAlert = isAlert;
            this.button = button;
            this.clickEvent = clickEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the button element.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterClickEvent();

            if (isAlert)
            {
                RegisterAlertClickEvent();
            }
        }


        /// <summary>
        /// Register ClickEvent to the button.
        /// </summary>
        void RegisterClickEvent() => button.ClickEvent += clickEvent;


        /// <summary>
        /// Register AlertClickEvent to the button.
        /// </summary>
        void RegisterAlertClickEvent() => button.ClickEvent += AlertClickEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the button is clicked and the isAlert value was set to true.
        /// </summary>
        void AlertClickEvent()
        {
            WindowChangedEvent.Invoke();
        }
    }
}