using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class BooleanNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port GUID value.
        /// </summary>
        [SerializeField] public string InputPortGUID;


        /// <summary>
        /// The data's true output port's GUID value.
        /// </summary>
        [SerializeField] public string TrueOutputPortGUID;


        /// <summary>
        /// The data's false output port's GUID value.
        /// </summary>
        [SerializeField] public string FalseOutputPortGUID;


        /// <summary>
        /// The data's true output port opponent node's GUID value.
        /// </summary>
        [SerializeField] public string TrueOutputOpponentNodeGUID;


        /// <summary>
        /// The data's false output port opponent node's GUID value.
        /// </summary>
        [SerializeField] public string FalseOutputOpponentNodeGUID;


        /// <summary>
        /// The data's condition molder data.
        /// </summary>
        [SerializeField] public ConditionMolderData ConditionMolderData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node data class.
        /// </summary>
        public BooleanNodeData()
        {
            ConditionMolderData = new();
        }
    }
}