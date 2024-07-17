using UnityEngine.UIElements;

namespace AG.DS
{
    public static class BlackboardExtensions
    {
        /// <summary>
        /// Return the blackboard's add button element.
        /// </summary>
        /// <param name="blackboard">Extension blackboard.</param>
        /// <returns>The blackboard's add button element.</returns>
        public static VisualElement GetAddButton(this Blackboard blackboard)
        {
            return blackboard.Q(name: "addButton");
        }
    }
}