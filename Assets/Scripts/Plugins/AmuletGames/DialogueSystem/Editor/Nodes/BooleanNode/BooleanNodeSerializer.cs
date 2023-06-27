using System.Linq;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeSerializer : NodeSerializerFrameBase
    <
        BooleanNode,
        BooleanNodeView,
        BooleanNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node serializer class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="view">The node view to set for.</param>
        public BooleanNodeSerializer(BooleanNode node, BooleanNodeView view)
        {
            Node = node;
            View = view;
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
                View.InputDefaultPort.Save(data.InputPortData);
                View.TrueOutputDefaultPort.Save(data.TrueOutputPortData);
                View.FalseOutputDefaultPort.Save(data.FalseOutputPortData);
            }

            void SaveBranchingOpponentNodesGUID()
            {
                // True output opponent node
                data.TrueOutputOpponentNodeGUID = View.TrueOutputDefaultPort.connected

                    // Opponent node's GUID.
                    ? ((NodeBase)View.TrueOutputDefaultPort.connections.First().input.node).NodeGUID

                    // Save as empty string.
                    : "";


                data.FalseOutputOpponentNodeGUID = View.FalseOutputDefaultPort.connected

                    // Opponent node's GUID.
                    ? ((NodeBase)View.FalseOutputDefaultPort.connections.First().input.node).NodeGUID

                    // Save as empty string.
                    : "";
            }

            void SaveBooleanNodeStitcher()
            {
                View.booleanNodeStitcher.SaveStitcherValues(data.BooleanNodeStitcherData);
            }

            void AddData()
            {
                dsData.NodeData.Add(data);
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
                View.InputDefaultPort.Load(data.InputPortData);
                View.TrueOutputDefaultPort.Load(data.TrueOutputPortData);
                View.FalseOutputDefaultPort.Load(data.FalseOutputPortData);
            }

            void LoadBooleanNodeStitcher()
            {
                View.booleanNodeStitcher.LoadStitcherValues(data.BooleanNodeStitcherData);
            }
        }
    }
}