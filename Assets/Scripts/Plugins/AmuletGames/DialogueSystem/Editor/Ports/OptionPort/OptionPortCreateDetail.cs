using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionPortCreateDetail : PortCreateDetailBase
    {
        /// <summary>
        /// Is the creating port comes from the option port group.
        /// </summary>
        public bool IsGroup;


        /// <inheritdoc />
        public OptionPortCreateDetail
        (
            PortType portType,
            Direction direction,
            Port.Capacity capacity,
            string name,
            bool isGroup
        )
            : base(portType, direction, capacity, name)
        {
            IsGroup = isGroup;
        }
    }
}