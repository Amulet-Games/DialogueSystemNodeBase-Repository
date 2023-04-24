using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "### AG ###/Dialogue System/New Dialogue System Data")]
    public class DialogueSystemData : ScriptableObject
    {
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
        /// Boolean node data list.
        /// </summary>
        public List<BooleanNodeData> BooleanNodeData;


        /// <summary>
        /// Dialogue node data list.
        /// </summary>
        public List<DialogueNodeData> DialogueNodeData;


        /// <summary>
        /// End node data list.
        /// </summary>
        public List<EndNodeData> EndNodeData;


        /// <summary>
        /// Event node data list.
        /// </summary>
        public List<EventNodeData> EventNodeData;


        /// <summary>
        /// Option branch node data list.
        /// </summary>
        public List<OptionBranchNodeData> OptionBranchNodeData;


        /// <summary>
        /// Option root node data list.
        /// </summary>
        public List<OptionRootNodeData> OptionRootNodeData;


        /// <summary>
        /// Preview node data list.
        /// </summary>
        public List<PreviewNodeData> PreviewNodeData;


        /// <summary>
        /// Start node data list.
        /// </summary>
        public List<StartNodeData> StartNodeData;


        /// <summary>
        /// Story node data list.
        /// </summary>
        public List<StoryNodeData> StoryNodeData;


        // ----------------------------- Get Data -----------------------------
        /// <summary>
        /// Return a list of all saved node data.
        /// </summary>
        /// <returns>A list of all saved node data.</returns>
        public List<NodeDataBase> GetDataNodes()
        {
            List<NodeDataBase> nodesData = new();

            nodesData.AddRange(BooleanNodeData);
            nodesData.AddRange(DialogueNodeData);
            nodesData.AddRange(EndNodeData);
            nodesData.AddRange(EventNodeData);
            nodesData.AddRange(OptionBranchNodeData);
            nodesData.AddRange(OptionRootNodeData);
            nodesData.AddRange(PreviewNodeData);
            nodesData.AddRange(StartNodeData);
            nodesData.AddRange(StoryNodeData);

            return nodesData;
        }


        // ----------------------------- Clear Data -----------------------------
        /// <summary>
        /// Clear all the saved node data.
        /// </summary>
        public void ClearDataNodes()
        {
            BooleanNodeData.Clear();
            DialogueNodeData.Clear();
            EndNodeData.Clear();
            EventNodeData.Clear();
            OptionBranchNodeData.Clear();
            OptionRootNodeData.Clear();
            PreviewNodeData.Clear();
            StartNodeData.Clear();
            StoryNodeData.Clear();
        }
    }
}