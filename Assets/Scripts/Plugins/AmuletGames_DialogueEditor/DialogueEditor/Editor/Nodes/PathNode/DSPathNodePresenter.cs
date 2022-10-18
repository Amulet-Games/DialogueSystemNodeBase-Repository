using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSPathNodePresenter : DSNodePresenterFrameBase<DSPathNode, DSPathNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of path node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        /// <param name="graphView">Dialogue system's graph view module.</param>
        public DSPathNodePresenter(DSPathNode node, DSPathNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            AddContentButton_OptionEntry();

            AddOptionEntry();

            AddImagesPreviewSegment();

            AddDialogueSegment();

            void AddContentButton_OptionEntry()
            {
                DSIntegrantsMaker.GetNewContentButton
                (
                    Node,
                    DSStringsConfig.AddEntryLabelText,
                    DSAssetsConfig.AddOptionEntryButtonIconImage,
                    DSStylesConfig.Integrant_ContentButton_AddOptionEntry_Image,
                    ContentButtonClickedAction
                );
            }

            void AddOptionEntry()
            {
                Model.OptionEntry.SetupEntry(Node);
            }

            void AddImagesPreviewSegment()
            {
                Model.DualPortraitsSegment.SetupSegment(Node);
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
            Model.InputPort = DSDefaultPort.GetNewInputPort<Edge>
            (
                Node,
                DSStringsConfig.NodeInputLabelText,
                Port.Capacity.Multi
            );
        }


        // ----------------------------- Callbacks -----------------------------
        /// <summary>
        /// Action that invoked after the content button is pressed.
        /// <para>ContentButtonClickedAction - DSIntegrantsMaker - ContentButtonMainBox.</para>
        /// </summary>
        void ContentButtonClickedAction()
        {
            // Create a new option entry within the node's option window component.
            Model.OptionWindow.GetNewOptionWindowEntry(null);

            // Refresh Ports Layout.
            Node.RefreshPorts();
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            bool isInputPortConnected;
            bool isEntryPortConnected;
            bool isWindowEntriesConnected;

            SetupLocalFields();

            AppendDisconnectInputPortAction();

            AppendDisconnectEntryPortAction();

            AppendDisconnectOptionWindowEntriesAction();

            AppendDisconnectAllPortsAction();

            void SetupLocalFields()
            {
                isInputPortConnected = Model.InputPort.connected;
                isEntryPortConnected = Model.OptionEntry.Port.connected;
                isWindowEntriesConnected = Model.OptionWindow.IsWindowEntriesConnected();
            }

            void AppendDisconnectInputPortAction()
            {
                Model.InputPort.AddContextualManuItems
                (
                    evt,
                    DSStringsConfig.DisconnectInputPortLabelText
                );
            }

            void AppendDisconnectEntryPortAction()
            {
                Model.OptionEntry.AddContextualManuItems(evt);
            }

            void AppendDisconnectOptionWindowEntriesAction()
            {
                Model.OptionWindow.AddContextualManuItems(evt);
            }

            void AppendDisconnectAllPortsAction()
            {
                // Disconnect All
                evt.menu.AppendAction
                (
                    DSStringsConfig.DisconnectAllPortLabelText,
                    actionEvent => DisconnectAllActionEvent(),

                    isInputPortConnected || isEntryPortConnected || isWindowEntriesConnected 
                    ? DropdownMenuAction.Status.Normal
                    : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect Input port.
                    Model.InputPort.DisconnectPort();
                    // Disconnect Continue Output port.
                    Model.OptionEntry.DisconnectPort();
                    // Disconnect Entry ports
                    if (isWindowEntriesConnected) Model.OptionWindow.DisconnectEntryPorts();
                }
            }
        }
    }
}