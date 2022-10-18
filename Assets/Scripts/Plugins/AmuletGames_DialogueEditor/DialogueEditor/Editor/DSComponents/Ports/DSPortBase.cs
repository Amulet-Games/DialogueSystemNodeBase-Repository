using System;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    public abstract class DSPortBase : Port
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of dialogue system's port base.
        /// </summary>
        /// <param name="portOrientation">Vertical or horizontal.</param>
        /// <param name="portDirection">Input or output.</param>
        /// <param name="portCapacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        protected DSPortBase(Orientation portOrientation, Direction portDirection, Capacity portCapacity, Type type)
            : base(portOrientation, portDirection, portCapacity, type) { }


        // ----------------------------- Post Setup -----------------------------
        /// <summary>
        /// Callback action when the port connected state is loaded and the result 
        /// <br>connecting edge has setup actions to execute afterward.</br>
        /// <para>Note that calling this method from the output port is enough.</para>
        /// <br>Since the input port and output port are sharing the same edge,</br>
        /// <br>calling it from both side will often be unnecessary.</br>
        /// </summary>
        /// <param name="edge">The edge to execute the action upon.</param>
        public abstract void ConnectedEdgeLoadedAction(Edge edge);
    }
}