using System.Linq;

namespace AG
{
    public class DSBooleanNodeSerializer : DSNodeSerializerFrameBase<DSBooleanNode, DSBooleanNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of boolean node serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSBooleanNodeSerializer(DSBooleanNode node, DSBooleanNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new boolean node's model and save the current model's data into it.
        /// </summary>
        /// <returns>A new copy of selected boolean node model.</returns>
        public DSBooleanNodeModel SaveNode()
        {
            DSBooleanNodeModel target = new DSBooleanNodeModel(Node);

            SaveBaseValues(target);

            SavePortsGuid();

            SaveBranchingOpponentNodesGuid();

            SaveConditionMolder();

            return target;

            void SavePortsGuid()
            {
                target.SavedInputPortGuid = Model.InputPort.name;
                target.SavedTrueOutputPortGuid = Model.TrueOutputPort.name;
                target.SavedFalseOutputPortGuid = Model.FalseOutputPort.name;
            }

            void SaveBranchingOpponentNodesGuid()
            {
                if (Model.TrueOutputPort.connected)
                {
                    // If true output port is connecting to other node, save the opponent node's Guid.
                    target.SavedTrueInputNodeGuid =
                        ((DSNodeBase)Model.TrueOutputPort.connections.First().input.node).NodeGuid;
                }
                else
                {
                    // Otherwise simply leave it as empty.
                    target.SavedTrueInputNodeGuid = "";
                }

                if (Model.FalseOutputPort.connected)
                {
                    // If false output port is connecting to other node, save the opponent node's Guid.
                    target.SavedFalseInputNodeGuid =
                        ((DSNodeBase)Model.FalseOutputPort.connections.First().input.node).NodeGuid;
                }
                else
                {
                    // Otherwise simply leave it as empty.
                    target.SavedFalseInputNodeGuid = "";
                }
            }

            void SaveConditionMolder()
            {
                target.ConditionMolder.SaveMolderValues(Model.ConditionMolder);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <inheritdoc />
        public override void LoadNode(DSBooleanNodeModel source)
        {
            LoadBaseValues(source);

            LoadPortsGuid();

            LoadConditionMolder();

            void LoadPortsGuid()
            {
                Model.InputPort.name = source.SavedInputPortGuid;
                Model.TrueOutputPort.name = source.SavedTrueOutputPortGuid;
                Model.FalseOutputPort.name = source.SavedFalseOutputPortGuid;
            }

            void LoadConditionMolder()
            {
                Model.ConditionMolder.LoadMolderValues(source.ConditionMolder);
            }
        }
    }
}