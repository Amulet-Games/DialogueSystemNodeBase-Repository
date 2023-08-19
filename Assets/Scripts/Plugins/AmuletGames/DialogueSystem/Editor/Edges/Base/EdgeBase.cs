using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <summary>
    /// The graph view edge element.
    /// </summary>
    public abstract class EdgeBase : Edge
    {
        /// <summary>
        /// Reference of the edge callback.
        /// </summary>
        public IEdgeCallback Callback;
    }
}