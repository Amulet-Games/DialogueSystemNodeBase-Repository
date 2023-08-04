using System;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeView : NodeViewFrameBase
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
        /// The input default port of the node.
        /// </summary>
        public DefaultPort InputDefaultPort;


        /// <summary>
        /// The output default port of the node.
        /// </summary>
        public DefaultPort OutputDefaultPort;


        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the story node view class.
        /// </summary>
        public StoryNodeView()
        {
            NodeTitleTextFieldView = new(value: StringConfig.StoryNode_TitleTextField_LabelText);

            SecondLineTriggerTypeEnumContainer = new();

            CsvGUID = Guid.NewGuid().ToString();
        }


        // ----------------------------- Service -----------------------------
        /// <inheritdoc />
        public override void RemovePorts(GraphViewer graphViewer)
        {
            // Remove from graph viewer cache
            graphViewer.Remove(port: InputDefaultPort);
            graphViewer.Remove(port: OutputDefaultPort);

            // Disconnect each ports
            InputDefaultPort.Disconnect(graphViewer);
            OutputDefaultPort.Disconnect(graphViewer);
        }
    }
}