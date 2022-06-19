using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class BranchNodeData : BaseNodeData
    {
        [Header("Port Guid")]
        public string inputPortGuid;
        public string trueOutputPortGuid;
        public string falseOutputPortGuid;

        [Header("Node Guid")]
        public string trueInputNodeGuid;
        public string falseInputNodeGuid;

        [Header("Modifier")]
        public List<DSModifierBase> all = new List<DSModifierBase>();
        public List<ConditionModifier> conditionModifiers = new List<ConditionModifier>();
    }
}
