using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class EventNodeData : BaseNodeData
    {
        [Header("Port Guid")]
        public string inputPortGuid;
        public string outputPortGuid;

        [Header("Modifier")]
        public List<DSModifierBase> all = new List<DSModifierBase>();
        public List<BasicEventModifier> basicEventModifiers = new List<BasicEventModifier>();
        public List<ScriptableEventModifier> scriptableEventModifiers = new List<ScriptableEventModifier>();
    }
}
