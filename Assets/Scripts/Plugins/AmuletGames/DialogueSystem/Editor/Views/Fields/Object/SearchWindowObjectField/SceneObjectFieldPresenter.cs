using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class SceneObjectFieldPresenter
    {
        /// <summary>
        /// Create the elements for the scene object field view.
        /// </summary>
        /// <typeparam name="TObject">Type object</typeparam>
        /// <param name="view">The scene object field view to set for.</param>
        /// <param name="fieldUSS01">The first field USS style to set for.</param>
        /// <param name="fieldUSS02">The second field USS style to set for.</param>
        public static void CreateElement
        (
            SceneObjectFieldView view,
            string fieldUSS01,
            string fieldUSS02 = null
        )
        {
            ObjectField field;
            VisualElement fieldInput;
            VisualElement fieldDisplay;
            VisualElement fieldSelector;
            VisualElement fieldDisplayImage;
            VisualElement fieldDisplayLabel;

            CreateField();

            SetupDetails();

            AddStyleClass();

            void CreateField()
            {
                view.Field = new();

                var (inputElement, displayElement, selectorElement, displayImageElement, displayLabelElement) = view.Field.GetInitialChildElements();

                field = view.Field;
                fieldInput = inputElement;
                fieldDisplay = displayElement;
                fieldSelector = selectorElement;
                fieldDisplayImage = displayImageElement;
                fieldDisplayLabel = displayLabelElement;
            }

            void SetupDetails()
            {
                field.objectType = typeof(GameObject);
                field.allowSceneObjects = true;

                fieldDisplay.Remove(fieldDisplayImage);
                fieldSelector.AddBackgroundHighlighter();
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