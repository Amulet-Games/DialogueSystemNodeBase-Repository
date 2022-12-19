using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class OptionWindowNodePresenter : NodePresenterFrameBase
    <
        OptionWindowNode,
        OptionWindowNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option window node presenter module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public OptionWindowNodePresenter(OptionWindowNode node, OptionWindowNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            AddContentButton_NewOutputMultiOptionChannel();

            AddOutputSingleOptionChannel();

            AddHeaderTextContainer();

            AddDialogueSegment();

            void AddContentButton_NewOutputMultiOptionChannel()
            {
                IntegrantFactory.CreateNewContentButton
                (
                    node: Node,
                    btnText: StringsConfig.AddEntryLabelText,
                    btnIconSprite: AssetsConfig.AddEntryButtonIconSprite,
                    btnIconImageUSS01: StylesConfig.Integrant_ContentButton_AddEntry_Image,
                    action: ContentButtonClickedAction
                );
            }

            void AddOutputSingleOptionChannel()
            {
                Model.OutputSingleOptionChannel.SetupChannel(Node);
            }

            void AddHeaderTextContainer()
            {
                Node.mainContainer.Add(LanguageFieldFactory.GetNewTextField
                (
                    languageTextContainer: Model.HeaderTextContainer,
                    fieldIcon: AssetsConfig.HeadlineTextFieldIcon,
                    isMultiLine: false,
                    placeholderText: StringsConfig.OptionWindowNodeHeadlinePlaceholderText,
                    fieldUSS01: StylesConfig.OptionWindowNode_Header_TextField
                ));
            }

            void AddDialogueSegment()
            {
                Model.DialogueSegment.SetupSegment(Node);
            }
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            // Input port.
            Model.InputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Input,
                capacity: Port.Capacity.Multi,
                portlabel: StringsConfig.NodeInputLabelText,
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
            // Create a new output multi option channel.
            Model.OutputMultiOptionChannelGroup.GetNewChannel(data: null);

            // Update ports layout.
            Node.RefreshPorts();
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            bool isInputPortConnected;
            bool isOutputSingleOptionChannelConnected;
            bool isOutputMultiOptionChannelGroupConnected;

            SetupLocalFields();

            AppendDisconnectInputPortAction();

            AppendDisconnectOutputSingleOptionChannelAction();

            AppendDisconnectOutputMultiOptionChannelGroupAction();

            AppendDisconnectAllPortsAction();

            void SetupLocalFields()
            {
                isInputPortConnected = Model.InputPort.connected;
                isOutputSingleOptionChannelConnected = Model.OutputSingleOptionChannel.Port.connected;
                isOutputMultiOptionChannelGroupConnected = Model.OutputMultiOptionChannelGroup.IsConnectedChannelExists();
            }

            void AppendDisconnectInputPortAction()
            {
                Model.InputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectInputPortLabelText
                );
            }

            void AppendDisconnectOutputSingleOptionChannelAction()
            {
                Model.OutputSingleOptionChannel.AddContextualManuItems(evt);
            }

            void AppendDisconnectOutputMultiOptionChannelGroupAction()
            {
                Model.OutputMultiOptionChannelGroup.AddContextualManuItems(evt);
            }

            void AppendDisconnectAllPortsAction()
            {
                // Disconnect All
                evt.menu.AppendAction
                (
                    actionName: StringsConfig.DisconnectAllPortLabelText,
                    action: actionEvent => DisconnectAllActionEvent(),
                    status: isInputPortConnected || isOutputSingleOptionChannelConnected || isOutputMultiOptionChannelGroupConnected
                            ? DropdownMenuAction.Status.Normal
                            : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect input port.
                    if (isInputPortConnected)
                        Model.InputPort.DisconnectPort();

                    // Disconnect output single option channel port.
                    if (isOutputSingleOptionChannelConnected)
                        Model.OutputSingleOptionChannel.DisconnectPort();

                    // Disconnect output multi option channel group's channels' port.
                    if (isOutputMultiOptionChannelGroupConnected)
                        Model.OutputMultiOptionChannelGroup.DisconnectChannels();
                }
            }
        }
    }
}