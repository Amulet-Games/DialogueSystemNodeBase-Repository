namespace AG.DS
{
    /// <inheritdoc />
    public class DialogueNodeModel : NodeModelBase
    {
        /// <summary>
        /// Port that allows the other nodes to connect to this node.
        /// </summary>
        public DefaultPort InputPort;


        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public DefaultPort OutputPort;


        /// <summary>
        /// Object conatiner for the dialogue system's character scriptable object.
        /// </summary>
        public ObjectContainer<DialogueCharacter> CharacterObjectContainer;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue node model module class.
        /// </summary>
        public DialogueNodeModel()
        {
            CharacterObjectContainer = new();
        }
    }
}