using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [CreateAssetMenu(menuName = "Dialogue System/New Dialogue System Data")]
    public class DialogueSystemData : ScriptableObject
    {
        /// <summary>
        /// Edge data list.
        /// </summary>
        public List<EdgeData> EdgeData;


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
        /// Option track node data list.
        /// </summary>
        public List<OptionTrackNodeData> OptionTrackNodeData;


        /// <summary>
        /// Option window node data list.
        /// </summary>
        public List<OptionWindowNodeData> OptionWindowNodeData;


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


        // ----------------------------- Contructor -----------------------------
        /// <summary>
        /// Constructor of the dialogue system data class.
        /// </summary>
        public DialogueSystemData()
        {
            EdgeData = new();
            BooleanNodeData = new();
            DialogueNodeData = new();
            EndNodeData = new();
            EventNodeData = new();
            OptionTrackNodeData = new();
            OptionWindowNodeData = new();
            PreviewNodeData = new();
            StartNodeData = new();
            StoryNodeData = new();
        }


        // ----------------------------- Get Node Savables Services -----------------------------
        /// <summary>
        /// Get all the node model savables from the scriptable asset.
        /// </summary>
        /// <returns>A new list that have combined all saved node's models from the asset.</returns>
        public List<NodeDataBase> NodesData()
        {
            List<NodeDataBase> nodesData = new();

            nodesData.AddRange(BooleanNodeData);
            nodesData.AddRange(DialogueNodeData);
            nodesData.AddRange(EndNodeData);
            nodesData.AddRange(EventNodeData);
            nodesData.AddRange(OptionTrackNodeData);
            nodesData.AddRange(OptionWindowNodeData);
            nodesData.AddRange(PreviewNodeData);
            nodesData.AddRange(StartNodeData);
            nodesData.AddRange(StoryNodeData);

            return nodesData;
        }


        // ----------------------------- Clear Node Savables Services -----------------------------
        /// <summary>
        /// Clear all the node savables inside the scriptable asset.
        /// </summary>
        public void ClearNodesData()
        {
            BooleanNodeData.Clear();
            DialogueNodeData.Clear();
            EndNodeData.Clear();
            EventNodeData.Clear();
            OptionTrackNodeData.Clear();
            OptionWindowNodeData.Clear();
            PreviewNodeData.Clear();
            StartNodeData.Clear();
            StoryNodeData.Clear();
        }
    }
}