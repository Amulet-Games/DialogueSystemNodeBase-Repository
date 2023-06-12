namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeModel : NodeModelFrameBase
    {
        /// <summary>
        /// Model for the character scriptable object object field.
        /// </summary>
        public CommonObjectFieldModel<DialogueCharacter> CharacterObjectFieldModel;


        /// <summary>
        /// A special node's UI style that combined the use of segment, modifier and content button together.
        /// </summary>
        public MessageModifierModelGroup DialogueNodeStitcher;


        /// <summary>
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node model class.
        /// </summary>
        public DialogueNodeModel()
        {
            CharacterObjectFieldModel = new();
            DialogueNodeStitcher = new();
        }


        // ----------------------------- Remove Ports All -----------------------------
        /// <inheritdoc />
        public override void RemovePorts(GraphViewer graphViewer)
        {
            // Remove from graph viewer cache
            graphViewer.Remove(port: InputDefaultPort);
            graphViewer.Remove(port: OutputDefaultPort);

            // Disconnect each ports
            InputDefaultPort.Disconnect(graphViewer);
            OutputDefaultPort.Disconnect(graphViewer);
        }
    }
}