using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionTrackNodePresenter : NodePresenterFrameBase
    <
        OptionTrackNode,
        OptionTrackNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option track node presenter module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public OptionTrackNodePresenter(OptionTrackNode node, OptionTrackNodeModel model)
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

            AddInputSingleOptionChannel();

            AddHeaderTextContainer();

            AddConditionSegment();

            void AddContentButton_ConditionModifier()
            {
                IntegrantFactory.CreateNewContentButton
                (
                    node: Node,
                    btnText: StringsConfig.AddConditionLabelText,
                    btnIconSprite: AssetsConfig.AddConditionModifierButtonIconSprite,
                    btnIconImageUSS01: StylesConfig.Integrant_ContentButton_AddCondition_Image,
                    action: ContentButtonClickedAction
                );
            }

            void AddInputSingleOptionChannel()
            {
                Model.InputSingleOptionChannel.SetupChannel(Node);
            }

            void AddHeaderTextContainer()
            {
                Node.mainContainer.Add(LanguageFieldFactory.GetNewTextField
                (
                    languageTextContainer: Model.HeaderTextContainer,
                    fieldIcon: AssetsConfig.HeadlineTextFieldIcon,
                    isMultiLine: false,
                    placeholderText: StringsConfig.OptionTrackNodeHeadlinePlaceholderText,
                    fieldUSS01: StylesConfig.OptionTrackNode_Header_TextField
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
            Model.OutputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.NodeOutputLabelText,
                isSiblings: false
            );
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after the content button is pressed.
        /// <para>ContentButtonClickedAction - IntegrantsMaker - ContentButtonMainBox.</para>
        /// </summary>
        void ContentButtonClickedAction()
        {
            // Create a new condition modifier within this node.
            new ConditionModifier().CreateInstanceElements
            (
                data: null,
                addToSegmentAction: Model.ConditionSegment.ModifierAddedAction,
                removeFromSegmentAction: Model.ConditionSegment.ModifierRemovedAction
            );

            // Reveal the condition segment on the connecting node.
            VisualElementHelper.ShowElement(Model.ConditionSegment.MainBox);
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            bool isInputSingleOptionChannelConnected;
            bool isOutputPortConnected;

            SetupLocalFields();

            AppendDisconnectInputSingleOptionChannelAction();

            AppendDisconnectOutputPortAction();

            AppendDisconnectAllPortsAction();

            void SetupLocalFields()
            {
                isInputSingleOptionChannelConnected = Model.InputSingleOptionChannel.Port.connected;
                isOutputPortConnected = Model.OutputPort.connected;
            }

            void AppendDisconnectInputSingleOptionChannelAction()
            {
                Model.InputSingleOptionChannel.AddContextualManuItems(evt);
            }

            void AppendDisconnectOutputPortAction()
            {
                Model.OutputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectOutputPortLabelText
                );
            }

            void AppendDisconnectAllPortsAction()
            {
                // Disconnect All
                evt.menu.AppendAction
                (
                    actionName: StringsConfig.DisconnectAllPortLabelText,
                    action: actionEvent => DisconnectAllActionEvent(),
                    status: isInputSingleOptionChannelConnected || isOutputPortConnected
                            ? DropdownMenuAction.Status.Normal
                            : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect input single option channel port.
                    if (isInputSingleOptionChannelConnected)
                        Model.InputSingleOptionChannel.DisconnectPort();

                    // Disconnect Output port.
                    if (isOutputPortConnected)
                        Model.OutputPort.DisconnectPort();
                }
            }
        }
    }
}