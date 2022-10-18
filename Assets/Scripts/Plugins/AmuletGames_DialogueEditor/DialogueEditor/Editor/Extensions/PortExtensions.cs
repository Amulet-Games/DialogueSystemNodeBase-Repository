using UnityEditor.Experimental.GraphView;

namespace AG
{
    public static class PortExtensions
    {
        /// <summary>
        /// Extension method that returns the port sibling index within its parent hierarchy.
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <returns>The sibling index of the port within its parent hierarchy.</returns>
        public static int GetSiblingIndex(this Port port) => port.parent.IndexOf(port);


        /// <summary>
        /// Extension method that returns the port sibling index within its parent hierarchy
        /// <br>combine with the specified amonut.</br>
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <returns>The sibling index of the port within its parent hierarchy.</returns>
        public static int GetSiblingIndexAdd(this Port port, int addingAmount) => port.parent.IndexOf(port) + addingAmount;


        /// <summary>
        /// Extension method that returns ture if the port's direction is equal to "Input".
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <returns>True if the port's direction is equal to "Input".</returns>
        public static bool IsInput(this Port port) => port.direction == Direction.Input;


        /// <summary>
        /// Extension method that returns ture if the port's capacity is equal to "Single".
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <returns>True if the port's capacity is equal to "Single".</returns>
        public static bool IsSingle(this Port port) => port.capacity == Port.Capacity.Single;
    }
}