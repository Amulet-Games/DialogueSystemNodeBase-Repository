using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

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
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            AddContentButton_ConditionModifier();

            AddOptionTrack();

            AddOptionHeaderTextContainer();

            AddConditionSegment();

            void AddContentButton_ConditionModifier()
            {
                DSIntegrantsMaker.GetNewContentButton
                (
                    Node,
                    DSStringsConfig.AddConditionLabelText,
                    DSAssetsConfig.AddConditionModifierButtonIconImage,
                    DSStylesConfig.Integrant_ContentButton_AddCondition_Image,
                    ContentButtonClickedAction
                );
            }

            void AddOptionTrack()
            {
                Model.OptionTrack.SetupTrack(Node);
            }

            void AddOptionHeaderTextContainer()
            {
                // Create a new option header text field within the node.
                Node.mainContainer.Add(DSLanguageFieldsMaker.GetNewTextField
                (
                    Model.OptionHeaderTextContainer,
                    DSAssetsConfig.InputHintIconSprite,
                    false,
                    DSStringsConfig.OptionNodeHeadlinePlaceHolderText,
                    DSStylesConfig.OptionNode_OptionHeader_TextField
                ));
            }

            void AddConditionSegment()
            {
                Model.ConditionSegment.SetupSegment(Node);
            }
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            // Output port.
            Model.OutputPort = DSDefaultPort.GetNewOutputPort<Edge>
            (
                Node,
                false,
                DSStringsConfig.NodeOutputLabelText,
                Port.Capacity.Single
            );
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after the content button is pressed.
        /// <para>ContentButtonClickedAction - DSIntegrantsMaker - ContentButtonMainBox.</para>
        /// </summary>
        void ContentButtonClickedAction()
        {
            // Create a new condition modifier within this node.
            DSModifiersMaker.GetNewConditionModifier
            (
                null,
                Model.ConditionSegment.ModifierAddedAction,
                Model.ConditionSegment.ModifierRemovedAction
            );

            // Reveal the condition segment on the connecting node.
            DSElementDisplayUtility.ShowElement(Model.ConditionSegment.MainBox);
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            bool isTrackPortConnected;
            bool isOutputPortConnected;

            SetupLocalFields();

            AddOptionTrackContextualMenuItems();

            AppendDisconnectOutputPortAction();

            AppendDisconnectAllPortsAction();

            void SetupLocalFields()
            {
                isTrackPortConnected = Model.OptionTrack.Port.connected;
                isOutputPortConnected = Model.OutputPort.connected;
            }

            void AddOptionTrackContextualMenuItems()
            {
                Model.OptionTrack.AddContextualManuItems(evt);
            }

            void AppendDisconnectOutputPortAction()
            {
                Model.OutputPort.AddContextualManuItems
                (
                    evt,
                    DSStringsConfig.DisconnectOutputPortLabelText
                );
            }

            void AppendDisconnectAllPortsAction()
            {
                // Disconnect All
                evt.menu.AppendAction
                (
                    DSStringsConfig.DisconnectAllPortLabelText,
                    actionEvent => DisconnectAllActionEvent(),
                    isTrackPortConnected || isOutputPortConnected ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect Track port.
                    if (isTrackPortConnected) Model.OptionTrack.DisconnectPort();
                    // Disconnect Output port.
                    if (isOutputPortConnected) Model.OutputPort.DisconnectPort();
                }
            }
        }
    }
}