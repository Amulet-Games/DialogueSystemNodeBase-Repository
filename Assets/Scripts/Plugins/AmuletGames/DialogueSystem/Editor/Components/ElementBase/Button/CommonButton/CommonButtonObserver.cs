using System;

namespace AG.DS
{
    public class CommonButtonObserver
    {
        /// <summary>
        /// Is pressing the button will invoke the WindowChangedEvent?
        /// </summary>
        bool isAlert;


        /// <summary>
        /// The targeting button element.
        /// </summary>
        CommonButton button;


        /// <summary>
        /// The event to invoke when the button is clicked.
        /// </summary>
        Action clickEvent;


        /// <summary>
        /// Constructor of the common button observer class.
        /// </summary>
        /// <param name="isAlert">The isAlert value to set for.</param>
        /// <param name="button">The button element to set for.</param>
        /// <param name="clickEvent">The clickEvent to set for.</param>
        public CommonButtonObserver
        (
            bool isAlert,
            CommonButton button,
            Action clickEvent
        )
        {
            this.isAlert = isAlert;
            this.button = button;
            this.clickEvent = clickEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the common button element.
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
        /// The event to invoke when the button is clicked and the isAlert property.
        /// </summary>
        void AlertClickEvent()
        {
            WindowChangedEvent.Invoke();
        }
    }
}