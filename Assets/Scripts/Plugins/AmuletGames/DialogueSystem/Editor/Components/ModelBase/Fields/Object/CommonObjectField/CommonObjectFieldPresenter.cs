using UnityEditor.UIElements;

namespace AG.DS
{
    public class CommonObjectFieldPresenter
    {
        /// <summary>
        /// Method for creating a new common object field UIElement.
        /// </summary>
        /// <typeparam name="TObject">Type object</typeparam>
        /// <param name="fieldUSS01">The first USS style to set for the field.</param>
        /// <param name="fieldUSS02">The second USS style to set for the field.</param>
        /// <returns>A new common object field UIElement.</returns>
        public static ObjectField CreateElements<TObject>
        (
            string fieldUSS01,
            string fieldUSS02 = null
        )
            where TObject : UnityEngine.Object
        {
            ObjectField commonObjectField;

            CreateField();

            SetFieldDetails();

            ChangeSelectorIcon();

            ShowEmptyStyle();

            AddFieldToStyleClass();

            return commonObjectField;

            void CreateField()
            {
                commonObjectField = new();
            }

            void SetFieldDetails()
            {
                commonObjectField.objectType = typeof(TObject);
                commonObjectField.allowSceneObjects = false;
            }

            void ChangeSelectorIcon()
            {
                var selectorElement = commonObjectField.ElementAt(0).ElementAt(1);

                selectorElement.style.backgroundImage =
                    ConfigResourcesManager.Instance.SpriteConfig.ObjectFieldSelectorIconSprite.texture;
            }

            void ShowEmptyStyle()
            {
                commonObjectField.ShowEmptyStyle();
            }

            void AddFieldToStyleClass()
            {
                commonObjectField.AddToClassList(fieldUSS01);

                if (fieldUSS02 != null)
                    commonObjectField.AddToClassList(fieldUSS02);
            }
        }
    }
}