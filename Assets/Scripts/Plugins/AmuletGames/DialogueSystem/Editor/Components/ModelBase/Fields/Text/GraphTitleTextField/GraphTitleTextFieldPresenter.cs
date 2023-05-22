using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class GraphTitleTextFieldPresenter
    {
        /// <summary>
        /// Method for creating a new graph title text field element.
        /// </summary>
        /// <param name="dsData">The dialogue system data to bind with after the field is created.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new graph title text field element.</returns>
        public static TextField CreateElement
        (
            DialogueSystemData dsData,
            string fieldUSS01
        )
        {
            TextField graphTitleTextField;

            CreateField();

            SetFieldDetails();

            BindFieldToSerializedObject();

            AddFieldToStyleClass();

            return graphTitleTextField;

            void CreateField()
            {
                graphTitleTextField = new();
            }

            void SetFieldDetails()
            {
                graphTitleTextField.SetValueWithoutNotify(dsData.name);

                // The new value can only be set by the user pressing Enter or Return key.
                graphTitleTextField.isDelayed = true;
            }

            void BindFieldToSerializedObject()
            {
                // Create the serialized object from the dialogue system data.
                SerializedObject so = new(obj: dsData);

                // Bind the new value.
                graphTitleTextField.Bind(so);

                // Setup callback action when the bound serialized object's value has changed.
                graphTitleTextField.TrackSerializedObjectValue(obj: so, so =>
                {
                    graphTitleTextField.SetValueWithoutNotify(so.targetObject.name);
                });
            }

            void AddFieldToStyleClass()
            {
                graphTitleTextField.AddToClassList(fieldUSS01);
            }
        }
    }
}