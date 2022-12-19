namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodeModel : NodeModelBase
    {
        /// <summary>
        /// Holds the enum field that determines what to do with the dialogue when it reaches its end.
        /// </summary>
        public DialogueOverHandleTypeEnumContainer dialogueOverHandleType_EnumContainer;


        // ----------------------------- Ports -----------------------------
        /// <summary>
        /// Port that allows the other nodes to connect to this node.
        /// </summary>
        public DefaultPort InputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node model module class.
        /// </summary>
        /// <param name="node">The connecting node to set for.</param>
        public EndNodeModel(EndNode node)
        {
            dialogueOverHandleType_EnumContainer = new();
        }
    }
}