using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSEventNodePresenter : DSNodePresenterFrameBase<DSEventNode, DSEventNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of event node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSEventNodePresenter(DSEventNode node, DSEventNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            // Create a new event molder within this node.
            Model.EventMolder.GetNewMolder
            (
                Node,
                DSStringsConfig.AddEventLabelText,
                DSAssetsConfig.AddEventModifierButtonIconImage,
                DSStylesConfig.Integrant_ContentButton_AddEvent_Image
            );
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            // Input port.
            Model.InputPort = DSDefaultPort.GetNewInputPort<Edge>
            (
                Node,
                DSStringsConfig.NodeInputLabelText,
                Port.Capacity.Single
            );
            
            // Output port.
            Model.OutputPort = DSDefaultPort.GetNewOutputPort<Edge>
            (
                Node,
                false,
                DSStringsConfig.NodeOutputLabelText,
                Port.Capacity.Single
            );
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            bool isInputPortConnected;
            bool isOutputPortConnected;

            SetupLocalFields();

            AppendDisconnectInputPortAction();

            AppendDisconnectOuputPortAction();

            AppendDisconnectAllPortsAction();

            void SetupLocalFields()
            {
                isInputPortConnected = Model.InputPort.connected;
                isOutputPortConnected = Model.OutputPort.connected;
            }

            void AppendDisconnectInputPortAction()
            {
                Model.InputPort.AddContextualManuItems
                (
                    evt,
                    DSStringsConfig.DisconnectInputPortLabelText
                );
            }

            void AppendDisconnectOuputPortAction()
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
                    isInputPortConnected || isOutputPortConnected ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect Input port.
                    if (isInputPortConnected) Model.InputPort.DisconnectPort();
                    // Disconnect Ouput port.
                    if (isOutputPortConnected) Model.OutputPort.DisconnectPort();
                }
            }
        }
    }
}