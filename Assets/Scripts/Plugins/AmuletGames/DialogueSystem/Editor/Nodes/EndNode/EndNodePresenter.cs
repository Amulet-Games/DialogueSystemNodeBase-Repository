using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodePresenter : NodePresenterFrameBase
    <
        EndNode,
        EndNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the end node presenter class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public EndNodePresenter(EndNode node, EndNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreatePortElements()
        {
            Model.InputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            Node.Add(Model.InputDefaultPort);
            Node.RefreshPorts();
        }


        // ----------------------------- Post Process Position Details -----------------------------
        /// <inheritdoc />
        protected override void GeometryChangedAdjustNodePosition(NodeCreateDetails details)
        {
            Node.SetPosition
            (
                details,
                rightSideAlignmentReferencePort: Model.InputDefaultPort,
                middleAlignmentReferencePort: Model.InputDefaultPort
            );
        }
    }
}