using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class RadioGroupData
    {
        /// <summary>
        /// The group's active radio element array index.
        /// </summary>
        [SerializeField] public int activeRadioIndex;
    }
}