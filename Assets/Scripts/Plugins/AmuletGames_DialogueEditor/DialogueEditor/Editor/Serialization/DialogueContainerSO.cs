using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    [CreateAssetMenu(menuName = "Dialogue/New Dialogue Container SO")]
    public class DialogueContainerSO : ScriptableObject
    {
        /// <summary>
        /// List of saved edge models.
        /// </summary>
        public List<DSEdgeModel> EdgeModelSavables = new List<DSEdgeModel>();


        /// <summary>
        /// List of saved boolean node models.
        /// </summary>
        public List<DSBooleanNodeModel> BooleanModelSavables = new List<DSBooleanNodeModel>();


        /// <summary>
        /// List of saved end node models.
        /// </summary>
        public List<DSEndNodeModel> EndModelSavables = new List<DSEndNodeModel>();


        /// <summary>
        /// List of saved event node models.
        /// </summary>
        public List<DSEventNodeModel> EventModelSavables = new List<DSEventNodeModel>();


        /// <summary>
        /// List of saved option node models.
        /// </summary>
        public List<DSOptionNodeModel> OptionModelSavables = new List<DSOptionNodeModel>();


        /// <summary>
        /// List of saved path node models.
        /// </summary>
        public List<DSPathNodeModel> PathModelSavables = new List<DSPathNodeModel>();


        /// <summary>
        /// List of saved start node models.
        /// </summary>
        public List<DSStartNodeModel> StartModelSavables = new List<DSStartNodeModel>();


        /// <summary>
        /// List of saved story node models.
        /// </summary>
        public List<DSStoryNodeModel> StoryModelSavables = new List<DSStoryNodeModel>();


        // ----------------------------- Get Node Savables Services -----------------------------
        /// <summary>
        /// Get all the node model savables from the scriptable asset.
        /// </summary>
        /// <returns>A new list that have combined all saved node's models from the asset.</returns>
        public List<DSNodeModelBase> GetNodeSavables()
        {
            List<DSNodeModelBase> allModelSavables = new List<DSNodeModelBase>();

            allModelSavables.AddRange(BooleanModelSavables);
            allModelSavables.AddRange(EndModelSavables);
            allModelSavables.AddRange(EventModelSavables);
            allModelSavables.AddRange(OptionModelSavables);
            allModelSavables.AddRange(PathModelSavables);
            allModelSavables.AddRange(StartModelSavables);
            allModelSavables.AddRange(StoryModelSavables);

            return allModelSavables;
        }


        // ----------------------------- Clear Node Savables Services -----------------------------
        /// <summary>
        /// Clear all the node savables inside the scriptable asset.
        /// </summary>
        public void ClearNodeSavables()
        {
            BooleanModelSavables.Clear();
            EndModelSavables.Clear();
            EventModelSavables.Clear();
            OptionModelSavables.Clear();
            PathModelSavables.Clear();
            StartModelSavables.Clear();
            StoryModelSavables.Clear();
        }
    }
}