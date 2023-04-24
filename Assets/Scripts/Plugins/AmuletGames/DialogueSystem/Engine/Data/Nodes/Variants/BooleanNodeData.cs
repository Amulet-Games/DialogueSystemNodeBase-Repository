using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class BooleanNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port data.
        /// </summary>
        [SerializeField] public PortDataBase InputPortData;


        /// <summary>
        /// The data's true output port data.
        /// </summary>
        [SerializeField] public PortDataBase TrueOutputPortData;


        /// <summary>
        /// The data's false output port data.
        /// </summary>
        [SerializeField] public PortDataBase FalseOutputPortData;


        /// <summary>
        /// The data's true output port opponent node's GUID value.
        /// </summary>
        [SerializeField] public string TrueOutputOpponentNodeGUID;


        /// <summary>
        /// The data's false output port opponent node's GUID value.
        /// </summary>
        [SerializeField] public string FalseOutputOpponentNodeGUID;


        /// <summary>
        /// The data's boolean node stitcher data.
        /// </summary>
        [SerializeField] public BooleanNodeStitcherData BooleanNodeStitcherData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node data class.
        /// </summary>
        public BooleanNodeData()
        {
            InputPortData = new();
            TrueOutputPortData = new();
            FalseOutputPortData = new();
            BooleanNodeStitcherData = new();
        }
    }
}