using UnityEngine.UIElements;

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
        Button button;


        /// <summary>
        /// The event to invoke when the button is clicked.
        /// </summary>
        EventCallback<ClickEvent> clickEvent;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the common button observer class.
        /// </summary>
        /// <param name="isAlert">The isAlert value to set for.</param>
        /// <param name="button">The button element to set for.</param>
        /// <param name="clickEvent">The clickEvent to set for.</param>
        public CommonButtonObserver
        (
            bool isAlert,
            Button button,
            EventCallback<ClickEvent> clickEvent
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
        void RegisterClickEvent() => button.RegisterCallback(clickEvent);


        /// <summary>
        /// Register alert ClickEvent to the button.
        /// </summary>
        void RegisterAlertClickEvent() => button.RegisterCallback<ClickEvent>(AlertClickEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the button is clicked and the isAlert property.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void AlertClickEvent(ClickEvent evt)
        {
            WindowChangedEvent.Invoke();
        }
    }
}