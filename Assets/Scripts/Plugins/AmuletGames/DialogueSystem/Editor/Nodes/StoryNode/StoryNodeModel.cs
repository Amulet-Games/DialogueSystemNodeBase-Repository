using System;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeModel : NodeModelFrameBase
    {
        /// <summary>
        /// Enum container for the users to choose how they want to trigger the second line of dialogue
        /// <br>within the same segment.</br>
        /// </summary>
        public MessageProgressTypeEnumFieldModel SecondLineTriggerTypeEnumContainer;


        /// <summary>
        /// Float container for the users to input the delta time duration that they want to wait
        /// <br>to trigger the second line of dialogue.</br>
        /// </summary>
        //public FloatFieldModel DurationFloatContainer;

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
        /// Constructor of the story node model class.
        /// </summary>
        public StoryNodeModel()
        {
            // Second content
            SecondLineTriggerTypeEnumContainer = new();

            // CSV
            CsvGUID = Guid.NewGuid().ToString();
        }


        // ----------------------------- Remove Ports All -----------------------------
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