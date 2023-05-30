using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodePresenter : NodePresenterFrameBase
    <
        StartNode,
        StartNodeModel
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node presenter class.
        /// </summary>
        /// <param name="node">The node element to set for.</param>
        /// <param name="model">The node model to set for.</param>
        public StartNodePresenter(StartNode node, StartNodeModel model)
        {
            Node = node;
            Model = model;
        }


        // ----------------------------- Makers -----------------------------
        /// <inheritdoc />
        public override void CreateContentElements()
        {
            base.CreateContentElements();
        }


        /// <inheritdoc />
        public override void CreatePortElements()
        {
            Model.OutputDefaultPort = DefaultPort.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.ProjectManager.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Output_LabelText
            );

            Node.Add(Model.OutputDefaultPort);
            Node.RefreshPorts();
        }


        // ----------------------------- Post Process Position Details -----------------------------
        /// <inheritdoc />
        protected override void GeometryChangedAdjustNodePosition(NodeCreateDetails details)
        {
            Node.SetPosition
            (
                details,
                leftSideAlignmentReferencePort: Model.OutputDefaultPort,
                middleAlignmentReferencePort: Model.OutputDefaultPort
            );
        }
    }
}