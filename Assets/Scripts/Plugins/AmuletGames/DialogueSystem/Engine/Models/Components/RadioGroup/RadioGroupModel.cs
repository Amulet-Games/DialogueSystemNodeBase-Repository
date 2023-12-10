using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class RadioGroupModel
    {
        /// <summary>
        /// The group's active radio element array index.
        /// </summary>
        [SerializeField] public int activeRadioIndex;
    }
}