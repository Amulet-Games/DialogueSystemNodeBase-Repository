namespace AG.DS
{
    public class PreviewNode : NodeFrameBase
    <
        PreviewNode,
        PreviewNodeModel,
        PreviewNodePresenter,
        PreviewNodeSerializer,
        PreviewNodeCallback,
        PreviewNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the preview node component class.
        /// </summary>
        /// <param name="details">The connecting creation details to set for.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public PreviewNode
        (
            NodeCreationDetails details,
            GraphViewer graphViewer
        )
            : base(StringsConfig.PreviewNodeDefaultTitleText, graphViewer)
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
                PreviewNodeModel model = new();

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
                    minWidth: NodesConfig.PreviewNodeMinWidth,
                    widthBuffer: NodesConfig.PreviewNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.PostProcessNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSPreviewNodeStyle);
            }
        }


        // ----------------------------- Constructor (Load) -----------------------------
        /// <summary>
        /// Constructor of the preview node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="data">The given node data to load from.</param>
        /// <param name="graphViewer">Reference of the dialogue system's graph viewer module.</param>
        public PreviewNode
        (
            PreviewNodeData data,
            GraphViewer graphViewer
        )
            : base(StringsConfig.PreviewNodeDefaultTitleText, graphViewer)
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
                PreviewNodeModel model = new();

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
                    minWidth: NodesConfig.PreviewNodeMinWidth,
                    widthBuffer: NodesConfig.PreviewNodeWidthBuffer
                );
            }

            void AddStyleSheet()
            {
                styleSheets.Add(StylesConfig.DSPreviewNodeStyle);
            }
        }
    }
}