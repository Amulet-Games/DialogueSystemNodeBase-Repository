using System;

namespace AG.DS
{
    public class ContentButtonObserver
    {
        /// <summary>
        /// Is pressing the button will invoke the WindowChangedEvent?
        /// </summary>
        bool isAlert;


        /// <summary>
        /// The targeting content button element.
        /// </summary>
        ContentButton contentButton;


        /// <summary>
        /// The event to invoke when the button is clicked.
        /// </summary>
        Action clickEvent;


        /// <summary>
        /// Constructor of the content button observer class.
        /// </summary>
        /// <param name="isAlert">The isAlert value to set for.</param>
        /// <param name="contentButton">The content button element to set for.</param>
        /// <param name="clickEvent">The clickEvent to set for.</param>
        public ContentButtonObserver
        (
            bool isAlert,
            ContentButton contentButton,
            Action clickEvent
        )
        {
            this.isAlert = isAlert;
            this.contentButton = contentButton;
            this.clickEvent = clickEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the content button.
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
        /// Register ClickEvent to the content button.
        /// </summary>
        void RegisterClickEvent() => contentButton.ClickEvent += clickEvent;


        /// <summary>
        /// Register alert ClickEvent to the content button.
        /// </summary>
        void RegisterAlertClickEvent() => contentButton.ClickEvent += AlertClickEvent;


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        void AlertClickEvent()
        {
            WindowChangedEvent.Invoke();
        }
    }
}