using UnityEngine.UIElements;

namespace AG.DS
{
    public class BlackboardSection : UnityEditor.Experimental.GraphView.BlackboardSection
    {
        /// <summary>
        /// Constructor of the blackboard selection element.
        /// </summary>
        /// <param name="title">The section title to set for.</param>
        public BlackboardSection(string title)
        {
            this.title = title;
        }
    }
}
