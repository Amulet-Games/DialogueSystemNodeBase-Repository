namespace AG.DS
{
    /// <inheritdoc />
    public class OptionTrackNodeModel : NodeModelBase
    {
        /// <summary>
        /// A special input port that'll only make connections if the other port is from the same channel.
        /// </summary>
        public SingleOptionChannel InputSingleOptionChannel;


        /// <summary>
        /// Text container for the header text.
        /// </summary>
        public LanguageTextContainer HeaderTextContainer;


        /// <summary>
        /// Holds a group of conditions that needs to be true in order to pass this node.
        /// </summary>
        public ConditionSegment ConditionSegment;


        // ----------------------------- Ports -----------------------------
        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public DefaultPort OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of the option track node model module class.
        /// </summary>
        /// <param name="node">The connecting node to set for.</param>
        public OptionTrackNodeModel(OptionTrackNode node)
        {
            InputSingleOptionChannel = new(isOutput: false);
            HeaderTextContainer = new();
            ConditionSegment = new();
        }
    }
}
