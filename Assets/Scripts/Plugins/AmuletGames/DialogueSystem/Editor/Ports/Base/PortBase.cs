using System;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public abstract class PortBase : Port
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the port base class.
        /// </summary>
        /// <param name="orientation">Vertical or horizontal.</param>
        /// <param name="direction">Input or output.</param>
        /// <param name="capacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        protected PortBase
        (
            Orientation orientation,
            Direction direction,
            Capacity capacity,
            Type type
        )
            : base(orientation, direction, capacity, type)
        {
        }


        // ----------------------------- Disconnect -----------------------------
        /// <summary>
        /// Disconnect any edges.
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public abstract void Disconnect(GraphViewer graphViewer);
    }
}