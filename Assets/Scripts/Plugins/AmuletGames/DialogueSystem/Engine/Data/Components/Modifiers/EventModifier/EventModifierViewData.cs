using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierViewData
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
        /// Constructor of the event modifier view data class.
        /// </summary>
        public EventModifierViewData()
        {
            FolderData = new();
        }
    }
}