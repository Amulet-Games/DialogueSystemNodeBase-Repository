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
                    port: PortModel.Port.Default,
                    Direction.Input,
                    capacity: Capacity.Single,
                    name: StringConfig.Port_Input_LabelText,
                    color: PortConfig.DefaultPortColor
                );

                View.InputPort = PortManager.Instance.Create(portModel);
                View.InputPort.AddEdgeConnector
                (
                    nodeCreateConnectorWindow: Node.GraphViewer.NodeCreateDefaultConnectorWindow,
                    nodeCreateWindowEntries: NodeCreateEntryProvider.DefaultNodeInputEntries,
                    edgeFocusable: true,
                    edgeStyleSheet: ConfigResourcesManager.StyleSheetConfig.DefaultEdgeStyle
                );

                Node.Add(View.InputPort);
            }
        }
    }
}