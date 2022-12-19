using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodePresenter : NodePresenterFrameBase
    <
        BooleanNode,
        BooleanNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the boolean node presenter module class.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public BooleanNodePresenter(BooleanNode node, BooleanNodeModel model)
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
                node: Node,
                contentBtnText: StringsConfig.AddConditionLabelText,
                contentBtnSprite: AssetsConfig.AddConditionModifierButtonIconSprite,
                contentBtnIconImageUSS01: StylesConfig.Integrant_ContentButton_AddCondition_Image
            );
        }


        /// <inheritdoc />
        public override void CreateNodePorts()
        {
            // Input port.
            Model.InputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.NodeInputLabelText,
                isSiblings: false
            );

            // True Output port.
            Model.TrueOutputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.BooleanNodeTrueOutputLabelText,
                isSiblings: false
            );

            // False Output port.
            Model.FalseOutputPort = DefaultPort.CreateRootElements<Edge>
            (
                node: Node,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                portlabel: StringsConfig.BooleanNodeFalseOutputLabelText,
                isSiblings: true
            );
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
                    evt: evt,
                    itemName: StringsConfig.DisconnectInputPortLabelText
                );
            }

            void AppendDisconnectTrueOuputPortAction()
            {
                Model.TrueOutputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectTrueOutputPortLabelText
                );
            }

            void AppendDisconnectFalseOuputPortAction()
            {
                Model.FalseOutputPort.AddContextualManuItems
                (
                    evt: evt,
                    itemName: StringsConfig.DisconnectFalseOutputPortLabelText
                );
            }

            void AppendDisconnectAllPortsAction()
            {
                // Disconnect All
                evt.menu.AppendAction
                (
                    actionName: StringsConfig.DisconnectAllPortLabelText,
                    action: actionEvent => DisconnectAllActionEvent(),
                    status: isInputPortConnected || isTrueOutputPortConnected || isFalseOutputPortConnected 
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