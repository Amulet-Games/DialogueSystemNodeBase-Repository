using System.Collections.Generic;

namespace AG
{
    public class DSOptionNodeSerializer : DSNodeSerializerFrameBase<DSOptionNode, DSOptionNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of option node's serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSOptionNodeSerializer(DSOptionNode node, DSOptionNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new option node's model and save the current model's data into it.
        /// </summary>
        /// <returns>A new copy of selected option node model.</returns>
        public DSOptionNodeModel SaveNode()
        {
            DSOptionNodeModel newNodeModel = new DSOptionNodeModel(Node);

            SaveBaseValues(newNodeModel);

            SavePortsGuid();

            SaveOptionTrack();

            SaveOptionHeaderTextContainer();

            SaveConditionSegment();

            return newNodeModel;

            void SavePortsGuid()
            {
                newNodeModel.SavedOutputPortGuid = Model.OutputPort.name;
            }

            void SaveOptionTrack()
            {
                newNodeModel.OptionTrack.SaveTrackValues(Model.OptionTrack);
            }

            void SaveOptionHeaderTextContainer()
            {
                newNodeModel.OptionHeaderTextContainer.SaveContainerValue(Model.OptionHeaderTextContainer);
            }

            void SaveConditionSegment()
            {
                newNodeModel.ConditionSegment.SaveSegmentValues(Model.ConditionSegment);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(DSOptionNodeModel source)
        {
            LoadBaseValues(source);

            LoadPortsGuid();

            LoadOptionTrack();

            LoadOptionHeaderTextContainer();

            LoadConditionSegment();

            void LoadPortsGuid()
            {
                Model.OutputPort.name = source.SavedOutputPortGuid;
            }

            void LoadOptionTrack()
            {
                Model.OptionTrack.LoadTrackValues(source.OptionTrack);
            }

            void LoadOptionHeaderTextContainer()
            {
                Model.OptionHeaderTextContainer.LoadContainerValue(source.OptionHeaderTextContainer);
            }

            void LoadConditionSegment()
            {
                Model.ConditionSegment.LoadSegmentValues(source.ConditionSegment);
            }
        }
    }
}