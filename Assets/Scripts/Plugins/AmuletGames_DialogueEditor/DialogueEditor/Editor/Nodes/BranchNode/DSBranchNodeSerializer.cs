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
        /// <param name="edges">List of edges that are currently in the graph.</param>
        /// <returns>A new copy of selected branch node model.</returns>
        public DSBranchNodeModel SaveNode(List<Edge> edges)
        {
            DSBranchNodeModel newNodeModel;

            CreateNewBranchNodeModel();

            SaveNodeDetails();

            SavePortsGuid();

            SaveBranchingNodesGuid();

            SaveConditionMolder();

            return newNodeModel;

            void CreateNewBranchNodeModel()
            {
                newNodeModel = new DSBranchNodeModel();
            }

            void SaveNodeDetails()
            {
                newNodeModel.SavedNodeGuid = Node.NodeGuid;
                newNodeModel.SavedNodePosition = Node.GetPosition().position;
            }

            void SavePortsGuid()
            {
                newNodeModel.SavedInputPortGuid = Model.InputPort.name;
                newNodeModel.SavedTrueOutputPortGuid = Model.TrueOutputPort.name;
                newNodeModel.SavedFalseOutputPortGuid = Model.FalseOutputPort.name;
            }

            void SaveBranchingNodesGuid()
            {
                // Find the edges that are connecting to this branch node's output ports.
                // Two edges for either True or False
                Edge trueOutputEdge = edges.FirstOrDefault(edge => edge.output == Model.TrueOutputPort);
                Edge falseOutputEdge = edges.FirstOrDefault(edge => edge.output == Model.FalseOutputPort);

                // Save their connecting input node's guid if edges were found.
                if (trueOutputEdge != null)
                {
                    newNodeModel.SavedTrueInputNodeGuid = ((DSNodeBase)trueOutputEdge.input.node).NodeGuid;
                }
                else
                {
                    newNodeModel.SavedTrueInputNodeGuid = "";
                }

                if (falseOutputEdge != null)
                {
                    newNodeModel.SavedFalseInputNodeGuid = ((DSNodeBase)falseOutputEdge.input.node).NodeGuid;
                }
                else
                {
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
            LoadNodeDetails();

            LoadPortsGuid();

            LoadConditionMolder();

            void LoadNodeDetails()
            {
                Node.NodeGuid = source.SavedNodeGuid;
            }

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