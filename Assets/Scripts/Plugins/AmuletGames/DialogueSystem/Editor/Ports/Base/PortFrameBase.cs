using System;
using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    public abstract class PortFrameBase
    <
        TPortData
    >
        : PortBase
        where TPortData : PortDataBase
    {
        // ----------------------------- Constructor -----------------------------
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
        /// Save the port values to the given data.
        /// </summary>
        /// <param name="data">The data to save to.</param>
        public abstract void Save(TPortData data);


        /// <summary>
        /// Load the port values from the given data.
        /// </summary>
        /// <param name="data">The data to load from.</param>
        public abstract void Load(TPortData data);
    }
}