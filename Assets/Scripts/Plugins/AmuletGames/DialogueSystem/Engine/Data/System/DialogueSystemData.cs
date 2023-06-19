using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/New Dialogue System Data")]
    public class DialogueSystemData : ScriptableObject
    {
#if UNITY_EDITOR
        /// <summary>
        /// Is the dialogue editor window of the data has already been opened in the editor?
        /// </summary>
        [HideInInspector] public bool IsOpened = false;
#endif

        /// <summary>
        /// Edge data list.
        /// </summary>
        public List<EdgeDataBase> EdgeData;


        /// <summary>
        /// Node data list.
        /// </summary>
        public List<NodeDataBase> NodeData;


        /// <summary>
        /// Clear all the saved node data.
        /// </summary>
        public void ClearDataNode() => NodeData.Clear();


        /// <summary>
        /// Clear all saved edge data.
        /// </summary>
        public void ClearDataEdge() => EdgeData.Clear();
    }
}