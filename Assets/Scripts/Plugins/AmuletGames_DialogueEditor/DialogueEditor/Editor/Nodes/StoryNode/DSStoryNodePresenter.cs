using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG
{
    public class DSStoryNodePresenter : DSNodePresenterFrameBase<DSStoryNode, DSStoryNodeModel>
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of story node's presenter.
        /// </summary>
        /// <param name="node">Node of which this presenter is connecting upon.</param>
        /// <param name="model">Model of which this presenter is connecting upon.</param>
        public DSStoryNodePresenter(DSStoryNode node, DSStoryNodeModel model)
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

        }
    }
}