using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    public class BlackboardCategory : UnityEditor.Experimental.GraphView.BlackboardSection
    {
        /// <summary>
        /// Element that connects the category's section element and the content container.
        /// </summary>
        public BlackboardRow Row;


        /// <summary>
        /// Element that contains the category's content's elements.
        /// </summary>
        public VisualElement ContentContainer;


        /// <summary>
        /// Constructor of the blackboard category element.
        /// </summary>
        /// <param name="title">The category title to set for.</param>
        public BlackboardCategory(string title)
        {
            this.title = title;
        }
    }
}