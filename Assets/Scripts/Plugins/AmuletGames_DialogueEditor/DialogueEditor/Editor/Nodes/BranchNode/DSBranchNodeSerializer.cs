using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;

namespace AG
{
    public class DSBranchNodeSerializer : DSNodeSerializerFrameBase<DSBranchNode, DSBranchNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of branch node serializer.
        /// </summary>
        /// <param name="node">Node of which this serializer is connecting upon.</param>
        /// <param name="model">Model of which this serializer is connecting upon.</param>
        public DSBranchNodeSerializer(DSBranchNode node, DSBranchNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Save -----------------------------
        /// <summary>
        /// Create a new branch node's model and save the current model's data into it.
        /// </summary>
        /// <returns>A new copy of selected branch node model.</returns>
        public DSBranchNodeModel SaveNode()
        {
            DSBranchNodeModel newNodeModel;

            CreateNewBranchNodeModel();

            SaveBaseDetails(newNodeModel);

            SavePortsGuid();

            SaveBranchingOpponentNodesGuid();

            SaveConditionMolder();

            return newNodeModel;

            void CreateNewBranchNodeModel()
            {
                newNodeModel = new DSBranchNodeModel();
            }

            void SavePortsGuid()
            {
                newNodeModel.SavedInputPortGuid = Model.InputPort.name;
                newNodeModel.SavedTrueOutputPortGuid = Model.TrueOutputPort.name;
                newNodeModel.SavedFalseOutputPortGuid = Model.FalseOutputPort.name;
            }

            void SaveBranchingOpponentNodesGuid()
            {
                if (Model.TrueOutputPort.connected)
                {
                    // If true output port is connecting to other node, save the opponent node's Guid.
                    newNodeModel.SavedTrueInputNodeGuid =
                        ((DSNodeBase)Model.TrueOutputPort.connections.First().input.node).NodeGuid;
                }
                else
                {
                    // Otherwise simply leave it as empty.
                    newNodeModel.SavedTrueInputNodeGuid = "";
                }

                if (Model.FalseOutputPort.connected)
                {
                    // If false output port is connecting to other node, save the opponent node's Guid.
                    newNodeModel.SavedFalseInputNodeGuid =
                        ((DSNodeBase)Model.FalseOutputPort.connections.First().input.node).NodeGuid;
                }
                else
                {
                    // Otherwise simply leave it as empty.
                    newNodeModel.SavedFalseInputNodeGuid = "";
                }
            }

            void SaveConditionMolder()
            {
                newNodeModel.ConditionMolder.SaveMolderValues(Model.ConditionMolder);
            }
        }


        // ----------------------------- Load -----------------------------
        /// <summary>
        /// Create a new branch node to the graph with the data loaded from the source.
        /// </summary>
        /// <param name="source">The node's model of which this node is going to load from.</param>
        public void LoadNode(DSBranchNodeModel source)
        {
            LoadBaseDetails(source);

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