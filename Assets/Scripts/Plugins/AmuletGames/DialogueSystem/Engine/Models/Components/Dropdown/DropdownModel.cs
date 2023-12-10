using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class DropdownModel
    {
        /// <summary>
        /// The model's selected dropdown element array index.
        /// </summary>
        [SerializeField] public int selectedElementIndex;
    }
}