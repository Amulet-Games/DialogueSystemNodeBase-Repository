using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class EndNodeData : BaseNodeData
    {
        [Header("Port Guid")]
        public string inputPortGuid;

        [Header("Container")]
        public DialogueOverHandleTypeEnumContainer graphEndHandleType_EnumContainer = new DialogueOverHandleTypeEnumContainer();
    }
}