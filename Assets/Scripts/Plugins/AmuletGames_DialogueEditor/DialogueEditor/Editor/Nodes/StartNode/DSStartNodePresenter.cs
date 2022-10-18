using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSStartNodePresenter : DSNodePresenterFrameBase<DSStartNode, DSStartNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of start node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSStartNodePresenter(DSStartNode node, DSStartNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateNodeElements()
        {
            base.CreateNodeElements();
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


        // ----------------------------- Add Contextual Menu Items Services -----------------------------
        /// <inheritdoc />
        public override  void AddContextualManuItems(ContextualMenuPopulateEvent evt)
        {
            bool isOutputPortConnected;

            SetupLocalFields();

            AppendDisconnectOutputPortAction();

            AppendDisconnectAllPortsAction();

            void SetupLocalFields()
            {
                isOutputPortConnected = Model.OutputPort.connected;
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
                    isOutputPortConnected ? DropdownMenuAction.Status.Normal : DropdownMenuAction.Status.Disabled
                );

                void DisconnectAllActionEvent()
                {
                    // Disconnect Output port.
                    if (isOutputPortConnected) Model.OutputPort.DisconnectPort();
                }
            }
        }
    }
}