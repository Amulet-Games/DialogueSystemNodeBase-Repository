using UnityEditor.Experimental.GraphView;

namespace AG
{
    public class DSOptionNodePresenter : DSNodePresenterFrameBase<DSOptionNode, DSOptionNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of option node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSOptionNodePresenter(DSOptionNode node, DSOptionNodeModel model)
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

            AddOptionTrack();

            AddTextlineSegment();

            AddConditionSegment();

            void AddContentButton_ConditionModifier()
            {
                DSIntegrantsMaker.GetNewContentButton(Node, DSStringsConfig.AddConditionLabelText, DSAssetsConfig.AddConditionModifierButtonIconImage, DSStylesConfig.Integrant_ContentButton_AddCondition_Image, IntegrantButtonPressedAction);
            }

            void AddOptionTrack()
            {
                Model.OptionTrack.SetupTrack(Node);
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
            Model.OutputPort = DSPortsMaker.AddOutputPort(Node, false, DSStringsConfig.NodeOutputLabelText, Port.Capacity.Single);
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
            DSElementDisplayUtility.ShowElement(Model.ConditionSegment.MainBox);
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
        public override bool IsInputPortConnected() => Model.OptionTrack.Port.connected;


        /// <summary>
        /// Is the node's output ports are connecting to the other nodes?
        /// </summary>
        /// <returns>A boolean value that returns true if output ports are connected and vice versa.</returns>
        public override bool IsOutputPortConnected() => Model.OutputPort.connected;
    }
}