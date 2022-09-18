using UnityEditor.Experimental.GraphView;

namespace AG
{
    public static class PortExtensions
    {
        /// <summary>
        /// Extension method for getting the port sibling index within its parent.
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <returns>The sibling index of the port within its parent's hierarchy.</returns>
        public static int GetSiblingIndex(this Port port) => port.parent.IndexOf(port);


        /// <summary>
        /// Extension method for getting the boolean value from the port that it's direction is input or not.
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <returns></returns>
        public static bool IsInput(this Port port) => port.direction == Direction.Input;
    }
}