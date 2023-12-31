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
        [SerializeField] public PortDataBase InputPortData;


        /// <summary>
        /// The node's true output port data.
        /// </summary>
        [SerializeField] public PortDataBase TrueOutputPortData;


        /// <summary>
        /// The node's false output port data.
        /// </summary>
        [SerializeField] public PortDataBase FalseOutputPortData;


        /// <summary>
        /// The node's condition modifier group data.
        /// </summary>
        [SerializeField] public ConditionModifierGroupData ConditionModifierGroupData;


        /// <summary>
        /// Constructor of the boolean node data class.
        /// </summary>
        public BooleanNodeData()
        {
            ConditionModifierGroupData = new();
        }
    }
}