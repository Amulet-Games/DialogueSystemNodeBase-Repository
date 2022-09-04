using UnityEditor.Experimental.GraphView;

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
        /// <summary>
        /// Create all the UIElements that exist within the connecting node.
        /// </summary>
        public void CreateNodeElements()
        {
            AddEventMolder();

            void AddEventMolder()
            {
                Model.EventMolder.GetNewMolder(Node, DSStringsConfig.AddEventLabelText, DSAssetsConfig.AddEventModifierButtonIconImage, DSStylesConfig.Integrant_ContentButton_AddEvent_Image);
            }
        }


        /// <summary>
        /// Create all the ports that exist within the connecting node.
        /// </summary>
        public void CreateNodePorts()
        {
            Model.InputPort = DSPortsMaker.AddInputPort(Node, DSStringsConfig.NodeInputLabelText, Port.Capacity.Multi);
            Model.OutputPort = DSPortsMaker.AddOutputPort(Node, false, DSStringsConfig.NodeOutputLabelText, Port.Capacity.Single);
        }


        // ----------------------------- Ports Connection Check Services -----------------------------
        /// <summary>
        /// Is the node's input ports are connecting to the other nodes?
        /// </summary>
        /// <returns>A boolean value that returns true if input ports are connected and vice versa.</returns>
        public override bool IsInputPortConnected() => Model.InputPort.connected;


        /// <summary>
        /// Is the node's output ports are connecting to the other nodes?
        /// </summary>
        /// <returns>A boolean value that returns true if output ports are connected and vice versa.</returns>
        public override bool IsOutputPortConnected() => Model.OutputPort.connected;
    }
}