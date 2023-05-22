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
        /// Constructor of the dialogue node model class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        public DialogueNodeModel(DialogueNode node)
        {
            Node = node;
            CharacterObjectFieldModel = new();
            DialogueNodeStitcher = new();
        }


        // ----------------------------- Remove Ports All -----------------------------
        /// <inheritdoc />
        public override void RemovePortsAll()
        {
            Node.GraphViewer.Remove(port: InputDefaultPort);
            Node.GraphViewer.Remove(port: OutputDefaultPort);
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