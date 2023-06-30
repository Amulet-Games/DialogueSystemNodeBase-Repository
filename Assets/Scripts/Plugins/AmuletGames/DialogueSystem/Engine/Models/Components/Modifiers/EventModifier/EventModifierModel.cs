using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class EventModifierModel
    {
        /// <summary>
        /// The modifier's folder model.
        /// </summary>
        [SerializeField] public FolderModel FolderModel;


        /// <summary>
        /// The modifier's dialogue event value.
        /// </summary>
        [SerializeField] public DialogueEvent DialogueEvent;


        /// <summary>
        /// The modifier's delay seconds integer value.
        /// </summary>
        [SerializeField] public int DelaySecondsInteger;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event modifier model class.
        /// </summary>
        public EventModifierModel()
        {
            FolderModel = new();
        }
    }
}