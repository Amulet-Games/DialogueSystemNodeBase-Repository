using System;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class ReflectableObjectFieldView<TObject>
        where TObject : UnityEngine.Object
    {
        /// <summary>
        /// Visual element.
        /// </summary>
        [NonSerialized] public ObjectField Field;


        /// <summary>
        /// The text to display when the field is empty.
        /// </summary>
        [NonSerialized] string placeholderText;


        /// <summary>
        /// The property of the serializable value of the view.
        /// </summary>
        public TObject Value
        {
            get
            {
                return m_value;
            }
            set
            {
                m_value = value;

                Field.SetValueWithoutNotify(m_value);
                Field.ToggleEmptyStyle(placeholderText);

                if (m_value != null)
                {
                    Field.Bind(obj: new SerializedObject(m_value));
                }
                else
                {
                    Field.Unbind();
                }

                ValueChangedEvent?.Invoke();
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// </summary>
        [SerializeField] TObject m_value;


        /// <summary>
        /// The event to invoke when the serializable value has changed.
        /// </summary>
        public Action ValueChangedEvent;


        /// <summary>
        /// Constructor of the reflectable object field view class.
        /// </summary>
        /// <param name="placeholderText">The placeholder text to set for.</param>
        public ReflectableObjectFieldView(string placeholderText)
        {
            this.placeholderText = placeholderText;
        }
    }
}