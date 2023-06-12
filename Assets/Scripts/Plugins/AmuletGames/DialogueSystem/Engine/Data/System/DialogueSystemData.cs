using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/New Dialogue System Data")]
    public class DialogueSystemData : ScriptableObject
    {
        [Space(5), Header("Readonly")]
        /// <summary>
        /// The asset instance id of the data.
        /// </summary>
        [ReadOnlyInspector] public int InstanceId = 0;


        [Space(5), Header("Customization")]
        /// <summary>
        /// The minimum size of the dialogue editor window when it's floating or modal.
        /// </summary>
        public Vector2 WindowMinSize = new(x: 200, y: 200);


        /// <summary>
        /// The size of the dialogue editor window when it's first opened.
        /// </summary>
        public Vector2 WindowStartSizeScreenRatio = new(x: 0.7f, y: 0.7f);


        [Space(5), Header("Data")]
        /// <summary>
        /// Edge data list.
        /// </summary>
        public List<EdgeDataBase> EdgeData;


        /// <summary>
        /// Node data list.
        /// </summary>
        public List<NodeDataBase> NodeData;


        // ----------------------------- Clear Data -----------------------------
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