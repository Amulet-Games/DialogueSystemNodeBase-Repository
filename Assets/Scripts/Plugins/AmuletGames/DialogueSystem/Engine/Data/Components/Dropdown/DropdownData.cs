using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class DropdownData
    {
        /// <summary>
        /// The dropdown's selected dropdown item array index.
        /// </summary>
        [SerializeField] public int selectedItemIndex;
    }
}