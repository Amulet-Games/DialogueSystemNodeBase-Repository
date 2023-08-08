using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class ContentButton : VisualElement
    {
        /// <summary>
        /// Label element for the button's name.
        /// </summary>
        public Label Label;


        /// <summary>
        /// Image element for the button's icon.
        /// </summary>
        public Image IconImage;


        /// <summary>
        /// The property of the manipulator that tracks Mouse events on the button and callbacks when its clicked.
        /// </summary>
        public ContentButtonClickable Clickable
        {
            get
            {
                return clickable;
            }
            set
            {
                if (clickable != null && clickable.target == this)
                {
                    this.RemoveManipulator(clickable);
                }

                clickable = value;
                if (clickable != null)
                {
                    this.AddManipulator(clickable);
                }
            }
        }


        /// <summary>
        /// Manipulator that tracks Mouse events on the button and callbacks when its clicked.
        /// </summary>
        ContentButtonClickable clickable;


        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        public event Action ClickEvent
        {
            add
            {
                if (clickable == null)
                {
                    Clickable = new ContentButtonClickable(handler: value, delay: 0, interval: 0);
                }
                else
                {
                    clickable.clicked += value;
                }
            }
            remove
            {
                if (clickable != null)
                {
                    clickable.clicked -= value;
                }
            }
        }


        /// <summary>
        /// Invoke the content button's clicked action.
        /// </summary>
        public void Click() => clickable.Invoke();
    }
}