using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public class BlackboardCategoryPresenter
    {
        /// <summary>
        /// Create a new blackboard category element.
        /// </summary>
        /// <param name="categoryTitle">The category title to set for.</param>
        /// <returns>A new blackboard category element.</returns>
        public static BlackboardCategory CreateElement(string categoryTitle)
        {
            BlackboardCategory category;

            CreateCategory();

            CreateContainers();

            CreateBlackboardRow();

            return category;

            void CreateCategory()
            {
                category = new BlackboardCategory(title: categoryTitle);
                category.AddToClassList(className: StyleConfig.Blackboard_Category);
            }

            void CreateContainers()
            {
                category.ContentContainer = new();
                category.ContentContainer.AddToClassList(className: StyleConfig.Blackboard_Category_Container);
            }

            void CreateBlackboardRow()
            {
                category.Row = new BlackboardRow(item: category, propertyView: category.ContentContainer);
            }
        }
    }
}