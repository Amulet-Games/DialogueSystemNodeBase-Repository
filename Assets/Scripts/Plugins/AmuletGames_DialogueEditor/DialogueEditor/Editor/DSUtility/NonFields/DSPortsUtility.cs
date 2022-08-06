using UnityEngine;

namespace AG
{
    public class DSPortsUtility
    {
        /// <summary>
        /// Get the port's color value by specifing which type of node is it from.
        /// </summary>
        /// <param name="nodeType">The node's type of the port originated from.</param>
        /// <returns>The rgb color value of the port in the specified node.</returns>
        public static Color GetPortColorByNodeType(N_NodeType nodeType)
        {
            switch (nodeType)
            {
                case N_NodeType.Start:
                    return new Color(0.373f, 0.7f, 0.415f);
                case N_NodeType.End:
                    return new Color(0.341f, 0.504f, 0.934f);
                case N_NodeType.Dialogue:
                    return new Color(1, 0.36f, 0.36f);
                case N_NodeType.Choice:
                    return new Color(.404f, 0.706f, 0.663f);
                case N_NodeType.Branch:
                    return new Color(0.6f, 0.613f, 0.282f);
                case N_NodeType.Event:
                    return new Color(0.858f, 0.521f, 0.297f);
                default:
                    return new Color(0f, 0, 0f);
            }
        }
    }
}