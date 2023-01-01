using UnityEngine.UIElements;

namespace AG.DS
{
    public class FoldoutFactory
    {
        /// <summary>
        /// Factory method for c
        /// </summary>
        /// <param name="foldoutContainer"></param>
        /// <param name="foldoutLabelText"></param>
        /// <param name="foldoutUSS01"></param>
        /// <returns></returns>
        public static Foldout GetNewFoldout
        (
            FoldoutContainer foldoutContainer,
            string foldoutLabelText,
            string foldoutUSS01 = ""
        )
        {
            Foldout foldout;

            CreateFoldout();

            ConnectFoldoutToContainer();

            SetFoldoutDetails();

            AddFieldToStyleClass();

            return foldout;

            void CreateFoldout()
            {
                foldout = new();
            }

            void ConnectFoldoutToContainer()
            {
                // Connect the element to the container.
                foldoutContainer.Foldout = foldout;
            }

            void SetFoldoutDetails()
            {
                foldout.value = default;
                foldout.text = foldoutLabelText;
            }

            void AddFieldToStyleClass()
            {
                foldout.AddToClassList(foldoutUSS01);
            }
        }
    }
}