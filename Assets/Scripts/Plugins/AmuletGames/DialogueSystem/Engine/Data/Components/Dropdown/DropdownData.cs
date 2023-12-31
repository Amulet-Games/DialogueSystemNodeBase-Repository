using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class DropdownData
    {
        /// <summary>
        /// The dropdown's selected dropdown element array index.
        /// </summary>
        [SerializeField] public int selectedElementIndex;
    }
}