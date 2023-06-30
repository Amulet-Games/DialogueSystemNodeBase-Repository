using System.Linq;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodeSerializer : NodeSerializerFrameBase
    <
        BooleanNode,
        BooleanNodeView,
        BooleanNodeModel
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
        public override void Save(DialogueSystemModel dsModel)
        {
            BooleanNodeModel model = new();

            SaveBaseValues(model);

            SavePorts();

            SaveBranchingOpponentNodesGUID();

            SaveBooleanNodeStitcher();

            AddToDsModel();

            void SavePorts()
            {
                View.InputDefaultPort.Save(model.InputPortModel);
                View.TrueOutputDefaultPort.Save(model.TrueOutputPortModel);
                View.FalseOutputDefaultPort.Save(model.FalseOutputPortModel);
            }

            void SaveBranchingOpponentNodesGUID()
            {
                // True output opponent node
                model.TrueOutputOpponentNodeGUID = View.TrueOutputDefaultPort.connected

                    // Opponent node's GUID.
                    ? ((NodeBase)View.TrueOutputDefaultPort.connections.First().input.node).NodeGUID

                    // Save as empty string.
                    : "";


                model.FalseOutputOpponentNodeGUID = View.FalseOutputDefaultPort.connected

                    // Opponent node's GUID.
                    ? ((NodeBase)View.FalseOutputDefaultPort.connections.First().input.node).NodeGUID

                    // Save as empty string.
                    : "";
            }

            void SaveBooleanNodeStitcher()
            {
                View.booleanNodeStitcher.SaveStitcherValues(model.BooleanNodeStitcherModel);
            }

            void AddToDsModel()
            {
                dsModel.NodeModels.Add(model);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void Load(BooleanNodeModel model)
        {
            LoadBaseValues(model);

            LoadPorts();

            LoadBooleanNodeStitcher();

            void LoadPorts()
            {
                View.InputDefaultPort.Load(model.InputPortModel);
                View.TrueOutputDefaultPort.Load(model.TrueOutputPortModel);
                View.FalseOutputDefaultPort.Load(model.FalseOutputPortModel);
            }

            void LoadBooleanNodeStitcher()
            {
                View.booleanNodeStitcher.LoadStitcherValues(model.BooleanNodeStitcherModel);
            }
        }
    }
}