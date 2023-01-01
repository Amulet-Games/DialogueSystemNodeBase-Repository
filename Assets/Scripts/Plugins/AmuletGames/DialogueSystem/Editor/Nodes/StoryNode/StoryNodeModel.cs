using System;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeModel : NodeModelBase
    {
        /// <summary>
        /// Object container for the dialogue system's character scriptable object.
        /// </summary>
        public ObjectContainer<DialogueCharacter> CharacterObjectContainer;


        /// <summary>
        /// Object container for the dialogue's audio.
        /// </summary>
        public LanguageAudioClipContainer AudioClipContainer;


        /// <summary>
        /// Text container for the first dialogue's textline.
        /// </summary>
        public LanguageTextContainer FirstTextlineTextContainer;


        /// <summary>
        /// Enum container for the users to choose how they want to trigger the second line of dialogue
        /// <br>within the same segment.</br>
        /// </summary>
        public SecondLineTriggerTypeEnumContainer SecondLineTriggerTypeEnumContainer;


        /// <summary>
        /// Text container for the second dialogue's textline.
        /// </summary>
        public LanguageTextContainer SecondTextlineTextContainer;


        /// <summary>
        /// Float container for the users to input the delta time duration that they want to wait
        /// <br>to trigger the second line of dialogue.</br>
        /// </summary>
        public FloatContainer DurationFloatContainer;


        /// <summary>
        /// CSV GUID.
        /// </summary>
        public string CsvGUID;


        // ----------------------------- Ports -----------------------------
        /// <summary>
        /// Port that allows the other nodes to connect to this node.
        /// </summary>
        public DefaultPort InputPort;


        /// <summary>
        /// Port that allows this node to move forward to the other node.
        /// </summary>
        public DefaultPort OutputPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the event node model module class.
        /// </summary>
        public StoryNodeModel()
        {
            // First content
            CharacterObjectContainer = new();
            AudioClipContainer = new();
            FirstTextlineTextContainer = new();

            // Second content
            SecondLineTriggerTypeEnumContainer = new();
            DurationFloatContainer = new();
            SecondTextlineTextContainer = new();

            // CSV
            CsvGUID = Guid.NewGuid().ToString();
        }
    }
}