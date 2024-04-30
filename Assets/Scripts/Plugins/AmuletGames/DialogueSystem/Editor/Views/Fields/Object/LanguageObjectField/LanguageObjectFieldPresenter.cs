using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class LanguageObjectFieldPresenter
    {
        /// <summary>
        /// Create the elements for the language object field view.
        /// </summary>
        /// <typeparam name="TObject">Type object</typeparam>
        /// <param name="view">The language object field view to set for.</param>
        /// <param name="fieldUSS01">The first field USS style to set for.</param>
        /// <param name="fieldUSS02">The second field USS style to set for.</param>
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
            VisualElement fieldSelector;
            VisualElement fieldDisplayImage;
            VisualElement fieldDisplayLabel;

            CreateField();

            SetupDetails();

            AddStyleClass();

            SetupDefaultValue();

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
                field.objectType = typeof(TObject);
                field.allowSceneObjects = false;

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

            void SetupDefaultValue()
            {
                view.CurrentLanguageValue = null;
            }
        }
    }
}