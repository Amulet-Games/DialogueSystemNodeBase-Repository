using System.Linq;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeSerializer : NodeSerializerFrameBase
    <
        BooleanNode,
        BooleanNodeModel,
        BooleanNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node serializer module class.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public BooleanNodeSerializer(BooleanNode node, BooleanNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void SaveNode(DialogueSystemData dsData)
        {
            var data = new BooleanNodeData();

            SaveBaseValues(data: data);

            SavePortsGUID();

            SaveBranchingOpponentNodesGUID();

            SaveConditionMolder();

            AddData();

            void SavePortsGUID()
            {
                data.InputPortGUID = Model.InputPort.name;
                data.TrueOutputPortGUID = Model.TrueOutputPort.name;
                data.FalseOutputPortGUID = Model.FalseOutputPort.name;
            }

            void SaveBranchingOpponentNodesGUID()
            {
                // True output opponent node
                data.TrueOutputOpponentNodeGUID = Model.TrueOutputPort.connected

                    // Connecting opponenet node's GUID.
                    ? ((NodeBase)Model.TrueOutputPort.connections.First().input.node).NodeGUID

                    // Save as empty string.
                    : "";


                data.FalseOutputOpponentNodeGUID = Model.FalseOutputPort.connected

                    // Connecting opponent node's GUID.
                    ? ((NodeBase)Model.FalseOutputPort.connections.First().input.node).NodeGUID

                    // Save as empty string.
                    : "";
            }

            void SaveConditionMolder()
            {
                Model.ConditionMolder.SaveMolderValues(data.ConditionMolderData);
            }

            void AddData()
            {
                dsData.BooleanNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(BooleanNodeData data)
        {
            LoadBaseValues(data);

            LoadPortsGUID();

            LoadConditionMolder();

            void LoadPortsGUID()
            {
                Model.InputPort.name = data.InputPortGUID;
                Model.TrueOutputPort.name = data.TrueOutputPortGUID;
                Model.FalseOutputPort.name = data.FalseOutputPortGUID;
            }

            void LoadConditionMolder()
            {
                Model.ConditionMolder.LoadMolderValues(data.ConditionMolderData);
            }
        }
    }
}