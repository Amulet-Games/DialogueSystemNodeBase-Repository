using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortGroupData
    {
        /// <summary>
        /// The group's items data.
        /// </summary>
        [SerializeField] public List<OptionPortGroupItemData> ItemsData;


        /// <summary>
        /// The group's first port cell data.
        /// </summary>
        [SerializeField] public OptionPortCellData FirstPortCellData;


        /// <summary>
        /// Constructor of the option port group data class.
        /// </summary>
        public OptionPortGroupData()
        {
            ItemsData = new();
            FirstPortCellData = new();
        }
    }
}