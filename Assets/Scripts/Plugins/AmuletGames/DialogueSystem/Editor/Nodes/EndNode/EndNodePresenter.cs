using UnityEditor.Experimental.GraphView;

namespace AG.DS
{
    /// <inheritdoc />
    public class EndNodePresenter : NodePresenterFrameBase
    <
        EndNode,
        EndNodeView
    >
    {
        /// <inheritdoc />
        public override void CreateElements(EndNode node)
        {
            base.CreateElements(node);

            CreateTitleElements();

            CreatePortElements();
        }


        /// <summary>
        /// Create the node's port elements.
        /// </summary>
        void CreatePortElements()
        {
            View.InputPort = PortManager.Instance.CreateDefault
            (
                connectorWindow: Node.GraphViewer.NodeCreateDefaultConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                name: StringConfig.Port_Input_LabelText
            );

            Node.Add(View.InputPort);
        }
    }
}