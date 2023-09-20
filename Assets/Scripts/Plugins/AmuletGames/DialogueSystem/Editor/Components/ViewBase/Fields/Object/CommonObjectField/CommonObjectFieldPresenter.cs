using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class CommonObjectFieldPresenter
    {
        /// <summary>
        /// Create the elements for the common object field view.
        /// </summary>
        /// <typeparam name="TObject">Type object</typeparam>
        /// <param name="view">The common object field view to set for.</param>
        /// <param name="fieldUSS01">The first field USS style to set for.</param>
        /// <param name="fieldUSS02">The second field USS style to set for.</param>
        public static void CreateElement<TObject>
        (
            CommonObjectFieldView<TObject> view,
            string fieldUSS01,
            string fieldUSS02 = null
        )
            where TObject : Object
        {
            ObjectField field;
            VisualElement fieldInput;
            VisualElement fieldDisplay;
            Label fieldDisplayLabel;

            CreateField();

            SetupDetails();

            AddStyleClass();

            void CreateField()
            {
                view.Field = new();

                field = view.Field;
                fieldInput = field.GetFieldInput();
                fieldDisplay = field.GetFieldDisplay();
                fieldDisplayLabel = field.GetDisplayLabel();
            }

            void SetupDetails()
            {
                field.objectType = typeof(TObject);
                field.allowSceneObjects = false;

                // Remove display image
                fieldDisplay.Remove(field.GetDisplayImage());

                // Add background highlighter to the selector
                field.GetFieldSelector().AddBackgroundHighlighter();

                view.Value = null;
            }

            void AddStyleClass()
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
        }
    }
}