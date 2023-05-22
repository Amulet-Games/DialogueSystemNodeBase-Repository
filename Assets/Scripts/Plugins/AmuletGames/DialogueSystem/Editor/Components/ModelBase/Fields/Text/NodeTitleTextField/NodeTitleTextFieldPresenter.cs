using UnityEngine.UIElements;

namespace AG.DS
{
    public class NodeTitleTextFieldPresenter
    {
        /// <summary>
        /// Method for creating a new node title text field element.
        /// </summary>
        /// <param name="titleText">The title text to set for the field.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new node title text field element.</returns>
        public static TextField CreateElement
        (
            string titleText,
            string fieldUSS01
        )
        {
            TextField nodeTitleTextField;

            CreateField();

            SetFieldDetails();

            AddFieldToStyleClass();

            return nodeTitleTextField;

            void CreateField()
            {
                nodeTitleTextField = new();
            }

            void SetFieldDetails()
            {
                nodeTitleTextField.SetValueWithoutNotify(newValue: titleText);

                // The new value can only be set by the user pressing Enter or Return key.
                nodeTitleTextField.isDelayed = true;

                nodeTitleTextField.multiline = false;

                nodeTitleTextField.GetElementInput().pickingMode = PickingMode.Ignore;
            }

            void AddFieldToStyleClass()
            {
                nodeTitleTextField.AddToClassList(fieldUSS01);
            }
        }
    }
}