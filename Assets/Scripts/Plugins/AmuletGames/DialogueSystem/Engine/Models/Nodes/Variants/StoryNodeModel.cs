using System;
using UnityEngine;

namespace AG.DS
{
    /// <inheritdoc />
    [Serializable]
    public class StoryNodeModel : NodeModelBase
    {
        /// <summary>
        /// The node's input port model.
        /// </summary>
        [SerializeField] public PortModelBase InputPortModel;


        /// <summary>
        /// The node's output port model.
        /// </summary>
        [SerializeField] public PortModelBase OutputPortModel;


        /// <summary>
        /// The node's dialogue character value.
        /// </summary>
        [SerializeField] public DialogueCharacter DialogueCharacter;


        /// <summary>
        /// The node's audio clip language generic value.
        /// </summary>
        [SerializeField] public LanguageGeneric<AudioClip> AudioClipLanguageGeneric;


        /// <summary>
        /// The node's first textline text language generic value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> FirstTextlineTextLanguageGeneric;


        /// <summary>
        /// The node's second line trigger type enum value.
        /// </summary>
        [SerializeField] public int SecondLineTriggerTypeEnumIndex;


        /// <summary>
        /// The node's second textline text language generic value.
        /// </summary>
        [SerializeField] public LanguageGeneric<string> SecondTextlineTextLanguageGeneric;


        /// <summary>
        /// The node's duration float value.
        /// </summary>
        [SerializeField] public float DurationFloat;


        /// <summary>
        /// The node's CSV GUID value.
        /// </summary>
        [SerializeField] public string CsvGUID;


        /// <summary>
        /// Constructor of the story node model class.
        /// </summary>
        public StoryNodeModel()
        {
            InputPortModel = new();
            OutputPortModel = new();
        }
    }
}