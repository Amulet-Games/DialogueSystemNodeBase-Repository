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
        /// <param name="details">The node create details to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public PreviewNode
        (
            NodeCreateDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.PreviewNode_TitleText, graphViewer)
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
                    minWidth: NodeConfig.PreviewNodeMinWidth,
                    widthBuffer: NodeConfig.PreviewNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.SetNodePosition(details);
            }

            void AddStyleSheet()
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSPreviewNodeStyle);
            }
        }


        // ----------------------------- Constructor (New) -----------------------------
        /// <summary>
        /// Constructor of the preview node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public PreviewNode
        (
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.PreviewNode_TitleText, graphViewer)
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
                    minWidth: NodeConfig.PreviewNodeMinWidth,
                    widthBuffer: NodeConfig.PreviewNodeWidthBuffer
                );   
            }

            // Add style sheet
            {
                styleSheets.Add(ConfigResourcesManager.Instance.StyleSheetConfig.DSPreviewNodeStyle);
            }
        }
    }
}