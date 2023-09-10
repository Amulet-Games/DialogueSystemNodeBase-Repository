using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    /// <summary>
    /// Holds the raw data that can be used when creating a new port.
    /// </summary>
    public class PortCreateDetailBase
    {
        /// <summary>
        /// The creating port's type.
        /// </summary>
        public PortType PortType { get; private set; }

        /// <summary>
        /// The creating port's direction type.
        /// </summary>
        public Direction Direction { get; private set; }


        /// <summary>
        /// The creating port's capacity type.
        /// </summary>
        public Capacity Capacity { get; private set; }


        /// <summary>
        /// The creating port's name.
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// Constructor of the port create detail base class.
        /// </summary>
        /// <param name="portType">The port type to set for.</param>
        /// <param name="direction">The direction to set for.</param>
        /// <param name="capacity">The capacity to set for.</param>
        /// <param name="name">The name to set for.</param>
        public PortCreateDetailBase
        (
            PortType portType,
            Direction direction,
            Capacity capacity,
            string name
        )
        {
            PortType = portType;
            Direction = direction;
            Capacity = capacity;
            Name = name;
        }
    }
}