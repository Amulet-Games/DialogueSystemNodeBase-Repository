using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.GraphView.Port;

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
            // Input
            {
                var portModel = new PortModel
                (
                    direction: Direction.Input,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_Input_LabelText,
                    color: PortConfig.DefaultPortColor
                );
                var edgeModel = new EdgeModel
                (
                    focusable: true,
                    styleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );
                var edgeConnectorListenerModel = new EdgeConnectorListenerModel
                (
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeModel: edgeModel
                );

                View.InputPort = PortFactory.Generate(portModel);
                View.InputPort.AddEdgeConnector(edgeConnectorListenerModel);

                Node.Add(View.InputPort);
            }
        }
    }
}