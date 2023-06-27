using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonButtonCallback
    {
        /// <summary>
        /// Is pressing the button invokes WindowChangedEvent?
        /// </summary>
        bool isAlert;


        /// <summary>
        /// The targeting button.
        /// </summary>
        Button button;


        /// <summary>
        /// The event to invoke when the button is clicked.
        /// </summary>
        EventCallback<ClickEvent> clickEvent;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the common button callback class.
        /// </summary>
        /// <param name="isAlert">The isAlert value to set for.</param>
        /// <param name="button">The button to set for.</param>
        /// <param name="clickEvent">The clickEvent to set for.</param>
        public CommonButtonCallback
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
        /// Register events to the common button.
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
        /// Register ClickEvent to the common button.
        /// </summary>
        void RegisterClickEvent() => button.RegisterCallback(clickEvent);


        /// <summary>
        /// Register alert ClickEvent to the common button.
        /// </summary>
        void RegisterAlertClickEvent() => button.RegisterCallback<ClickEvent>(AlertClickEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when isAlert is set to true and the content button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void AlertClickEvent(ClickEvent evt)
        {
            WindowChangedEvent.Invoke();
        }
    }
}