using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ConditionModifierModel
    {
        /// <summary>
        /// The modifier's folder model.
        /// </summary>
        [SerializeField] public FolderModel FolderModel;


        /// <summary>
        /// The modifier's operation dropdown model.
        /// </summary>
        [SerializeField] public DropdownModel OperationDropdownModel;


        /// <summary>
        /// The modifier's chain with dropdown model.
        /// </summary>
        [SerializeField] public DropdownModel ChainWithDropdownModel;


        /// <summary>
        /// Constructor of the condition modifier model class.
        /// </summary>
        public ConditionModifierModel()
        {
            FolderModel = new();
            OperationDropdownModel = new();
            ChainWithDropdownModel = new();
        }
    }
}