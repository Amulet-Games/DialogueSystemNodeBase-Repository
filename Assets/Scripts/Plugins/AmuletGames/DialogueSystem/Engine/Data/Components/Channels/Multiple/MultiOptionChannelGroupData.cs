using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class MultiOptionChannelGroupData
    {
        /// <summary>
        /// The data's multi option channel data list.
        /// </summary>
        [SerializeField] public List<MultiOptionChannelData> ChannelDataList;


        /// <summary>
        /// The data's multi option channel data list count.
        /// </summary>
        [SerializeField] public int ChannelDataListCount;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the multi option channel group data class.
        /// </summary>
        public MultiOptionChannelGroupData()
        {
            ChannelDataList = new();
            ChannelDataListCount = 0;
        }
    }
}