using UnityEngine.UIElements;

namespace AG.DS
{
    public class FolderTitleTextFieldPresenter
    {
        /// <summary>
        /// Method for creating a new folder title text field element.
        /// </summary>
        /// <param name="titleText">The title text to set for the field.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <returns>A new folder title text field element.</returns>
        public static TextField CreateElement
        (
            string titleText,
            string fieldUSS01
        )
        {
            TextField folderTitleTextField;

            CreateField();

            SetFieldDetails();

            AddFieldToStyleClass();

            return folderTitleTextField;

            void CreateField()
            {
                folderTitleTextField = new();
            }

            void SetFieldDetails()
            {
                folderTitleTextField.SetValueWithoutNotify(newValue: titleText);

                // The new value can only be set by the user pressing Enter or Return key.
                folderTitleTextField.isDelayed = true;

                folderTitleTextField.multiline = false;

                // Field's input visual element doesn't react to the user's mouse interaction by default.
                folderTitleTextField.GetElementInput().pickingMode = PickingMode.Ignore;
            }

            void AddFieldToStyleClass()
            {
                folderTitleTextField.AddToClassList(fieldUSS01);
            }
        }
    }
}