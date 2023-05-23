namespace AG.DS
{
    public class StartNode : NodeFrameBase
    <
        StartNode,
        StartNodeModel,
        StartNodePresenter,
        StartNodeSerializer,
        StartNodeCallback,
        StartNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the start node component class.
        /// </summary>
        /// <param name="details">The node create details to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public StartNode
        (
            NodeCreateDetails details,
            GraphViewer graphViewer
        )
            : base(nodeTitle: StringConfig.Instance.StartNode_TitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            PostProcessNodeWidth();

            PostProcessNodePosition();

            AddStyleSheet();

            CreatedAction();

            void SetupFrameFields()
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
                Presenter.CreateContentElements();
            }

            void PostProcessNodeWidth()
            {
                Presenter.SetNodeWidth
                (
                    minWidth: NodeConfig.StartNodeMinWidth,
                    widthBuffer: NodeConfig.StartNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.SetNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSStartNodeStyle);
            }
        }


        // ----------------------------- Constructor (New) -----------------------------
        /// <summary>
        /// Constructor of the start node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public StartNode
        (
            GraphViewer graphViewer
        )
            : base(nodeTitle: StringConfig.Instance.StartNode_TitleText, graphViewer)
        {
            // Setup frame fields
            {
                Model = new(node: this);
                Presenter = new(node: this, model: Model);
                Serializer = new(node: this, model: Model);
                Callback = new(node: this, model: Model);
            }

            // Create elements
            {
                Presenter.CreateTitleElements();
                Presenter.CreatePortElements();
                Presenter.CreateContentElements();
            }

            // Setup node width
            {
                Presenter.SetNodeWidth
                (
                    minWidth: NodeConfig.StartNodeMinWidth,
                    widthBuffer: NodeConfig.StartNodeWidthBuffer
                );
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSStartNodeStyle);
            }
        }
    }
}