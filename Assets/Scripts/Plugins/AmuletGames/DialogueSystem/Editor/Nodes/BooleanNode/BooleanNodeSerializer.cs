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
        /// <param name="node">The node module to set for.</param>
        /// <param name="model">The model module to set for.</param>
        public BooleanNodeSerializer(BooleanNode node, BooleanNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <inheritdoc />
        public override void Save(DialogueSystemData dsData)
        {
            BooleanNodeData data = new();

            SaveBaseValues(data: data);

            SavePorts();

            SaveBranchingOpponentNodesGUID();

            SaveBooleanNodeStitcher();

            AddData();

            void SavePorts()
            {
                Model.InputDefaultPort.Save(data.InputPortData);
                Model.TrueOutputDefaultPort.Save(data.TrueOutputPortData);
                Model.FalseOutputDefaultPort.Save(data.FalseOutputPortData);
            }

            void SaveBranchingOpponentNodesGUID()
            {
                // True output opponent node
                data.TrueOutputOpponentNodeGUID = Model.TrueOutputDefaultPort.connected

                    // Connecting opponenet node's GUID.
                    ? ((NodeBase)Model.TrueOutputDefaultPort.connections.First().input.node).NodeGUID

                    // Save as empty string.
                    : "";


                data.FalseOutputOpponentNodeGUID = Model.FalseOutputDefaultPort.connected

                    // Connecting opponent node's GUID.
                    ? ((NodeBase)Model.FalseOutputDefaultPort.connections.First().input.node).NodeGUID

                    // Save as empty string.
                    : "";
            }

            void SaveBooleanNodeStitcher()
            {
                Model.booleanNodeStitcher.SaveStitcherValues(data.BooleanNodeStitcherData);
            }

            void AddData()
            {
                dsData.BooleanNodeData.Add(data);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(BooleanNodeData data)
        {
            LoadBaseValues(data);

            LoadPorts();

            LoadBooleanNodeStitcher();

            void LoadPorts()
            {
                Model.InputDefaultPort.Load(data.InputPortData);
                Model.TrueOutputDefaultPort.Load(data.TrueOutputPortData);
                Model.FalseOutputDefaultPort.Load(data.FalseOutputPortData);
            }

            void LoadBooleanNodeStitcher()
            {
                Model.booleanNodeStitcher.LoadStitcherValues(data.BooleanNodeStitcherData);
            }
        }
    }
}