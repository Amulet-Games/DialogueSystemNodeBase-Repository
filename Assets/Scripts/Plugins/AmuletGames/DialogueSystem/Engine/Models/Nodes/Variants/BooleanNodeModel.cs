using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class BooleanNodeModel : NodeModelBase
    {
        /// <summary>
        /// The node's input port model.
        /// </summary>
        [SerializeField] public PortModelBase InputPortModel;


        /// <summary>
        /// The node's true output port model.
        /// </summary>
        [SerializeField] public PortModelBase TrueOutputPortModel;


        /// <summary>
        /// The node's false output port model.
        /// </summary>
        [SerializeField] public PortModelBase FalseOutputPortModel;


        /// <summary>
        /// The node's true output port opponent node's GUID value.
        /// </summary>
        [SerializeField] public string TrueOutputOpponentNodeGUID;


        /// <summary>
        /// The node's false output port opponent node's GUID value.
        /// </summary>
        [SerializeField] public string FalseOutputOpponentNodeGUID;


        /// <summary>
        /// The node's boolean node stitcher model.
        /// </summary>
        [SerializeField] public BooleanNodeStitcherModel BooleanNodeStitcherModel;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node model class.
        /// </summary>
        public BooleanNodeModel()
        {
            InputPortModel = new();
            TrueOutputPortModel = new();
            FalseOutputPortModel = new();
            BooleanNodeStitcherModel = new();
        }
    }
}