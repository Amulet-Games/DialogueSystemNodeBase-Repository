using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public static class PortExtensions
    {
        /// <summary>
        /// Returns the child index of the port.
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <param name="additionNumber">An additional number that it can be used to combine with the result.</param>
        /// <returns>The sibling index of the port within its parent hierarchy.</returns>
        public static int GetSiblingIndex
        (
            this Port port,
            int additionNumber = 1
        )
        {
            return port.parent.IndexOf(port) + additionNumber;
        }


        /// <summary>
        /// Returns true if the port's direction is input.
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <returns>True if the port's direction is input.</returns>
        public static bool IsInput(this Port port)
        {
            return port.direction == Direction.Input;
        }


        /// <summary>
        /// Returns true if the port's capacity is single.
        /// </summary>
        /// <param name="port">Extension port</param>
        /// <returns>True if the port's capacity is single.</returns>
        public static bool IsSingle(this Port port)
        {
            return port.capacity == Port.Capacity.Single;
        }


        /// <summary>
        /// Returns true if the port is added to the connect style.
        /// </summary>
        /// <param name="port">Extension port.</param>
        /// <returns>True if the port is added to the connect style.</returns>
        public static bool IsConnectStyle(this Port port)
        {
            return port.ClassListContains(StyleConfig.Port_Connect);
        }
    }
}