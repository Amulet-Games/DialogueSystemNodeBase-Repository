using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPortModel : PortModel
    {
        /// <summary>
        /// True if the port belongs to a group.
        /// </summary>
        public bool IsGroup;


        /// <inheritdoc />
        public OptionPortModel
        (
            Port port,
            Direction direction,
            Capacity capacity,
            string name,
            bool isGroup
        )
            : base(port, direction, capacity, name)
        {
            IsGroup = isGroup;
        }
    }
}