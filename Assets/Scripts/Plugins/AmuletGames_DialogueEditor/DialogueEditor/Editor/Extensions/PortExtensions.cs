using UnityEditor.Experimental.GraphView;

namespace AG
{
    public static class PortExtensions
    {
        /// <summary>
        /// Extension method for getting the port sibling index within its parent.
        /// </summary>
        /// <param name="port">The target port to retrieve the index from.</param>
        /// <returns>The sibling index of the port within its parent's hierarchy.</returns>
        public static int GetSiblingIndex(this Port port) => port.parent.IndexOf(port);
    }
}