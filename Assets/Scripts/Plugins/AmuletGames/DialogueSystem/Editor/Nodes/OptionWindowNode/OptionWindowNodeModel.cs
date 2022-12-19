namespace AG.DS
{
    /// <inheritdoc />
    public class OptionWindowNodeModel : NodeModelBase
    {
        /// <summary>
        /// A special output port that'll only make connections if the other port is from the same channel.
        /// </summary>
        public SingleOptionChannel OutputSingleOptionChannel;


        /// <summary>
        /// A group of speical ports that'll only make connections if the other port is from the same channel.
        /// </summary>
        public MultiOptionChannelGroup OutputMultiOptionChannelGroup;


        /// <summary>
        /// Text container for the header text.
        /// </summary>
        public LanguageTextContainer HeaderTextContainer;


        /// <summary>
        /// Holds the text field for the dialogue text, text field for speaker's name and
        /// <br>a object field for the dialogue's audio. (Language dependent)</br>
        /// </summary>
        public DialogueSegment DialogueSegment;


        // ----------------------------- Ports -----------------------------
        /// <summary>
        /// Port that allows other nodes to connect to this node.
        /// </summary>
        public DefaultPort InputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of the option window node model module class.
        /// </summary>
        /// <param name="node">The connecting node to set for.</param>
        public OptionWindowNodeModel(OptionWindowNode node)
        {
            OutputSingleOptionChannel = new(isOutput: true);
            OutputMultiOptionChannelGroup = new(node: node, isOutput: true);
            HeaderTextContainer = new();
            DialogueSegment = new();
        }
    }
}
