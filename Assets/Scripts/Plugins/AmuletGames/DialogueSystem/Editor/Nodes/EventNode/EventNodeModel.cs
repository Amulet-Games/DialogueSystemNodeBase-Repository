namespace AG.DS
{
    /// <inheritdoc />
    public class EventNodeModel : NodeModelBase
    {
        /// <summary>
        /// A special node's UI style that combined the use of segment, modifier and content button together.
        /// </summary>
        public EventMolder EventMolder;


        // ----------------------------- Ports -----------------------------
        /// <summary>
        /// Port that allows the other nodes to connect to this node.
        /// </summary>
        public DefaultPort InputPort;


        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public DefaultPort OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node's model module class.
        /// </summary>
        public EventNodeModel()
        {
            EventMolder = new();
        }
    }
}
