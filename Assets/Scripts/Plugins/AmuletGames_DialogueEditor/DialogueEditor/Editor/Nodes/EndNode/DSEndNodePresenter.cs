using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
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
        /// <summary>
        /// Create all the UIElements that exist within the connecting node.
        /// </summary>
        public void CreateNodeElements()
        {
            AddGraphEndHandleTypeEnumField();

            void AddGraphEndHandleTypeEnumField()
            {
                EnumField graphEndHandleEnum = DSEnumFieldsMaker.GetNewEnumField(Model.dialogueOverHandleType_EnumContainer, DSStylesConfig.EndNode_GraphEndHandleType_EnumField);
                
                // Add field to node's main container.
                Node.mainContainer.Add(graphEndHandleEnum);
            }
        }


        /// <summary>
        /// Create all the ports that exist within the connecting node.
        /// </summary>
        public void CreateNodePorts()
        {
            Model.InputPort = DSPortsMaker.AddInputPort(Node, DSStringsConfig.NodeInputLabelText, Port.Capacity.Multi);
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
        public override bool IsOutputPortConnected() => false;
    }
}