using System;

namespace AG.DS
{
    using ContentButtonView = NodeViewBase.ContentButtonView;

    /// <summary>
    /// Register events to the node element.
    /// </summary>
    public abstract class NodeObserverBase
    {
        public class ContentButtonViewObserver
        {
            /// <summary>
            /// The targeting content button view.
            /// </summary>
            ContentButtonView view;


            /// <summary>
            /// The event to invoke when the content button view's button is clicked.
            /// </summary>
            Action clickEvent;


            /// <summary>
            /// Constructor of the content button view observer class.
            /// </summary>
            /// <param name="view">The content button view to set for.</param>
            /// <param name="clickEvent">The ClickEvent to set for.</param>
            public ContentButtonViewObserver
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
            /// Register events to the content button view.
            /// </summary>
            public void RegisterEvents()
            {
                RegisterClickEvent();
            }


            /// <summary>
            /// Register ClickEvent to the content button view's button.
            /// </summary>
            void RegisterClickEvent()
                => new ButtonObserver(
                    isAlert: true,
                    button: view.Button,
                    clickEvent: clickEvent).RegisterEvents();
        }
    }
}