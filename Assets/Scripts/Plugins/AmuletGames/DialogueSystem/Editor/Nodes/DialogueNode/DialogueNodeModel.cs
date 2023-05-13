namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeModel : NodeModelFrameBase<DialogueNode>
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
        /// Constructor of the dialogue node model module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        public DialogueNodeModel(DialogueNode node)
        {
            Node = node;
            CharacterObjectFieldModel = new();
            DialogueNodeStitcher = new();
        }


        // ----------------------------- Remove Cache Ports All -----------------------------
        /// <inheritdoc />
        public override void RemoveCachePortsAll()
        {
            var serializeHandler = Node.GraphViewer.SerializeHandler;
            serializeHandler.RemoveCachePort(port: InputDefaultPort);
            serializeHandler.RemoveCachePort(port: OutputDefaultPort);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            InputDefaultPort.Disconnect(Node.GraphViewer);
            OutputDefaultPort.Disconnect(Node.GraphViewer);
        }
    }
}