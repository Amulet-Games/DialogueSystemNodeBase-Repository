using System;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class Button : VisualElement
    {
        /// <summary>
        /// The property of the manipulator that tracks Mouse events on the button and callbacks when its clicked.
        /// </summary>
        public Clickable Clickable
        {
            get
            {
                return m_clickable;
            }
            set
            {
                if (m_clickable != null && m_clickable.target == this)
                {
                    this.RemoveManipulator(m_clickable);
                }

                m_clickable = value;
                if (m_clickable != null)
                {
                    this.AddManipulator(m_clickable);
                }
            }
        }


        /// <summary>
        /// Manipulator that tracks Mouse events on the button and callbacks when its clicked.
        /// </summary>
        Clickable m_clickable;


        /// <summary>
        /// The event to invoke when the button is clicked.
        /// </summary>
        public event Action ClickEvent
        {
            add
            {
                if (m_clickable == null)
                {
                    Clickable = new Clickable(clicked: value, delay: 0, interval: 0);
                }
                else
                {
                    m_clickable.clicked += value;
                }
            }
            remove
            {
                if (m_clickable != null)
                {
                    m_clickable.clicked -= value;
                }
            }
        }


        /// <summary>
        /// Invoke the clickable's clicked action.
        /// </summary>
        public void Click() => m_clickable.Invoke();
    }
}