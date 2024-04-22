using System;
using System.Reflection;
using UnityEngine.UIElements;

namespace AG.DS
{
    [Serializable]
    public class FieldInfoFieldView
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public TextField Field;


        /// <summary>
        /// Label for the placeholder text.
        /// </summary>
        public Label PlaceholderTextLabel;


        /// <summary>
        /// The property of the serializable value of the view.
        /// </summary>
        public FieldInfo Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;

                Field.SetValueWithoutNotify(m_value.Name);

                PlaceholderTextLabel.SetDisplay(m_value == null);
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// </summary>
        FieldInfo m_value;


        /// <summary>
        /// Image for the search window icon.
        /// </summary>
        public Image SearchWindowIconImage;


        /// <summary>
        /// Reference of the search window.
        /// </summary>
        public SearchWindow SearchWindow;
    }
}