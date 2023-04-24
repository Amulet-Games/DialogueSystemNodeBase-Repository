using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class StoryNodeData : NodeDataBase
    {
        /// <summary>
        /// The data's input port data.
        /// </summary>
        [SerializeField] public PortDataBase InputPortData;


        /// <summary>
        /// The data's output port data.
        /// </summary>
        [SerializeField] public PortDataBase OutputPortData;


        /// <summary>
        /// The data's dialogue character value.
        /// </summary>
        [SerializeField] public DialogueCharacter DialogueCharacter;


        /// <summary>
        /// The data's audio clip language generic value.
        /// </summary>
        [SerializeField] public LanguageGeneric<AudioClip> AudioClipLanguageGeneric;


        /// <summary>
        /// The data's first textline text language generic value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> FirstTextlineTextLanguageGeneric;


        /// <summary>
        /// The data's second line trigger type enum value.
        /// </summary>
        [SerializeField] public int SecondLineTriggerTypeEnumIndex;


        /// <summary>
        /// The data's second textline text language generic value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> SecondTextlineTextLanguageGeneric;


        /// <summary>
        /// The data's duration float value.
        /// </summary>
        [SerializeField] public float DurationFloat;


        /// <summary>
        /// The data's CSV GUID value.
        /// </summary>
        [SerializeField] public string CsvGUID;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node data class.
        /// </summary>
        public StoryNodeData()
        {
            InputPortData = new();
            OutputPortData = new();
        }
    }
}