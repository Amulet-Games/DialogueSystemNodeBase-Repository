using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortGroupCellModel
    {
        /// <summary>
        /// The cell's option port model.
        /// </summary>
        [SerializeField] public OptionPortModel OptionPortModel;


        /// <summary>
        /// Constructor of the option port group cell model class.
        /// </summary>
        public OptionPortGroupCellModel()
        {
        }
    }
}