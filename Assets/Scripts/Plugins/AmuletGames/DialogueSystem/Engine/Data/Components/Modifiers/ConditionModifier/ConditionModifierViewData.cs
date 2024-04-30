using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class ConditionModifierViewData
    {
        /// <summary>
        /// The modifier's folder data.
        /// </summary>
        [SerializeField] public FolderData FolderData;


        /// <summary>
        /// The modifier's operation dropdown data.
        /// </summary>
        [SerializeField] public DropdownData OperationDropdownData;


        /// <summary>
        /// The modifier's chain with dropdown data.
        /// </summary>
        [SerializeField] public DropdownData ChainWithDropdownData;


        /// <summary>
        /// Constructor of the condition modifier view data class.
        /// </summary>
        public ConditionModifierViewData()
        {
            FolderData = new();
            OperationDropdownData = new();
            ChainWithDropdownData = new();
        }
    }
}