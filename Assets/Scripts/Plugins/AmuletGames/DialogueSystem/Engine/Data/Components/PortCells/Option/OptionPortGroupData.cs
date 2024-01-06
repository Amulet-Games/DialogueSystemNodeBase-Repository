using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortGroupData
    {
        /// <summary>
        /// The group's option port cells data.
        /// </summary>
        [SerializeField] public List<OptionPortCellData> GroupCellsData;


        /// <summary>
        /// The group's first port cell data.
        /// </summary>
        [SerializeField] public OptionPortCellData FirstPortCellData;


        /// <summary>
        /// Constructor of the option port group data class.
        /// </summary>
        public OptionPortGroupData()
        {
            GroupCellsData = new();
        }
    }
}