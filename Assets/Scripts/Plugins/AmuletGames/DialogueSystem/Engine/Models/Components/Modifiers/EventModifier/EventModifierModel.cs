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
        /// The modifier's delay seconds value.
        /// </summary>
        [SerializeField] public double DelaySeconds;


        /// <summary>
        /// Constructor of the event modifier model class.
        /// </summary>
        public EventModifierModel()
        {
            FolderModel = new();
        }
    }
}