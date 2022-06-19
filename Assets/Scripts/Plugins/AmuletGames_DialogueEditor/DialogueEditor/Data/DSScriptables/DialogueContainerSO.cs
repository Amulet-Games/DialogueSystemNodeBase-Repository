using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace AG
{
    [CreateAssetMenu(menuName = "Dialogue/New Dialogue Container")]
    public class DialogueContainerSO : ScriptableObject
    {
        public List<EdgeData> edgeSavables = new List<EdgeData>();

        public List<StartNodeData> startNodeSavables = new List<StartNodeData>();

        public List<DialogueNodeData> dialogueNodeSavables = new List<DialogueNodeData>();

        public List<ChoiceNodeData> choiceNodeSavables = new List<ChoiceNodeData>();

        public List<EventNodeData> eventNodeSavables = new List<EventNodeData>();

        public List<BranchNodeData> branchNodeSavables = new List<BranchNodeData>();

        public List<EndNodeData> endNodeSavables = new List<EndNodeData>();

        public List<BaseNodeData> GetAllSavables
        {
            get
            {
                List<BaseNodeData> allNodeDataSavables = new List<BaseNodeData>();

                allNodeDataSavables.AddRange(startNodeSavables);
                allNodeDataSavables.AddRange(dialogueNodeSavables);
                allNodeDataSavables.AddRange(choiceNodeSavables);
                allNodeDataSavables.AddRange(eventNodeSavables);
                allNodeDataSavables.AddRange(branchNodeSavables);
                allNodeDataSavables.AddRange(endNodeSavables);

                return allNodeDataSavables;
            }
        }
    }
}