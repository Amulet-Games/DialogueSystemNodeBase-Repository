using System;
using UnityEngine;

namespace AG.DS
{
    [Serializable]
    public class MessageModifierData
    {
        /// <summary>
        /// The data's folder data.
        /// </summary>
        [SerializeField] public FolderData FolderData;


        /// <summary>
        /// The data's message text value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> MessageText;


        /// <summary>
        /// The data's message audio value.
        /// </summary>
        [SerializeField] public LanguageGeneric<AudioClip> MessageAudio;


        /// <summary>
        /// The data's CSV GUID value.
        /// </summary>
        [SerializeField] public string CsvGUID;
    }
}