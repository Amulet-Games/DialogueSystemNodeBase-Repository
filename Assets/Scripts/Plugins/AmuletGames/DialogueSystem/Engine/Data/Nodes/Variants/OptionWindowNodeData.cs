using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class OptionWindowNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port GUID value.
        /// </summary>
        [SerializeField] public string InputPortGUID;


        /// <summary>
        /// The data's output single option channel data.
        /// </summary>
        [SerializeField] public SingleOptionChannelData OutputSingleOptionChannelData;

        
        /// <summary>
        /// The data's output multi option channel group data.
        /// </summary>
        [SerializeField] public MultiOptionChannelGroupData OutputMultiOptionChannelGroupData;


        /// <summary>
        /// The data's header's language generic value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> HeaderLanguageGeneric;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option window node data class.
        /// </summary>
        public OptionWindowNodeData()
        {
            OutputSingleOptionChannelData = new();
            OutputMultiOptionChannelGroupData = new();
            HeaderLanguageGeneric = new();
        }
    }
}