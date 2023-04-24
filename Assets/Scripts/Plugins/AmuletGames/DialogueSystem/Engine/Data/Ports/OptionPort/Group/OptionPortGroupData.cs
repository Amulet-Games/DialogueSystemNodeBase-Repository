using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortGroupData
    {
        [Serializable]
        public class CellData
        {
            /// <summary>
            /// The data's option port data.
            /// </summary>
            [SerializeField] public OptionPortData OptionPortData;


            // ----------------------------- Constructor -----------------------------
            /// <summary>
            /// Constructor of the option port group cell data class.
            /// </summary>
            public CellData()
            {
                OptionPortData = new();
            }
        }


        /// <summary>
        /// The data's option port group cell data.
        /// </summary>
        [SerializeField] public List<CellData> m_CellData;
        

        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option port group data class.
        /// </summary>
        public OptionPortGroupData()
        {
            m_CellData = new();
        }
    }
}