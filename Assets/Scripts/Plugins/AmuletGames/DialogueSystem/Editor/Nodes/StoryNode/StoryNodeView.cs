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
        /// CSV GUID.
        /// </summary>
        public string CsvGUID;


        /// <summary>
        /// The input port element.
        /// </summary>
        public PortBase InputPort;


        /// <summary>
        /// The output port element.
        /// </summary>
        public PortBase OutputPort;


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