using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    using DS;

    public class DialogueUtility : MonoBehaviour
    {
        //[Header("Dialogue Container (Drops).")]
        //public DialogueContainerSO containerSO;

        //public BaseNodeData GetFirstNodeDataAfterStart()
        //{
        //    return GetNextNodeData(containerSO.startNodeDataSavables[0]);
        //}

        //public BaseNodeData GetNodeDataByGuid(string _nodeDataGuid)
        //{
        //    return containerSO.AllNodeDataSavables.Find(node => node.nodeGuid == _nodeDataGuid);
        //}

        //public BaseNodeData GetChoiceLinkedInputNodeData(ChoiceData _choiceData)
        //{
        //    return containerSO.AllNodeDataSavables.Find(node => node.nodeGuid == _choiceData.inputGuid);
        //}

        //public BaseNodeData GetNextNodeData(BaseNodeData _currentNodeData)
        //{
        //    NodeEdgeData nodeEdgeData = containerSO.nodeEdgeDataSavables.Find(edge => edge.outputNodeGuid == _currentNodeData.nodeGuid);

        //    return GetNodeDataByGuid(nodeEdgeData.inputNodeGuid);
        //}
    }
}