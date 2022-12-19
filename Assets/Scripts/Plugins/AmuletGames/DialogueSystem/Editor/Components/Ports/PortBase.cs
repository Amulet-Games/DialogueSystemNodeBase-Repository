using System;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public abstract class PortBase : Port
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the port element base class.
        /// </summary>
        /// <param name="portOrientation">Vertical or horizontal.</param>
        /// <param name="portDirection">Input or output.</param>
        /// <param name="portCapacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        protected PortBase
        (
            Orientation portOrientation,
            Direction portDirection,
            Capacity portCapacity,
            Type type
        )
            : base(portOrientation, portDirection, portCapacity, type)
        {
        }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Callback action when the port connections are loaded from serialize handler.
        /// <para>Note that calling this method from the output port is enough.</para>
        /// <br>Since the input port and output port shares the same edge calling it from both side is unnecessary.</br>
        /// </summary>
        /// <param name="edge">The edge to execute the action upon.</param>
        public abstract void ConnectionLoadedAction(Edge edge);
    }
}