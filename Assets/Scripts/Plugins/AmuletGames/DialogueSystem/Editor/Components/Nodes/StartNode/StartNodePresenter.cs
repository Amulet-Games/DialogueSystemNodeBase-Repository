using UnityEditor.Experimental.GraphView;
using static UnityEditor.Experimental.GraphView.Port;

namespace AG.DS
{
    /// <inheritdoc />
    public class StartNodePresenter : NodePresenterFrameBase
    <
        StartNode,
        StartNodeView
    >
    {
        /// <inheritdoc />
        public override void CreateElements(StartNode node)
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
            // Output
            {
                var portModel = new PortModel
                (
                    direction: Direction.Output,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_Output_LabelText,
                    color: PortConfig.DefaultPortColor,
                    edgeConnectorSearchWindowView: Node.GraphViewer.EdgeConnectorSearchWindowView,
                    edgeModel: new(focusable: true, styleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle)
                );

                View.OutputPort = PortFactory.Generate(portModel);

                Node.Add(View.OutputPort);
            }
        }
    }
}