using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonObjectFieldPresenter
    {
        /// <summary>
        /// Method for creating a new common object field element.
        /// </summary>
        /// <typeparam name="TObject">Type object</typeparam>
        /// <param name="placeholderText">The placeholder text to set for the field.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <param name="fieldUSS02">The second USS style to set for the field.</param>
        /// <returns>A new common object field element.</returns>
        public static ObjectField CreateElement<TObject>
        (
            CommonObjectFieldView<TObject> view,
            string fieldUSS01,
            string fieldUSS02 = null
        )
            where TObject : Object
        {
            ObjectField objectField;
            VisualElement fieldInput;
            VisualElement fieldDisplay;
            Label fieldDisplayLabel;
            VisualElement fieldSelector;

            CreateField();

            SetFieldDetails();

            AddFieldToStyleClass();

            ShowEmptyStyle();

            return objectField;

            void CreateField()
            {
                view.Field = new();

                objectField = view.Field;
                fieldInput = objectField.GetFieldInput();
                fieldDisplay = objectField.GetFieldDisplay();
                fieldDisplayLabel = objectField.GetDisplayLabel();
                fieldSelector = objectField.GetFieldSelector();
            }

            void SetFieldDetails()
            {
                objectField.objectType = typeof(TObject);
                objectField.allowSceneObjects = false;

                // Remove display image.
                fieldDisplay.Remove(objectField.GetDisplayImage());

                // Add background highlighter to the selector
                fieldSelector.AddBackgroundHighlighter();
            }

            void AddFieldToStyleClass()
            {
                objectField.ClearClassList();
                fieldInput.ClearClassList();
                fieldDisplay.ClearClassList();
                fieldDisplayLabel.ClearClassList();

                objectField.AddToClassList(fieldUSS01);
                fieldInput.AddToClassList(StyleConfig.Object_Field_Input);
                fieldDisplay.AddToClassList(StyleConfig.Object_Field_Display);
                fieldDisplayLabel.AddToClassList(StyleConfig.Object_Field_Display_Label);

                if (fieldUSS02 != null)
                    objectField.AddToClassList(fieldUSS02);
            }

            void ShowEmptyStyle()
            {
                view.Value = null;
            }
        }
    }
}