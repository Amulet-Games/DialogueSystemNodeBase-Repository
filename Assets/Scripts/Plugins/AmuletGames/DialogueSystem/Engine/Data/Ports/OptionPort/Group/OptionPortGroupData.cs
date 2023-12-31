using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortGroupData
    {
        /// <summary>
        /// The group's option port group cells data.
        /// </summary>
        [SerializeField] public List<OptionPortGroupCellData> GroupCellsData;
        

        /// <summary>
        /// Constructor of the option port group data class.
        /// </summary>
        public OptionPortGroupData()
        {
            GroupCellsData = new();
        }
    }
}