using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class OptionTrackNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's output port GUID value.
        /// </summary>
        [SerializeField] public string OutputPortGUID;


        /// <summary>
        /// The data's input single option channel data.
        /// </summary>
        [SerializeField] public SingleOptionChannelData InputSingleOptionChannelData;

        
        /// <summary>
        /// The data's header's language generic value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> HeaderLanguageGeneric;


        /// <summary>
        /// The data's condition segment data.
        /// </summary>
        [SerializeField] public ConditionSegmentData ConditionSegmentData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option track node data class.
        /// </summary>
        public OptionTrackNodeData()
        {
            InputSingleOptionChannelData = new();
            HeaderLanguageGeneric = new();
            ConditionSegmentData = new();
        }
    }
}