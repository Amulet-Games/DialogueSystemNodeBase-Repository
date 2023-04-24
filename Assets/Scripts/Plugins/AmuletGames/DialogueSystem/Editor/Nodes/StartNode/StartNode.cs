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
        /// <param name="details">The node creation details to set for.</param>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        public StartNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(nodeTitle: StringConfig.Instance.StartNode_TitleText, graphViewer: graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            PostProcessNodeWidth();

            PostProcessNodePosition();

            AddStyleSheet();

            NodeCreatedAction();

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
                Presenter.PostProcessSetWidthValues
                (
                    minWidth: NodeConfig.StartNodeMinWidth,
                    widthBuffer: NodeConfig.StartNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSStartNodeStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the start node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The node data to load from.</param>
        /// <param name="graphViewer">The graph viewer module to set for.</param>
        public StartNode
        (
            StartNodeData data,
            GraphViewer graphViewer
        )
            : base(nodeTitle: StringConfig.Instance.StartNode_TitleText, graphViewer: graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            PostProcessNodeWidth();

            AddStyleSheet();

            Serializer.Load(data);

            NodeCreatedAction();

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
                Presenter.PostProcessSetWidthValues
                (
                    minWidth: NodeConfig.StartNodeMinWidth,
                    widthBuffer: NodeConfig.StartNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSStartNodeStyle);
            }
        }
    }
}