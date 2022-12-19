using UnityEditor.Experimental.GraphView;

namespace AG.DS
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
        /// <br>combine with the given additional number.</br>
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <param name="addByNumber">The number to combine with the port sibling index.</param>
        /// <returns>The sibling index of the port within its parent hierarchy.</returns>
        public static int GetSiblingIndexAdd(this Port port, int addByNumber) =>
            port.parent.IndexOf(port) + addByNumber;


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