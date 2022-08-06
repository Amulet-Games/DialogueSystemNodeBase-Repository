using UnityEditor.Experimental.GraphView;

namespace AG
{
    public class DSBranchNodePresenter : DSNodePresenterFrameBase<DSBranchNode, DSBranchNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of branch node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSBranchNodePresenter(DSBranchNode node, DSBranchNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <summary>
        /// Create all the UIElements that exist within the connecting node.
        /// </summary>
        public void CreateNodeElements()
        {
            AddConditionMolder();

            void AddConditionMolder()
            {
                Model.ConditionMolder.GetNewMolder(Node, "Add Condition", DSAssetsConfig.addConditionModifierButtonIconImage, DSStylesConfig.integrant_ContentButton_AddCondition_Image);
            }
        }


        /// <summary>
        /// Create all the ports that exist within the connecting node.
        /// </summary>
        public void CreateNodePorts()
        {
            Model.InputPort = DSPortsMaker.AddInputPort(Node, "Input", Port.Capacity.Multi, N_NodeType.Branch);
            Model.TrueOutputPort = DSPortsMaker.AddOutputPort(Node, "True", Port.Capacity.Single, N_NodeType.Branch);
            Model.FalseOutputPort = DSPortsMaker.AddOutputPort(Node, "False", Port.Capacity.Single, N_NodeType.Branch);
        }


        // ----------------------------- Ports Connection Check Services -----------------------------
        /// <summary>
        /// Is the node's input ports are connecting to the other nodes?
        /// </summary>
        /// <returns>A boolean value that returns true if input ports are connected and vice versa.</returns>
        public override bool IsInputPortConnected() => Model.InputPort.connected;


        /// <summary>
        /// Is the node's output ports are connecting to the other nodes?
        /// </summary>
        /// <returns>A boolean value that returns true if output ports are connected and vice versa.</returns>
        public override bool IsOutputPortConnected() => Model.FalseOutputPort.connected || Model.TrueOutputPort.connected;
    }
}