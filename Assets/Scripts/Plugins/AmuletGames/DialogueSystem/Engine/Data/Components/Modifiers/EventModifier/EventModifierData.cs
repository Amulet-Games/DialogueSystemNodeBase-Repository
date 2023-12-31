using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierData
    {
        /// <summary>
        /// The modifier's folder data.
        /// </summary>
        [SerializeField] public FolderData FolderData;


        /// <summary>
        /// The modifier's dialogue event value.
        /// </summary>
        [SerializeField] public DialogueEvent DialogueEvent;


        /// <summary>
        /// The modifier's delay seconds value.
        /// </summary>
        [SerializeField] public float DelaySeconds;


        /// <summary>
        /// Constructor of the event modifier data class.
        /// </summary>
        public EventModifierData()
        {
            FolderData = new();
        }
    }
}