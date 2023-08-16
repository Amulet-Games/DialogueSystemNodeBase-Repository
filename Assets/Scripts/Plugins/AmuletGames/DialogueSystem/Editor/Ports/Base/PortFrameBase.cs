using System;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public abstract class PortFrameBase
    <
        TPortModel
    >
        : PortBase
        where TPortModel : PortModelBase
    {
        /// <summary>
        /// Constructor of the port frame base class.
        /// </summary>
        /// <param name="orientation">Vertical or horizontal.</param>
        /// <param name="direction">Input or output.</param>
        /// <param name="capacity">Support multiple or only single.</param>
        /// <param name="type">Port data type.</param>
        protected PortFrameBase
        (
            Orientation orientation,
            Direction direction,
            Capacity capacity,
            Type type
        )
            : base(orientation, direction, capacity, type)
        {
        }


        // ----------------------------- Serialization -----------------------------
        /// <summary>
        /// Save the port values.
        /// </summary>
        /// <param name="model">The port model to set for.</param>
        public abstract void Save(TPortModel model);


        /// <summary>
        /// Load the port values.
        /// </summary>
        /// <param name="model">The port model to set for.</param>
        public abstract void Load(TPortModel model);


        // ----------------------------- Service -----------------------------

    }
}