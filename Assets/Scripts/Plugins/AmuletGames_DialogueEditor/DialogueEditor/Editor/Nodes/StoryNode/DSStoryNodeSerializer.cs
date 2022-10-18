using System.Collections;
using System.Collections.Generic;

namespace AG
{
    public class DSStoryNodeSerializer : DSNodeSerializerFrameBase<DSStoryNode, DSStoryNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of story node serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSStoryNodeSerializer(DSStoryNode node, DSStoryNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new story node's model and save the current model's data into it.
        /// </summary>
        /// <returns>A new copy of selected event node model.</returns>
        public DSStoryNodeModel SaveNode()
        {
            DSStoryNodeModel newNodeModel = new DSStoryNodeModel(Node);

            SaveBaseValues(newNodeModel);

            SavePortsGuid();

            return newNodeModel;

            void SavePortsGuid()
            {
                newNodeModel.SavedInputPortGuid = Model.InputPort.name;
                newNodeModel.SavedOutputPortGuid = Model.OutputPort.name;
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(DSStoryNodeModel source)
        {
            LoadBaseValues(source);

            LoadPortsGuid();

            void LoadPortsGuid()
            {
                Model.InputPort.name = source.SavedInputPortGuid;
                Model.OutputPort.name = source.SavedOutputPortGuid;
            }
        }
    }
}