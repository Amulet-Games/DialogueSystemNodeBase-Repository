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


        Clickable m_Clickable;

        /// <summary>
        /// Manipulator that tracks Mouse events on the button and callbacks when its clicked.
        /// </summary>
        public Clickable Clickable
        {
            get
            {
                return m_Clickable;
            }
            set
            {
                if (m_Clickable != null && m_Clickable.target == this)
                {
                    this.RemoveManipulator(m_Clickable);
                }

                m_Clickable = value;
                if (m_Clickable != null)
                {
                    this.AddManipulator(m_Clickable);
                }
            }
        }


        /// <summary>
        /// The event to invoke when the content button is clicked.
        /// </summary>
        public event Action ClickEvent
        {
            add
            {
                if (m_Clickable == null)
                {
                    Clickable = new Clickable(value);
                }
                else
                {
                    m_Clickable.clicked += value;
                }
            }
            remove
            {
                if (m_Clickable != null)
                {
                    m_Clickable.clicked -= value;
                }
            }
        }
    }
}