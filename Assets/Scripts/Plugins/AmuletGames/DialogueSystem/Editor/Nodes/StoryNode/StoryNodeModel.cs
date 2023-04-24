using System;

namespace AG.DS
{
    /// <inheritdoc />
    public class StoryNodeModel : NodeModelFrameBase<StoryNode>
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
        /// Constructor of the event node model module class.
        /// </summary>
        /// <param name="node">The node module to set for.</param>
        public StoryNodeModel(StoryNode node)
        {
            Node = node;

            // Second content
            SecondLineTriggerTypeEnumContainer = new();

            // CSV
            CsvGUID = Guid.NewGuid().ToString();
        }


        // ----------------------------- Remove Cache Ports All -----------------------------
        /// <inheritdoc />
        public override void RemoveCachePortsAll()
        {
            var serializeHandler = Node.GraphViewer.SerializeHandler;
            serializeHandler.RemoveCachePort(port: InputDefaultPort);
            serializeHandler.RemoveCachePort(port: OutputDefaultPort);
        }


        // ----------------------------- Disconnect Ports All -----------------------------
        /// <inheritdoc />
        public override void DisconnectPortsAll()
        {
            InputDefaultPort.Disconnect(Node.GraphViewer);
            OutputDefaultPort.Disconnect(Node.GraphViewer);
        }
    }
}