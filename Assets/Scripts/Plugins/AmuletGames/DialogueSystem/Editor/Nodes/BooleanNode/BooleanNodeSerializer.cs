using System.Linq;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeSerializer : NodeSerializerFrameBase
    <
        BooleanNode,
        BooleanNodeView,
        BooleanNodeCallback,
        BooleanNodeModel
    >
    {
        /// <inheritdoc />
        public override void Save(BooleanNode node, BooleanNodeModel model)
        {
            base.Save(node, model);

            SavePorts();

            SaveBranchingOpponentNodesGUID();

            SaveBooleanNodeStitcher();

            void SavePorts()
            {
                node.View.InputDefaultPort.Save(model.InputPortModel);
                node.View.TrueOutputDefaultPort.Save(model.TrueOutputPortModel);
                node.View.FalseOutputDefaultPort.Save(model.FalseOutputPortModel);
            }

            void SaveBranchingOpponentNodesGUID()
            {
                // True output opponent node
                model.TrueOutputOpponentNodeGUID = node.View.TrueOutputDefaultPort.connected

                    // Opponent node's GUID.
                    ? ((NodeBase)node.View.TrueOutputDefaultPort.connections.First().input.node).NodeGUID

                    // Save as empty string.
                    : "";


                model.FalseOutputOpponentNodeGUID = node.View.FalseOutputDefaultPort.connected

                    // Opponent node's GUID.
                    ? ((NodeBase)node.View.FalseOutputDefaultPort.connections.First().input.node).NodeGUID

                    // Save as empty string.
                    : "";
            }

            void SaveBooleanNodeStitcher()
            {
                node.View.booleanNodeStitcher.SaveStitcherValues(model.BooleanNodeStitcherModel);
            }
        }


        /// <inheritdoc />
        public override void Load(BooleanNode node, BooleanNodeModel model)
        {
            base.Load(node, model);

            LoadPorts();

            LoadBooleanNodeStitcher();

            void LoadPorts()
            {
                node.View.InputDefaultPort.Load(model.InputPortModel);
                node.View.TrueOutputDefaultPort.Load(model.TrueOutputPortModel);
                node.View.FalseOutputDefaultPort.Load(model.FalseOutputPortModel);
            }

            void LoadBooleanNodeStitcher()
            {
                node.View.booleanNodeStitcher.LoadStitcherValues(model.BooleanNodeStitcherModel);
            }
        }
    }
}