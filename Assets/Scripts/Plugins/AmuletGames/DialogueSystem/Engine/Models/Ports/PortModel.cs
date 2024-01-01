using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    /// <summary>
    /// Holds the raw data that can be used when creating a new port.
    /// </summary>
    public class PortModel
    {
        public enum Port
        {
            Default = 0,

            Option = 1
        }

        /// <summary>
        /// The type of the port.
        /// </summary>
        public Port PortType { get; private set; }


        /// <summary>
        /// The direction of the port.
        /// </summary>
        public Direction Direction { get; private set; }


        /// <summary>
        /// The capacity of the port.
        /// </summary>
        public Capacity Capacity { get; private set; }


        /// <summary>
        /// The name of the port.
        /// </summary>
        public string Name { get; private set; }


        public Color Color { get; private set; }


        /// <summary>
        /// Constructor of the port create detail base class.
        /// </summary>
        /// <param name="port">The port type to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="capacity">The capacity to set for.</param>
        /// <param name="name">The name to set for.</param>
        /// <param name="color">The color to set for.</param>
        public PortModel
        (
            Port port,
            Direction direction,
            Capacity capacity,
            string name,
            Color color
        )
        {
            PortType = port;
            Direction = direction;
            Capacity = capacity;
            Name = name;
            Color = color;
        }
    }
}