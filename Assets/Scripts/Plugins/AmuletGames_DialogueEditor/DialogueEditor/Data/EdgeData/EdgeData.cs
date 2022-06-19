using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class EdgeData
    {
        [Header("Nodes Guid")]
        public string outputNodeGuid;           // output node is the base node where this edge originate from.
        public string inputNodeGuid;            // input node is the target node where this edge connects to.

        [Header("Ports Guid")]
        public string outputPortGuid;           // output port is the port that this edge started.
        public string inputPortGuid;            // output port is the port that this edge connects to.
    }
}