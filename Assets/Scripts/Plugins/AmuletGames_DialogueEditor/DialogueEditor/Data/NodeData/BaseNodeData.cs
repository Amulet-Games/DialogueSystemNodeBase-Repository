using System;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class BaseNodeData
    {
        [Header("Base Details")]
        public string nodeGuid;
        public Vector2 position;
    }
}
