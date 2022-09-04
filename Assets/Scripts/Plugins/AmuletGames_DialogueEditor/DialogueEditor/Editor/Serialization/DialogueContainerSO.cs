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
        /// List of saved start node models.
        /// </summary>
        public List<DSStartNodeModel> StartModelSavables = new List<DSStartNodeModel>();


        /// <summary>
        /// List of saved dialogue node models.
        /// </summary>
        public List<DSDialogueNodeModel> DialogueModelSavables = new List<DSDialogueNodeModel>();


        /// <summary>
        /// List of saved option node models.
        /// </summary>
        public List<DSOptionNodeModel> OptionModelSavables = new List<DSOptionNodeModel>();


        /// <summary>
        /// List of saved event node models.
        /// </summary>
        public List<DSEventNodeModel> EventModelSavables = new List<DSEventNodeModel>();


        /// <summary>
        /// List of saved branch node models.
        /// </summary>
        public List<DSBranchNodeModel> BranchModelSavables = new List<DSBranchNodeModel>();


        /// <summary>
        /// List of saved end node models.
        /// </summary>
        public List<DSEndNodeModel> EndModelSavables = new List<DSEndNodeModel>();


        // ----------------------------- Get Savables Services -----------------------------
        /// <summary>
        /// Get all the node's model savables from the asset.
        /// </summary>
        /// <returns>A new list that have combined all saved node's models from the asset.</returns>
        public List<DSNodeModelBase> GetAllModelSavables()
        {
            List<DSNodeModelBase> allModelSavables = new List<DSNodeModelBase>();

            allModelSavables.AddRange(StartModelSavables);
            allModelSavables.AddRange(DialogueModelSavables);
            allModelSavables.AddRange(OptionModelSavables);
            allModelSavables.AddRange(EventModelSavables);
            allModelSavables.AddRange(BranchModelSavables);
            allModelSavables.AddRange(EndModelSavables);

            return allModelSavables;
        }
    }
}