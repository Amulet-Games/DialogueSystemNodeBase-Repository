using System;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    [Serializable]
    public class DSBranchNodeModel : DSNodeModelBase
    {
        //TODO Move this to another data class!
        // ----------------------------- Serialized Port Guid -----------------------------
        /// <summary>
        /// The serialized "Input" port's Guid id in this node.
        /// </summary>
        public string SavedInputPortGuid;


        /// <summary>
        /// The serialized "True Output" port's Guid id in this node.
        /// </summary>
        public string SavedTrueOutputPortGuid;


        /// <summary>
        /// The serialized "False Output" port's Guid id in this node.
        /// </summary>
        public string SavedFalseOutputPortGuid;


        // ----------------------------- Serialized Node Guid -----------------------------
        /// <summary>
        /// The serialized opponent's node's Guid Id in which is connected with this node by "True Output" port.
        /// </summary>
        public string SavedTrueInputNodeGuid;


        /// <summary>
        /// The serialized opponent's node's Guid Id in which is connected with this node by "False Output" port.
        /// </summary>
        public string SavedFalseInputNodeGuid;


        // ----------------------------- Model's Elements -----------------------------
        /// <summary>
        /// A special node's UI style that combined the use of segment, modifier and content button together.
        /// </summary>
        public ConditionMolder ConditionMolder;


        // ----------------------------- Model's Ports -----------------------------
        /// <summary>
        /// Port that allows the other nodes to connect to this node.
        /// </summary>
        public Port InputPort;


        /// <summary>
        /// Port that allows this node to branch out and move on from the "True" marked branch.
        /// </summary>
        public Port TrueOutputPort;


        /// <summary>
        /// Port that allows this node to branch out and move on from the "False" marked branch.
        /// </summary>
        public Port FalseOutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Construtor of branch node's model.
        /// </summary>
        public DSBranchNodeModel()
        {
            ConditionMolder = new ConditionMolder();
        }
    }
}
