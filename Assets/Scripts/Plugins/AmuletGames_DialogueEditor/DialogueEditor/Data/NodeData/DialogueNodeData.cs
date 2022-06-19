using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG
{
    [Serializable]
    public class DialogueNodeData : BaseNodeData
    {
        [Header("Port Guid")]
        public string inputPortGuid;
        public string continueOutputPortGuid;

        [Header("Segment")]
        public List<DSSegmentBase> all = new List<DSSegmentBase>();
        public List<ImagesPreviewSegment> imagesPreviewSegments = new List<ImagesPreviewSegment>();
        public List<SpeakerNameSegment> speakerNameSegments = new List<SpeakerNameSegment>();
        public List<TextlineSegment> textlineSegments = new List<TextlineSegment>();

        [Header("Node Entry")]
        public List<ChoiceEntry> choiceEntries = new List<ChoiceEntry>();
    }

    [Serializable]
    public class ChoiceEntry
    {
        public string portGuid;
        public string outputNodeGuid;
        public string inputNodeGuid;

        public void LoadEntryValue(ChoiceEntry source)
        {
            portGuid = source.portGuid;
            outputNodeGuid = source.outputNodeGuid;
            inputNodeGuid = source.inputNodeGuid;
        }
    }
}
