using UnityEditor.UIElements;
using UnityEngine;

namespace AG.DS
{
    public class LanguageObjectFieldPresenter
    {
        /// <summary>
        /// Method for creating a new language object field element.
        /// </summary>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <param name="fieldUSS02">The second USS style to set for the field.</param>
        /// <returns>A new language object field element.</returns>
        public static ObjectField CreateElement<TObject> 
        (
            string fieldUSS01,
            string fieldUSS02 = null
        )
            where TObject : Object
        {
            ObjectField languageObjectField;

            CreateField();

            SetFieldDetails();

            ChangeSelectorIcon();

            ShowEmptyStyle();

            AddFieldToStyleClass();

            return languageObjectField;

            void CreateField()
            {
                languageObjectField = new();
            }

            void SetFieldDetails()
            {
                languageObjectField.objectType = typeof(TObject);
                languageObjectField.allowSceneObjects = false;
            }

            void ChangeSelectorIcon()
            {

            }

            void ShowEmptyStyle()
            {
                languageObjectField.ShowEmptyStyle("");
            }

            void AddFieldToStyleClass()
            {
                languageObjectField.AddToClassList(fieldUSS01);

                if (fieldUSS02 != null)
                    languageObjectField.AddToClassList(fieldUSS02);
            }
        }
    }
}