using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierData
    {
        /// <summary>
        /// The data's folder data.
        /// </summary>
        [SerializeField] public FolderData FolderData;


        /// <summary>
        /// The data's dialogue event value.
        /// </summary>
        [SerializeField] public DialogueEvent DialogueEventData;


        /// <summary>
        /// The data's delay seconds integer value.
        /// </summary>
        [SerializeField] public int DelaySecondsIntegerData;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event modifier data class.
        /// </summary>
        public EventModifierData()
        {
            FolderData = new();
        }
    }
}