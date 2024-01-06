using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortCellData
    {
        /// <summary>
        /// The cell's option port data.
        /// </summary>
        [SerializeField] public OptionPortData OptionPortData;


        /// <summary>
        /// Constructor of the option port cell data class.
        /// </summary>
        public OptionPortCellData()
        {
            OptionPortData = new();
        }
    }
}