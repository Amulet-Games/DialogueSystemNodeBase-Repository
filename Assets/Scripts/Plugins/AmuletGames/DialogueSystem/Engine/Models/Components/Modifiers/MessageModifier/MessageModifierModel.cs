using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class MessageModifierModel
    {
        /// <summary>
        /// The modifier's folder model.
        /// </summary>
        [SerializeField] public FolderModel FolderModel;


        /// <summary>
        /// The modifier's message text value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> MessageText;


        /// <summary>
        /// The modifier's message audio value.
        /// </summary>
        [SerializeField] public LanguageGeneric<AudioClip> MessageAudio;


        /// <summary>
        /// The modifier's continue by radio group model.
        /// </summary>
        [SerializeField] public RadioGroupModel ContinueByRadioGroupModel;


        /// <summary>
        /// The modifier's delay seconds value.
        /// </summary>
        [SerializeField] public double DelaySeconds;


        /// <summary>
        /// The modifier's message CSV Guid value.
        /// </summary>
        [SerializeField] public Guid MessageCSVGuid;


        /// <summary>
        /// Constructor of the message modifier model class.
        /// </summary>
        public MessageModifierModel()
        {
            FolderModel = new();
            MessageText = new();
            MessageAudio = new();
            ContinueByRadioGroupModel = new();
        }
    }
}