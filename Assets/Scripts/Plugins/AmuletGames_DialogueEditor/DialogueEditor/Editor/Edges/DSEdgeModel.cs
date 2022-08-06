using System;

namespace AG
{
    [Serializable]
    public class DSEdgeModel
    {
        // ----------------------------- Serialized Port Guid -----------------------------
        /// <summary>
        /// Output port is where the edge starts.
        /// </summary>
        public string OutputPortGuid;


        /// <summary>
        /// Input port is where the edge ends.
        /// </summary>
        public string InputPortGuid;


        // ----------------------------- Serialized Node Guid -----------------------------
        /// <summary>
        /// Output node is the base node where the edge is originate from.
        /// </summary>
        public string OutputNodeGuid;


        /// <summary>
        /// Input node is the target node where the edge is connect to.
        /// </summary>
        public string InputNodeGuid;
    }
}