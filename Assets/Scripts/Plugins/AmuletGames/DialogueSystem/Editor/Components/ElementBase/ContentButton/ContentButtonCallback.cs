using UnityEngine.UIElements;

namespace AG.DS
{
    public class ContentButtonCallback
    {
        /// <summary>
        /// Is pressing the button invokes WindowChangedEvent?
        /// </summary>
        bool isAlert;


        /// <summary>
        /// The targeting content button.
        /// </summary>
        ContentButton contentButton;


        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        EventCallback<ClickEvent> clickEvent;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the content button callback class.
        /// </summary>
        /// <param name="isAlert">The isAlert value to set for.</param>
        /// <param name="contentButton">The targeting content button to set for.</param>
        /// <param name="clickEvent">The clickEvent to set for.</param>
        public ContentButtonCallback
        (
            bool isAlert,
            ContentButton contentButton,
            EventCallback<ClickEvent> clickEvent
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
        void RegisterClickEvent() => contentButton.RegisterCallback(clickEvent);


        /// <summary>
        /// Register alert ClickEvent to the content button.
        /// </summary>
        void RegisterAlertClickEvent() => contentButton.RegisterCallback<ClickEvent>(AlertClickEvent);


        // ----------------------------- Event -----------------------------
        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        /// <param name="evt">The registering event.</param>
        void AlertClickEvent(ClickEvent evt)
        {
            WindowChangedEvent.Invoke();
        }
    }
}