using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

namespace AG.DS
{
    /// <inheritdoc />
    public class BooleanNodePresenter : NodePresenterFrameBase
    <
        BooleanNode,
        BooleanNodeView
    >
    {
        /// <inheritdoc />
        public override void CreateElements(BooleanNode node)
        {
            base.CreateElements(node);

            CreateTitleElements();

            CreatePortElements();

            CreateContentElements();
        }


        /// <summary>
        /// Create the node's port elements.
        /// </summary>
        void CreatePortElements()
        {
            View.InputDefaultPort = DefaultPortPresenter.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Input,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_Input_LabelText
            );

            View.TrueOutputDefaultPort = DefaultPortPresenter.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_True_LabelText
            );

            View.FalseOutputDefaultPort = DefaultPortPresenter.CreateElement<DefaultEdge>
            (
                connectorWindow: Node.GraphViewer.NodeCreateConnectorWindow,
                direction: Direction.Output,
                capacity: Port.Capacity.Single,
                label: StringConfig.DefaultPort_False_LabelText,
                isSiblings: true
            );

            Node.Add(View.InputDefaultPort);
            Node.Add(View.TrueOutputDefaultPort);
            Node.Add(View.FalseOutputDefaultPort);
            Node.RefreshPorts();
        }


        /// <summary>
        /// Create the node's content elements.
        /// </summary>
        void CreateContentElements()
        {
            VisualElement contentContainer;

            SetupContainers();

            AddBooleanNodeStitcher();

            AddElementsToContainer();

            AddContainersToNode();

            void SetupContainers()
            {
                contentContainer = new();
                contentContainer.AddToClassList(StyleConfig.Node_Content_Container);
            }

            void AddBooleanNodeStitcher()
            {
                View.booleanNodeStitcher.CreateRootElements(Node);
            }

            void AddElementsToContainer()
            {
            }

            void AddContainersToNode()
            {
                Node.mainContainer.Add(contentContainer);
            }
        }
    }
}