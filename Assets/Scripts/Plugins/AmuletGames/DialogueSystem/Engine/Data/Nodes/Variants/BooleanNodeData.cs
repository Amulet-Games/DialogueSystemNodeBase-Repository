using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class BooleanNodeData : NodeDataBase
    {
        /// <summary>
        /// The node's input port data.
        /// </summary>
        [SerializeField] public PortData InputPortData;


        /// <summary>
        /// The node's true output port data.
        /// </summary>
        [SerializeField] public PortData TrueOutputPortData;


        /// <summary>
        /// The node's false output port data.
        /// </summary>
        [SerializeField] public PortData FalseOutputPortData;


        /// <summary>
        /// The node's condition modifier group data.
        /// </summary>
        [SerializeField] public ConditionModifierViewGroupViewData ConditionModifierGroupData;


        /// <summary>
        /// Constructor of the boolean node data class.
        /// </summary>
        public BooleanNodeData()
        {
            InputPortData = new();
            TrueOutputPortData = new();
            FalseOutputPortData = new();
            ConditionModifierGroupData = new();
        }
    }
}