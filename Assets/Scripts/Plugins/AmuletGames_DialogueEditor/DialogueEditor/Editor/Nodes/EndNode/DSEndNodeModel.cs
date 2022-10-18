using System;

namespace AG
{
    [Serializable]
    public class DSEndNodeModel : DSNodeModelFrameBase<DSEndNode>
    {
        //TODO Move this to another data class!
        // ----------------------------- Serialized Port Guid -----------------------------
        /// <summary>
        /// The serialized "Input" port's Guid id in this node.
        /// </summary>
        public string SavedInputPortGuid;


        // ----------------------------- Model's Elements -----------------------------
        /// <summary>
        /// Holds the enum field that determines what to do with the dialogue when it reaches its end.
        /// </summary>
        public DialogueOverHandleTypeEnumContainer dialogueOverHandleType_EnumContainer;


        // ----------------------------- Model's Ports -----------------------------
        /// <summary>
        /// Port that allows the other nodes to connect to this node.
        /// </summary>
        public DSDefaultPort InputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of end node's model.
        /// </summary>
        public DSEndNodeModel(DSEndNode node)
        {
            Node = node;
            dialogueOverHandleType_EnumContainer = new DialogueOverHandleTypeEnumContainer();
        }
    }
}