using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierData : ModifierDataBase
    {
        /// <summary>
        /// The data's dialogue event value.
        /// </summary>
        [SerializeField] public DialogueEvent DialogueEvent;
    }
}