using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class MessageModifierData
    {
        /// <summary>
        /// The modifier's folder data.
        /// </summary>
        [SerializeField] public FolderData FolderData;


        /// <summary>
        /// The modifier's message text value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> MessageText;


        /// <summary>
        /// The modifier's message audio value.
        /// </summary>
        [SerializeField] public LanguageGeneric<AudioClip> MessageAudio;


        /// <summary>
        /// The modifier's continue by radio group data.
        /// </summary>
        [SerializeField] public RadioGroupData ContinueByRadioGroupData;


        /// <summary>
        /// The modifier's delay seconds value.
        /// </summary>
        [SerializeField] public float DelaySeconds;


        /// <summary>
        /// The modifier's message CSV Guid value.
        /// </summary>
        [SerializeField] public Guid MessageCSVGuid;


        /// <summary>
        /// Constructor of the message modifier data class.
        /// </summary>
        public MessageModifierData()
        {
            FolderData = new();
            MessageText = new();
            MessageAudio = new();
            ContinueByRadioGroupData = new();
        }
    }
}