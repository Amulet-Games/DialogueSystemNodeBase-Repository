using System;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeView : NodeViewFrameBase<StoryNodeView>
    {
        /// <summary>
        /// Enum container for the users to choose how they want to trigger the second line of dialogue
        /// <br>within the same segment.</br>
        /// </summary>
        public MessageProgressTypeEnumFieldView SecondLineTriggerTypeEnumContainer;


        /// <summary>
        /// Float container for the users to input the delta time duration that they want to wait
        /// <br>to trigger the second line of dialogue.</br>
        /// </summary>
        //public FloatFieldView DurationFloatContainer;

        /// <summary>
        /// CSV GUID.
        /// </summary>
        public string CsvGUID;


        /// <summary>
        /// The input default port element.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output default port element.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        /// <inheritdoc />
        public override StoryNodeView Setup(LanguageHandler languageHandler)
        {
            NodeTitleFieldView = new(value: StringConfig.StoryNode_NodeTitleField_DefaultText);
            SecondLineTriggerTypeEnumContainer = new();
            CsvGUID = Guid.NewGuid().ToString();

            return this;
        }
    }
}