using System;

namespace AG.DS
{
    public class ContentButtonObserver
    {
        /// <summary>
        /// The targeting content button view.
        /// </summary>
        ContentButtonView view;


        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        Action clickEvent;


        /// <summary>
        /// Constructor of the content button observer class.
        /// </summary>
        /// <param name="view">The content button view to set for.</param>
        /// <param name="clickEvent">The ClickEvent to set for.</param>
        public ContentButtonObserver
        (
            ContentButtonView view,
            Action clickEvent
        )
        {
            this.view = view;
            this.clickEvent = clickEvent;
        }


        // ----------------------------- Register Events -----------------------------
        /// <summary>
        /// Register events to the content button.
        /// </summary>
        public void RegisterEvents()
        {
            RegisterClickEvent();
        }


        /// <summary>
        /// Register ClickEvent to the content button.
        /// </summary>
        void RegisterClickEvent()
            => new ButtonObserver(
                isAlert: true,
                button: view.Button,
                clickEvent: clickEvent).RegisterEvents();
    }
}