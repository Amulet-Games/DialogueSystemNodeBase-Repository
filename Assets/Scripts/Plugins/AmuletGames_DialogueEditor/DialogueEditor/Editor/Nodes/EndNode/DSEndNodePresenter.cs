using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSEndNodePresenter : DSNodePresenterFrameBase<DSEndNode, DSEndNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of end node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSEndNodePresenter(DSEndNode node, DSEndNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();

            AddGraphEndHandleTypeEnumField();

            void AddGraphEndHandleTypeEnumField()
            {
                // Create a new graph end handle type enum field within the node.
                Node.mainContainer.Add(DSEnumFieldsMaker.GetNewEnumField
                (
                    Model.dialogueOverHandleType_EnumContainer,
                    DSStylesConfig.EndNode_GraphEndHandleType_EnumField
                ));
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
                Port.Capacity.Single
            );
        }


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            bool isInputPortConnected;

            SetupLocalFields();

            AppendDisconnectInputPortAction();

            AppendDisconnectAllPortsAction();

            void SetupLocalFields()
            {
                isInputPortConnected = Model.InputPort.connected;
            }

            void AppendDisconnectInputPortAction()
            {
                Model.InputPort.AddContextualManuItems
                (
                    evt,
                    DSStringsConfig.DisconnectInputPortLabelText
                );
            }

            void AppendDisconnectAllPortsAction()
            {
                // Disconnect All
                evt.menu.AppendAction
                (
                    DSStringsConfig.DisconnectAllPortLabelText,
                    actionEvent => DisconnectAllActionEvent(),
                    isInputPortConnected ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect Input port.
                    if (isInputPortConnected) Model.InputPort.DisconnectPort();
                }
            }
        }
    }
}