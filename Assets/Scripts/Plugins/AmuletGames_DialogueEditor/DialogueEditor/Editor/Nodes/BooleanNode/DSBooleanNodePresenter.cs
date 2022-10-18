using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSBooleanNodePresenter : DSNodePresenterFrameBase<DSBooleanNode, DSBooleanNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of boolean node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSBooleanNodePresenter(DSBooleanNode node, DSBooleanNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            // Create a new condition molder within this node.
            Model.ConditionMolder.GetNewMolder
            (
                Node,
                DSStringsConfig.AddConditionLabelText,
                DSAssetsConfig.AddConditionModifierButtonIconImage, 
                DSStylesConfig.Integrant_ContentButton_AddCondition_Image
            );
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            Model.InputPort = DSDefaultPort.GetNewInputPort<Edge>(Node, DSStringsConfig.NodeInputLabelText, Port.Capacity.Single);
            Model.TrueOutputPort = DSDefaultPort.GetNewOutputPort<Edge>(Node, false, DSStringsConfig.BooleanNodeTrueOutputLabelText, Port.Capacity.Single);
            Model.FalseOutputPort = DSDefaultPort.GetNewOutputPort<Edge>(Node, true, DSStringsConfig.BooleanNodeFalseOutputLabelText, Port.Capacity.Single);
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            bool isInputPortConnected;
            bool isTrueOutputPortConnected;
            bool isFalseOutputPortConnected;

            SetupLocalFields();

            AppendDisconnectInputPortAction();

            AppendDisconnectTrueOuputPortAction();

            AppendDisconnectFalseOuputPortAction();

            AppendDisconnectAllPortsAction();

            void SetupLocalFields()
            {
                isInputPortConnected = Model.InputPort.connected;
                isTrueOutputPortConnected = Model.TrueOutputPort.connected;
                isFalseOutputPortConnected = Model.FalseOutputPort.connected;
            }

            void AppendDisconnectInputPortAction()
            {
                Model.InputPort.AddContextualManuItems
                (
                    evt,
                    DSStringsConfig.DisconnectInputPortLabelText
                );
            }

            void AppendDisconnectTrueOuputPortAction()
            {
                Model.TrueOutputPort.AddContextualManuItems
                (
                    evt,
                    DSStringsConfig.DisconnectTrueOutputPortLabelText
                );
            }

            void AppendDisconnectFalseOuputPortAction()
            {
                Model.FalseOutputPort.AddContextualManuItems
                (
                    evt,
                    DSStringsConfig.DisconnectFalseOutputPortLabelText
                );
            }

            void AppendDisconnectAllPortsAction()
            {
                // Disconnect All
                evt.menu.AppendAction
                (
                    DSStringsConfig.DisconnectAllPortLabelText,
                    actionEvent => DisconnectAllActionEvent(),

                    isInputPortConnected || isTrueOutputPortConnected || isFalseOutputPortConnected 
                    ? DropdownMenuAction.Status.Normal 
                    : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect Input port.
                    Model.InputPort.DisconnectPort();
                    // Disconnect True Output port.
                    Model.TrueOutputPort.DisconnectPort();
                    // Disconnect False Output port.
                    Model.FalseOutputPort.DisconnectPort();
                }
            }
        }
    }
}