using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class StartNodeData : BaseNodeData
    {
        [Header("Port Guid")]
        public string outputPortGuid;
    }
}
