namespace AG.DS
{
    public class OptionRootNode : NodeFrameBase
    <
        OptionRootNode,
        OptionRootNodeModel,
        OptionRootNodePresenter,
        OptionRootNodeSerializer,
        OptionRootNodeCallback,
        OptionRootNodeData
    >
    {
        // ----------------------------- Constructor -----------------------------
        /// <summary>
        /// Constructor of the option root node component class.
        /// </summary>
        /// <param name="details">The node create details to set for.</param>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public OptionRootNode
        (
            NodeCreateDetails details,
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.OptionRootNode_TitleText, graphViewer)
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
                    minWidth: NodeConfig.OptionRootNodeMinWidth,
                    widthBuffer: NodeConfig.OptionRootNodeWidthBuffer
                );
            }

            void PostProcessNodePosition()
            {
                Presenter.SetNodePosition(details);
            }

            void AddStyleSheet()
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSOptionRootNodeStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
            }
        }
    

        // ----------------------------- Constructor (New) -----------------------------
        /// <summary>
        /// Constructor of the option root node component class.
        /// <para>Specifically used when the node is created by the previously saved data.</para>
        /// </summary>
        /// <param name="graphViewer">The graph viewer element to set for.</param>
        public OptionRootNode
        (
            GraphViewer graphViewer
        )
            : base(StringConfig.Instance.OptionRootNode_TitleText, graphViewer)
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
                    minWidth: NodeConfig.OptionRootNodeMinWidth,
                    widthBuffer: NodeConfig.OptionRootNodeWidthBuffer
                );
            }

            // Add style sheet
            {
                var styleSheetConfig = ConfigResourcesManager.Instance.StyleSheetConfig;
                styleSheets.Add(styleSheetConfig.DSOptionRootNodeStyle);
                styleSheets.Add(styleSheetConfig.DSSegmentStyle);
                styleSheets.Add(styleSheetConfig.DSContentButtonStyle);
            }
        }
    }
}