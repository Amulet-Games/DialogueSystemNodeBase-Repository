using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortGroupItemData
    {
        /// <summary>
        /// The item's option port cell data.
        /// </summary>
        [SerializeField] public OptionPortCellData OptionPortCellData;


        /// <summary>
        /// Constructor of the option port group item data class.
        /// </summary>
        public OptionPortGroupItemData()
        {
            OptionPortCellData = new();
        }
    }
}