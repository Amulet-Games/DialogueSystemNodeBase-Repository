using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <summary>
    /// The graph view edge element.
    /// </summary>
    public abstract class EdgeBase : Edge
    {
        /// <summary>
        /// The property of the edge callback reference.
        /// </summary>
        public IEdgeCallback Callback;
    }
}