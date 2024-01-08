using System;
using System.Collections.Generic;

namespace AG.DS
{
    [Serializable]
    public class DialogueSystemWindowData
    {
        /// <summary>
        /// The edges data cache.
        /// </summary>
        public List<EdgeData> EdgesData = new();


        /// <summary>
        /// The nodes data cache.
        /// </summary>
        public List<NodeDataBase> NodesData = new();


        /// <summary>
        /// Clear the nodes data cache.
        /// </summary>
        public void ClearNodesData() => NodesData.Clear();


        /// <summary>
        /// Clear the edges data cache.
        /// </summary>
        public void ClearEdgesData() => EdgesData.Clear();
    }
}