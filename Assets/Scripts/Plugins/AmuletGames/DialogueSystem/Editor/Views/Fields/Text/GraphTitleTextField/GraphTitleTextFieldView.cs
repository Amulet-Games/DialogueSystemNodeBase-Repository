using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphTitleTextFieldView
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public TextField Field;


        /// <summary>
        /// The property of the serialized object that is binding with the field.
        /// </summary>
        public SerializedObject BindingSO
        {
            get
            {
                return m_bindingSO;
            }
            set
            {
                if (value != null)
                {
                    m_bindingSO = value;
                }

                Field.Bind(m_bindingSO);
            }
        }


        /// <summary>
        /// The serialized object that is binding with the field.
        /// </summary>
        [NonSerialized] SerializedObject m_bindingSO;


        /// <summary>
        /// The property of the serializable value of the view.
        /// </summary>
        public string Value
        {
            get
            {
                return m_value;
            }
            set
            {
                if (value != "")
                {
                    m_value = value;
                }

                Field.SetValueWithoutNotify(m_value);
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// </summary>
        [SerializeField] string m_value;


        /// <summary>
        /// Constructor of the graph title text field view class.
        /// </summary>
        /// <param name="value">The value of the view to set for.</param>
        /// <param name="bindingSO">The binding serialized object to set for.</param>
        public GraphTitleTextFieldView
        (
            string value,
            SerializedObject bindingSO
        )
        {
            m_value = value;
            m_bindingSO = bindingSO;
        }


        // ----------------------------- Service -----------------------------
        ///TODO: IReversible
    }
}