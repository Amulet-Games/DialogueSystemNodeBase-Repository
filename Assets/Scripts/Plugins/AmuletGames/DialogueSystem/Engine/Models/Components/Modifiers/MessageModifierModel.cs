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
        /// The modifier's CSV GUID value.
        /// </summary>
        [SerializeField] public string CsvGUID;
    }
}