using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortGroupCellData
    {
        /// <summary>
        /// The cell's option port data.
        /// </summary>
        [SerializeField] public OptionPortData OptionPortData;


        /// <summary>
        /// Constructor of the option port group cell data class.
        /// </summary>
        public OptionPortGroupCellData()
        {
        }
    }
}