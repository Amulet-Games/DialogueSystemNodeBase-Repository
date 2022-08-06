using UnityEditor.Experimental.GraphView;

namespace AG
{
    public class DSChoiceNodePresenter : DSNodePresenterFrameBase<DSChoiceNode, DSChoiceNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of choice node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSChoiceNodePresenter(DSChoiceNode node, DSChoiceNodeModel model)
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
            AddContentButton_ConditionModifier();

            AddTextlineSegment();

            AddConditionSegment();

            void AddContentButton_ConditionModifier()
            {
                DSIntegrantsMaker.GetNewContentButton(Node, "Add Condition", DSAssetsConfig.addConditionModifierButtonIconImage, DSStylesConfig.integrant_ContentButton_AddCondition_Image, IntegrantButtonPressedAction);
            }

            void AddTextlineSegment()
            {
                Model.TextlineSegment.SetupSegment(Node);
            }

            void AddConditionSegment()
            {
                Model.ConditionSegment.SetupSegment(Node);
            }
        }


        /// <summary>
        /// Create all the ports that exist within the connecting node.
        /// </summary>
        public void CreateNodePorts()
        {
            Model.InputPort = DSPortsMaker.AddInputPort(Node, "Input", Port.Capacity.Multi, N_NodeType.Choice);
            Model.OutputPort = DSPortsMaker.AddOutputPort(Node, "Output", Port.Capacity.Single, N_NodeType.Choice);
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after content button is pressed.
        /// </summary>
        void IntegrantButtonPressedAction()
        {
            // Create a new condition modifier within this node.
            AddInstanceConditionModifier();

            // Reveal the condition segment on the connecting node.
            DSFieldUtility.ShowElement(Model.ConditionSegment.MainBox);
        }


        /// <summary>
        /// Helper function for adding a new instance condition modifier.
        /// </summary>
        void AddInstanceConditionModifier()
        {
            DSModifiersMaker.GetNewConditionModifier
            (
                null,
                Model.ConditionSegment.ModifierAddedAction,
                Model.ConditionSegment.ModifierRemovedAction
            );
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
        public override bool IsOutputPortConnected() => Model.OutputPort.connected;
    }
}