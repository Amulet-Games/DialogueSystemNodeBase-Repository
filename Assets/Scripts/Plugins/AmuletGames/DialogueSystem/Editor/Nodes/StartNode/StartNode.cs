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
        /// Construtor of the start node component class.
        /// </summary>
        /// <param name="details">The connecting creation details to set for.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public StartNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringsConfig.StartNodeDefaultTitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            PostProcessNodeWidth();

            PostProcessNodePosition();

            AddStyleSheet();

            NodeCreatedAction();

            void SetupFrameFields()
            {
                StartNodeModel model = new();

                Presenter = new(node: this, model: model);
                Serializer = new(node: this, model: model);
                Callback = new(node: this, model: model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessNodeWidth
                (
                    minWidth: NodesConfig.StartNodeMinWidth,
                    widthBuffer: NodesConfig.StartNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSStartNodeStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Construtor of the start node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The given node data to load from.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public StartNode
        (
            StartNodeData data,
            GraphViewer graphViewer
        )
            : base(StringsConfig.StartNodeDefaultTitleText, graphViewer)
        {
            SetupFrameFields();

            CreateNodeElements();

            CreateNodePorts();

            PostProcessNodeWidth();

            AddStyleSheet();

            LoadNode(data);

            NodeCreatedAction();

            void SetupFrameFields()
            {
                StartNodeModel model = new();

                Presenter = new(node: this, model: model);
                Serializer = new(node: this, model: model);
                Callback = new(node: this, model: model);
            }

            void CreateNodeElements()
            {
                Presenter.CreateNodeElements();
            }

            void CreateNodePorts()
            {
                Presenter.CreateNodePorts();
            }

            void PostProcessNodeWidth()
            {
                Presenter.PostProcessNodeWidth
                (
                    minWidth: NodesConfig.StartNodeMinWidth,
                    widthBuffer: NodesConfig.StartNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSStartNodeStyle);
            }
        }
    }
}