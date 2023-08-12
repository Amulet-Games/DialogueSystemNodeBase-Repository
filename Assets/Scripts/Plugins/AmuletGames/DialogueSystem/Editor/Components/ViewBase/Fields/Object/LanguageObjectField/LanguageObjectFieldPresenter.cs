using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageObjectFieldPresenter
    {
        /// <summary>
        /// Method for creating a new language object field element.
        /// </summary>
        /// <typeparam name="TObject">Type object</typeparam>
        /// <param name="view">The language object field view to set for.</param>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <param name="fieldUSS02">The second USS style to set for the field.</param>
        public static void CreateElement<TObject> 
        (
            LanguageObjectFieldView<TObject> view,
            string fieldUSS01,
            string fieldUSS02 = null
        )
            where TObject : Object
        {
            ObjectField field;
            VisualElement fieldInput;
            VisualElement fieldDisplay;
            Label fieldDisplayLabel;
            VisualElement fieldSelector;

            CreateField();

            SetFieldDetails();

            AddFieldToStyleClass();

            ShowEmptyStyle();

            void CreateField()
            {
                view.Field = new();

                field = view.Field;
                fieldInput = field.GetFieldInput();
                fieldDisplay = field.GetFieldDisplay();
                fieldDisplayLabel = field.GetDisplayLabel();
                fieldSelector = field.GetFieldSelector();
            }

            void SetFieldDetails()
            {
                field.objectType = typeof(TObject);
                field.allowSceneObjects = false;

                // Remove display image.
                fieldDisplay.Remove(field.GetDisplayImage());

                // Add background highlighter to the selector
                field.GetFieldSelector().AddBackgroundHighlighter();
            }

            void AddFieldToStyleClass()
            {
                field.ClearClassList();
                fieldInput.ClearClassList();
                fieldDisplay.ClearClassList();
                fieldDisplayLabel.ClearClassList();

                field.AddToClassList(fieldUSS01);
                fieldInput.AddToClassList(StyleConfig.Object_Field_Input);
                fieldDisplay.AddToClassList(StyleConfig.Object_Field_Display);
                fieldDisplayLabel.AddToClassList(StyleConfig.Object_Field_Display_Label);

                if (fieldUSS02 != null)
                    field.AddToClassList(fieldUSS02);
            }

            void ShowEmptyStyle()
            {
                view.CurrentLanguageValue = null;
            }
        }
    }
}