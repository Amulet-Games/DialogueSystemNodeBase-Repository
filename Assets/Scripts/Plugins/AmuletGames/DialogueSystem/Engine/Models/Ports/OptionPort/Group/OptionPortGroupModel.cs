using System;
using System.Collections.Generic;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class OptionPortGroupModel
    {
        /// <summary>
        /// The group's option port group cell models.
        /// </summary>
        [SerializeField] public List<OptionPortGroupCellModel> cellModels;
        

        /// <summary>
        /// Constructor of the option port group model class.
        /// </summary>
        public OptionPortGroupModel()
        {
            cellModels = new();
        }
    }
}