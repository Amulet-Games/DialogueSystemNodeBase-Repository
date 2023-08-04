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
                return bindingSO;
            }
            set
            {
                if (value != null)
                {
                    bindingSO = value;
                }

                Field.Bind(bindingSO);
            }
        }


        /// <summary>
        /// The serialized object that is binding with the field.
        /// </summary>
        [NonSerialized] SerializedObject bindingSO;


        /// <summary>
        /// The property of the serializable value of the view.
        /// </summary>
        public string Value
        {
            get
            {
                return value;
            }
            set
            {
                if (value != "")
                {
                    this.value = value;
                }

                Field.SetValueWithoutNotify(this.value);
            }
        }


        /// <summary>
        /// The serializable value of the view.
        /// </summary>
        [SerializeField] string value;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the graph title text field view class.
        /// </summary>
        /// <param name="value">The value of the view to set for.</param>
        /// <param name="bindingSO">The binding serialized object to set for.</param>
        public GraphTitleTextFieldView(string value, SerializedObject bindingSO)
        {
            this.value = value;
            this.bindingSO = bindingSO;
        }


        ///TODO: IReversible
        // ----------------------------- IReversible -----------------------------
    }
}